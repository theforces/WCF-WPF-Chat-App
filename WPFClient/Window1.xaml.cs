using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Data.SqlClient;
using WPFClient.ServiceReference1;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, IChatCallback
    {

        //declarare variabile ce vor fi folosite pentru crearea conexiunii catre baza de date SQL Server
        string connectionString;
        SqlConnection cnn;

        //cream o variabila de tip SqlCommand( aceasta clasa este folosita sa se efectueze operatii de citire si scriere in baza de date) care va fi folosita sa citeasca din baza de date 
        SqlCommand command, commandID;


        //cream o variabila de tip String: sql care este folosita sa retina comanda string de SQL  
        String sql;

        SqlDataAdapter adapter;

        SqlDataReader dataReader;





        //SVC holds references to the proxy and cotracts..
        ChatClient proxy = null;
        ClientDC receiver = null;
        ClientDC localClient = null;

        //Client will create this folder when loading
        string rcvFilesPath = @"C:/WCF_Received_Files/";

        //When the communication object turns to fault state it will
        //require another thread to invoke a fault event
        private delegate void FaultedInvoker();

        //This will hold each online client with a listBoxItem to quickly handle adding
        //and removing clients when they join or leave
        Dictionary<ListBoxItem, ClientDC> OnlineClients = new Dictionary<ListBoxItem, ClientDC>();


        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
            chatListBoxNames.SelectionChanged += new SelectionChangedEventHandler(chatListBoxNames_SelectionChanged);
            chatTxtBoxType.KeyDown += new KeyEventHandler(chatTxtBoxType_KeyDown);
            chatTxtBoxType.KeyUp += new KeyEventHandler(chatTxtBoxType_KeyUp);

            
            
        }
        public System.Windows.Media.Brush CaretBrush { get; set; }

        //Service might be disconnected or stopped for any reason,
        //so we have to handle the state of the communication object,
        //the communication object will fire an event for each transitioning
        //from a state to another, notice that when a connection state goes
        //from opening to opened or from opened to closing state.. it can't go
        //back so, if it is closed or faulted you have to set the proxy = null;
        //to be able to create a proxy again and open a connection
        //..
        //I have made a method called HandleProxy() to handle the state
        //of the connection, so in each event like opened, closed or faulted
        //we will call this method, and it will switch on the connection state
        //and apply a suitable reaction.
        //..
        //Because this events will need to be invoked on another thread
        //you can do like so in WPF applications (I've got this idea from
        //Sacha Barber's greate article on WCF WPF Application)

        void InnerDuplexChannel_Closed(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvoker(HandleProxy));
                return;
            }
            HandleProxy();
        }

        void InnerDuplexChannel_Opened(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvoker(HandleProxy));
                return;
            }
            HandleProxy();
        }

        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvoker(HandleProxy));
                return;
            }
            HandleProxy();
        }

        #region Private Methods

        /// <summary>
        /// This is the most method I like, it helps us alot
        /// We may can't know when a connection is lost in 
        /// of network failure or service stopped.
        /// And also to maintain performance client doesnt know
        /// that the connection will be lost when hitting the 
        /// disconnect button, but when a session is terminated
        /// this method will be called, and it will handle everything.
        /// </summary>
        private void HandleProxy()
        {
            if (proxy != null)
            {
                switch (this.proxy.State)
                {
                    case CommunicationState.Closed:
                        proxy = null;
                        chatListBoxMsgs.Items.Clear();
                        chatListBoxNames.Items.Clear();
                        loginLabelStatus.Content = "Disconnected";
                        ShowChat(false);
                        ShowLogin(true);
                        loginButtonConnect.IsEnabled = true;
                        break;
                    case CommunicationState.Closing:
                        break;
                    case CommunicationState.Created:
                        break;
                    case CommunicationState.Faulted:
                        proxy.Abort();
                        proxy = null;
                        chatListBoxMsgs.Items.Clear();
                        chatListBoxNames.Items.Clear();
                        ShowChat(false);
                        ShowLogin(true);
                        loginLabelStatus.Content = "Disconnected";
                        loginButtonConnect.IsEnabled = true;
                        break;
                    case CommunicationState.Opened:
                        ShowLogin(false);
                        ShowChat(true);

                        chatLabelCurrentStatus.Content = "online";
                        chatLabelCurrentUName.Content = this.localClient.Name;

                        Dictionary<int, Image> images = GetImages();
                        Image img = images[loginComboBoxImgs.SelectedIndex];
                        chatCurrentImage.Source = img.Source;
                        break;
                    case CommunicationState.Opening:
                        break;
                    default:
                        break;
                }
            }

        }



        /// <summary>
        /// This is the second important method, which creates 
        /// the proxy, subscribe to connection state events
        /// and open a connection with the service
        /// </summary>
        private void Connect()
        {
            if (proxy == null)
            {
                try
                {
                    this.localClient = new ClientDC();
                    this.localClient.Name = txtUserName.Text.ToString();
                    this.localClient.AvatarID = loginComboBoxImgs.SelectedIndex;
                    InstanceContext context = new InstanceContext(this);
                    proxy = new ChatClient(context);
                    this.localClient.Password = pwbPassword.Password;
                    //As the address in the configuration file is set to localhost
                    //we want to change it so we can call a service in internal 
                    //network, or over internet
                    string servicePath = proxy.Endpoint.ListenUri.AbsolutePath;
                    string serviceListenPort = proxy.Endpoint.Address.Uri.Port.ToString();

                    proxy.Endpoint.Address = new EndpointAddress("net.tcp://" + "127.0.0.1" + ":" + serviceListenPort + servicePath);

                    proxy.Open();

                    proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);
                    proxy.InnerDuplexChannel.Opened += new EventHandler(InnerDuplexChannel_Opened);
                    proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
                    proxy.ConnectAsync(this.localClient);
                    proxy.ConnectCompleted += new EventHandler<ConnectCompletedEventArgs>(proxy_ConnectCompleted);

                }
                catch (Exception ex)
                {
                    txtUserName.Text = ex.Message.ToString();
                    loginLabelStatus.Content = "Offline";
                    loginButtonConnect.IsEnabled = true;
                }
            }
            else
            {
                HandleProxy();
            }
        }

        private void Send()
        {
            if (proxy != null && chatTxtBoxType.Text != "")
            {
                if (proxy.State == CommunicationState.Faulted)
                {
                    HandleProxy();
                }
                else
                {
                    //Create message, assign its properties
                    MessageDC msg = new MessageDC();
                    msg.Sender = this.localClient.Name;
                    msg.Content = chatTxtBoxType.Text.ToString();

                    //If whisper mode is checked and an item is
                    //selected in the list box of clients, it will
                    //arrange a client object called receiver
                    //to whisper
                    if ((bool)chatCheckBoxWhisper.IsChecked)
                    {
                        if (this.receiver != null)
                        {
                            proxy.WhisperAsync(msg, this.receiver);
                            chatTxtBoxType.Text = "";
                            chatTxtBoxType.Focus();
                        }
                    }

                    else
                    {
                        proxy.SayAsync(msg);
                        chatTxtBoxType.Text = "";
                        chatTxtBoxType.Focus();
                    }
                    //Tell the service to tell back all clients that this client
                    //has just finished typing..
                    proxy.IsWritingAsync(null);
                }
            }
        }


        /// <summary>
        /// This method to enable us scrolling the list box of messages
        /// when a new message comes from the service..
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private ScrollViewer FindVisualChild(DependencyObject obj)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is ScrollViewer)
                {
                    return (ScrollViewer)child;
                }
                else
                {
                    ScrollViewer childOfChild = FindVisualChild(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// This is an important method which is called whenever
        /// a message comes from the service, a client joins or
        /// leaves, to return a ready item to be added in the
        /// list box (either the one for messages or the one for
        /// clients).
        /// </summary>
        /// <param name="imgID"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private ListBoxItem MakeItem(int imgID, string text)
        {
            ListBoxItem item = new ListBoxItem();
            Dictionary<int, Image> images = GetImages();
            Image img = images[imgID];
            img.Height = 70;
            img.Width = 60;
            item.Content = img;

            TextBlock txtblock = new TextBlock();
            txtblock.Text = text;
            txtblock.VerticalAlignment = VerticalAlignment.Center;

            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Children.Add(item);
            panel.Children.Add(txtblock);

            ListBoxItem bigItem = new ListBoxItem();
            bigItem.Content = panel;

            return bigItem;
        }




        /// <summary>
        /// This method is not used, I just put it here to help
        /// you in case you want to make a rich text box and enable
        /// emoticons for example.
        /// Just add a richTextBox control and set
        /// richTextBox.Document = MakeDocument(imgid, text);
        /// </summary>
        /// <param name="imgID"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private FlowDocument MakeDocument(int imgID, string text)
        {
            Dictionary<int, Image> images = GetImages();
            Image img = images[imgID];
            img.Height = 70;
            img.Width = 60;


            Block imgBlock = new BlockUIContainer(img);
            Block txtBlock = new Paragraph(new Run(text));


            FlowDocument doc = new FlowDocument();
            doc.Blocks.Add(imgBlock);

            doc.Blocks.Add(txtBlock);

            doc.FlowDirection = FlowDirection.LeftToRight;
            return doc;
        }

        /// <summary>
        /// A method to retreive avatars as stream objects
        /// and get an objects of type Image from the stream,
        /// to return a dictionary of images and an ID for each
        /// image.
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, Image> GetImages()
        {
            List<Stream> picsStrm = new List<Stream>();

            Assembly asmb = Assembly.GetExecutingAssembly();
            string[] picNames = asmb.GetManifestResourceNames();

            foreach (string s in picNames)
            {
                if (s.EndsWith(".png"))
                {
                    Stream strm = asmb.GetManifestResourceStream(s);
                    if (strm != null)
                    {
                        picsStrm.Add(strm);
                    }
                }
            }

            Dictionary<int, Image> images = new Dictionary<int, Image>();
            int i = 0;

            foreach (Stream strm in picsStrm)
            {

                PngBitmapDecoder decoder = new PngBitmapDecoder(strm,
                    BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmap = decoder.Frames[0] as BitmapSource;
                Image img = new Image();
                img.Source = bitmap;
                img.Stretch = Stretch.UniformToFill;

                images.Add(i, img);
                i++;

                strm.Close();
            }
            return images;
        }

        /// <summary>
        /// Show or hide login controls depends on the parameter
        /// </summary>
        /// <param name="show"></param>
        private void ShowLogin(bool show)
        {
            if (show)
            {
                loginButtonConnect.Visibility = Visibility.Visible;
                loginComboBoxImgs.Visibility = Visibility.Visible;
                
                loginLabelStatus.Visibility = Visibility.Visible;
                //loginLabelTitle.Visibility = Visibility.Visible;
                tbUsername.Visibility = Visibility.Visible;

                chenar_urat.Visibility = Visibility.Visible;
                txtUserName.Visibility = Visibility.Visible;
                loginButtonUpdate.Visibility = Visibility.Collapsed;
                textBoxUpdatePassword.Visibility = Visibility.Collapsed;
                loginButtonDelete.Visibility = Visibility.Collapsed;
            }
            else
            {
                loginButtonConnect.Visibility = Visibility.Collapsed;
                loginComboBoxImgs.Visibility = Visibility.Collapsed;
                chenar_urat.Visibility = Visibility.Collapsed;
                loginLabelStatus.Visibility = Visibility.Collapsed;
                //loginLabelTitle.Visibility = Visibility.Collapsed;
                tbUsername.Visibility = Visibility.Collapsed;
                
               
                txtUserName.Visibility = Visibility.Collapsed;
                loginButtonUpdate.Visibility = Visibility.Visible;
                textBoxUpdatePassword.Visibility = Visibility.Visible;
                loginButtonDelete.Visibility = Visibility.Visible;
            }
        }


        /// <summary>
        /// Show or hide chat controls depends on the parameter
        /// </summary>
        /// <param name="show"></param>
        private void ShowChat(bool show)
        {
            if (show)
            {
                chatButtonDisconnect.Visibility = Visibility.Visible;
                chatButtonSend.Visibility = Visibility.Visible;
                chatCheckBoxWhisper.Visibility = Visibility.Visible;
                chatCurrentImage.Visibility = Visibility.Visible;
                chatLabelCurrentStatus.Visibility = Visibility.Visible;
                chatLabelCurrentUName.Visibility = Visibility.Visible;
                chatListBoxMsgs.Visibility = Visibility.Visible;
                chatListBoxNames.Visibility = Visibility.Visible;
                chatTxtBoxType.Visibility = Visibility.Visible;
                chatLabelWritingMsg.Visibility = Visibility.Visible;
                chatLabelSendFileStatus.Visibility = Visibility.Visible;
                chatButtonOpenReceived.Visibility = Visibility.Visible;
                chatButtonSendFile.Visibility = Visibility.Visible;
                loginButtonUpdate.Visibility = Visibility.Visible;
                textBoxUpdatePassword.Visibility = Visibility.Visible;
                loginButtonDelete.Visibility = Visibility.Visible;
            }
            else
            {
                chatButtonDisconnect.Visibility = Visibility.Collapsed;
                chatButtonSend.Visibility = Visibility.Collapsed;
                chatCheckBoxWhisper.Visibility = Visibility.Collapsed;
                chatCurrentImage.Visibility = Visibility.Collapsed;
                chatLabelCurrentStatus.Visibility = Visibility.Collapsed;
                chatLabelCurrentUName.Visibility = Visibility.Collapsed;
                chatListBoxMsgs.Visibility = Visibility.Collapsed;
                chatListBoxNames.Visibility = Visibility.Collapsed;
                chatTxtBoxType.Visibility = Visibility.Collapsed;
                chatLabelWritingMsg.Visibility = Visibility.Collapsed;
                chatLabelSendFileStatus.Visibility = Visibility.Collapsed;
                chatButtonOpenReceived.Visibility = Visibility.Collapsed;
                chatButtonSendFile.Visibility = Visibility.Collapsed;
                loginButtonUpdate.Visibility = Visibility.Collapsed;
                textBoxUpdatePassword.Visibility = Visibility.Collapsed;
                loginButtonDelete.Visibility = Visibility.Collapsed;
            }
        }

        #endregion


        #region UI_Events

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            //Create a folder named WCF_Received_Files in C directory
            DirectoryInfo dir = new DirectoryInfo(rcvFilesPath);
            dir.Create();

            Dictionary<int, Image> images = GetImages();
            //Populate images in the login comboBoc control
            foreach (Image img in images.Values)
            {
                ListBoxItem item = new ListBoxItem();
                item.Width = 90;
                item.Height = 90;
                item.Content = img;

                loginComboBoxImgs.Items.Add(item);
            }
            loginComboBoxImgs.SelectedIndex = 0;

            ShowChat(false);
            ShowLogin(true);

        }

        private void chatButtonOpenReceived_Click(object sender, RoutedEventArgs e)
        {
            //Open WCF_Received_Files folder in windows explorer
            System.Diagnostics.Process.Start(rcvFilesPath);
        }

        private void chatButtonSendFile_Click(object sender, RoutedEventArgs e)
        {
            if (this.receiver != null)
            {
                Stream strm = null;
                try
                {
                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.Multiselect = false;

                    if (fileDialog.ShowDialog() == DialogResult.HasValue)
                    {
                        return;
                    }

                    strm = fileDialog.OpenFile();
                    if (strm != null)
                    {
                        byte[] buffer = new byte[(int)strm.Length];

                        int i = strm.Read(buffer, 0, buffer.Length);

                        if (i > 0)
                        {
                            FileMessageDC fMsg = new FileMessageDC();
                            fMsg.FileName = fileDialog.SafeFileName;
                            fMsg.Sender = this.localClient.Name;
                            fMsg.Data = buffer;
                            proxy.SendFileAsync(fMsg, this.receiver);
                            proxy.SendFileCompleted += new EventHandler<SendFileCompletedEventArgs>(proxy_SendFileCompleted);
                            chatLabelSendFileStatus.Content = "Sending...";
                        }

                    }
                }
                catch (Exception ex)
                {
                    chatTxtBoxType.Text = ex.Message.ToString();
                }
                finally
                {
                    if (strm != null)
                    {
                        strm.Close();
                    }
                }
            }

        }

        void proxy_SendFileCompleted(object sender, SendFileCompletedEventArgs e)
        {
            chatLabelSendFileStatus.Content = "File Sent";
        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (proxy != null)
            {
                if (proxy.State == CommunicationState.Opened)
                {
                    proxy.Disconnect(this.localClient);
                    //dont set proxy.Close(); because isTerminating = true on Disconnect()
                    //and this by default will call HandleProxy() to take care of this.
                }
                else
                {
                    HandleProxy();
                }
            }
        }

        private void buttonConnect_Click(object sender, RoutedEventArgs e)
        {
            loginButtonConnect.IsEnabled = false;
            loginLabelStatus.Content = "Connecting..";
            proxy = null;
            Connect();
            txtUserName.Text = "";
            pwbPassword.Password = "";

        }


        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();

        }


        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            this.localClient = new ClientDC();
            this.localClient.Name = txtUserName.Text.ToString();
            this.localClient.AvatarID = loginComboBoxImgs.SelectedIndex;
            this.localClient.Password = pwbPassword.Password;
            InstanceContext context = new InstanceContext(this);
            proxy = new ChatClient(context);

            //As the address in the configuration file is set to localhost
            //we want to change it so we can call a service in internal 
            //network, or over internet
            string servicePath = proxy.Endpoint.ListenUri.AbsolutePath;
            string serviceListenPort = proxy.Endpoint.Address.Uri.Port.ToString();

            proxy.Endpoint.Address = new EndpointAddress("net.tcp://" + "127.0.0.1" + ":" + serviceListenPort + servicePath);

            proxy.Open();

            proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);
            proxy.InnerDuplexChannel.Opened += new EventHandler(InnerDuplexChannel_Opened);
            proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);

            Register();

            

        }
        private void pwbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pwbPassword.Password.Length > 0)
                tbPassword.Visibility = Visibility.Collapsed;
            else
                tbPassword.Visibility = Visibility.Visible;
        }
        private void Password_MouseEnter(object sender, MouseEventArgs e)
        {

            tbPassword.Opacity = 0.7;
        }
        private void Password_MouseLeave(object sender, MouseEventArgs e)
        {

            tbPassword.Opacity = 1;

        }
        private void Register()
        {
            proxy.RegisterAsync(localClient);
            proxy.RegisterCompleted += new EventHandler<RegisterCompletedEventArgs>(proxy_RegisterCompleted);
        }
        private void proxy_RegisterCompleted(object o, RegisterCompletedEventArgs e)
        {
            proxy = null;
            localClient = null;
            //todo 
        }
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUpdatePassword.Text.Equals(localClient.Password))
            {
                MessageBox.Show("New password is the same as the old password! Please insert a different password!");
                return;
            }

            if (textBoxUpdatePassword.Text != "")
                Update(textBoxUpdatePassword.Text);
            else
           
                MessageBox.Show("Password field is empty!");
              
           


        }

        private void Update(string newPassword)
        {
            proxy.Update(localClient, newPassword);
            proxy.UpdateCompleted += new EventHandler<UpdateCompletedEventArgs>(proxy_UpdateCompleted);

        }

        private void proxy_UpdateCompleted(object o, UpdateCompletedEventArgs e)
        {
            //todo 
        }
        private void Delete()
        {
            proxy.Delete(localClient);
            proxy.DeleteCompleted += new EventHandler<DeleteCompletedEventArgs>(proxy_DeleteCompleted);
            proxy.DisconnectAsync(this.localClient);
        }

        private void proxy_DeleteCompleted(object o, DeleteCompletedEventArgs e)
        {
            proxy = null;
            HandleProxy();
        }
        void proxy_ConnectCompleted(object sender, ConnectCompletedEventArgs e)
        {
            if (e.Error != null )
            {
                loginLabelStatus.Foreground = new SolidColorBrush(Colors.Red);
                txtUserName.Text = e.Error.Message.ToString();
                loginButtonConnect.IsEnabled = true;
            }
            else if (e.Result)
            {
                HandleProxy();
            }
            else if (!e.Result)
            {
                loginLabelStatus.Content = "Username or password is incorrect";
                loginButtonConnect.IsEnabled = true;
            }


        }

        private void chatButtonSend_Click(object sender, RoutedEventArgs e)
        {
            Send();
        }

        private void chatButtonDisconnect_Click(object sender, RoutedEventArgs e)
        {
            if (proxy != null)
            {
                if (proxy.State == CommunicationState.Faulted)
                {
                    HandleProxy();
                }
                else
                {
                    proxy.DisconnectAsync(this.localClient);
                }
            }
        }


        void chatTxtBoxType_KeyUp(object sender, KeyEventArgs e)
        {
            if (proxy != null)
            {
                if (proxy.State == CommunicationState.Faulted)
                {
                    HandleProxy();
                }
                else
                {
                    if (chatTxtBoxType.Text.Length < 1)
                    {
                        proxy.IsWritingAsync(null);
                    }
                }
            }
        }

        void chatTxtBoxType_KeyDown(object sender, KeyEventArgs e)
        {
            if (proxy != null)
            {
                if (proxy.State == CommunicationState.Faulted)
                {
                    HandleProxy();
                }
                else
                {
                    if (e.Key == Key.Enter)
                    {
                        Send();
                    }
                    else if (chatTxtBoxType.Text.Length < 1)
                    {
                        proxy.IsWritingAsync(this.localClient);
                    }
                }
            }
        }

        void chatListBoxNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If user select an online client, make a client object
            //to be the receiver if the user wants to whisper him.
            ListBoxItem item = chatListBoxNames.SelectedItem as ListBoxItem;
            if (item != null)
            {
                this.receiver = this.OnlineClients[item];
            }
        }


        #endregion

        #region IChatCallback Members

        public void RefreshClients(List<ClientDC> clients)
        {
            //var clientsList = new List<ClientDC>();
            //for (int i = 0; i < clients.Length; i++)
            //    clientsList.Add(clients[i]);

            chatListBoxNames.Items.Clear();
            OnlineClients.Clear();
            foreach (ClientDC c in clients)
            {
                ListBoxItem item = MakeItem(c.AvatarID, c.Name);
                chatListBoxNames.Items.Add(item);
                OnlineClients.Add(item, c);
            }
        }

        public void Receive(MessageDC msg)
        {
            foreach (ClientDC c in this.OnlineClients.Values)
            {
                if (c.Name == msg.Sender)
                {
                    ListBoxItem item = MakeItem(c.AvatarID, msg.Sender + " : " + msg.Content);
                    chatListBoxMsgs.Items.Add(item);
                }
            }
            ScrollViewer sv = FindVisualChild(chatListBoxMsgs);
            sv.LineDown();
        }

        public void ReceiveWhisper(MessageDC msg, ClientDC receiver)
        {
            foreach (ClientDC c in this.OnlineClients.Values)
            {
                if (c.Name == msg.Sender)
                {
                    ListBoxItem item = MakeItem(c.AvatarID,
                        msg.Sender + " whispers " + receiver.Name + " : " + msg.Content);
                    chatListBoxMsgs.Items.Add(item);
                }
            }
            ScrollViewer sv = FindVisualChild(chatListBoxMsgs);
            sv.LineDown();
        }

        public void IsWritingCallback(ClientDC client)
        {
            if (client == null)
            {
                chatLabelWritingMsg.Content = "";
            }
            else
            {
                chatLabelWritingMsg.Content += client.Name + " is writing a message.., ";
            }
        }

        public void ReceiverFile(FileMessageDC fileMsg, ClientDC receiver)
        {
            try
            {
                FileStream fileStrm = new FileStream(rcvFilesPath + fileMsg.FileName, FileMode.Create, FileAccess.ReadWrite);
                fileStrm.Write(fileMsg.Data, 0, fileMsg.Data.Length);
                chatLabelSendFileStatus.Content = "Received file, " + fileMsg.FileName;
            }
            catch (Exception ex)
            {
                chatLabelSendFileStatus.Content = ex.Message.ToString();
            }
        }

        public void UserJoin(ClientDC client)
        {
            ListBoxItem item = MakeItem(client.AvatarID,
                "------------ " + client.Name + " joined chat ------------");
            chatListBoxMsgs.Items.Add(item);
            ScrollViewer sv = FindVisualChild(chatListBoxMsgs);
            sv.LineDown();
        }

        public void UserLeave(ClientDC client)
        {
            ListBoxItem item = MakeItem(client.AvatarID,
                "------------ " + client.Name + " left chat ------------");
            chatListBoxMsgs.Items.Add(item);
            ScrollViewer sv = FindVisualChild(chatListBoxMsgs);
            sv.LineDown();
        }
        private void xrLabel260_MouseEnter(object sender, MouseEventArgs e)
        {

            tbUsername.Opacity = 0.7;

        }
        private void xrLabel260_MouseLeave(object sender, MouseEventArgs e)
        {

            tbUsername.Opacity = 1;

        }
        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUserName.Text.Length > 0)
                tbUsername.Visibility = Visibility.Collapsed;
            else
                tbUsername.Visibility = Visibility.Visible;
        }

        #region Async

        public IAsyncResult BeginUserLeave(ClientDC client, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserLeave(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserJoin(ClientDC client, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserJoin(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceiverFile(FileMessageDC fileMsg, ClientDC receiver, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceiverFile(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginIsWritingCallback(ClientDC client, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndIsWritingCallback(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceiveWhisper(MessageDC msg, ClientDC receiver, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceiveWhisper(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceive(MessageDC msg, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceive(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshClients(List<ClientDC> clients, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshClients(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void DisconnectClient(ClientDC client)
        {
            if (client.Name.Equals(localClient.Name, StringComparison.InvariantCultureIgnoreCase))
                HandleProxy();
        }

        public IAsyncResult BeginDisconnectClient(ClientDC client, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndDisconnectClient(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion


    }
}
