﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFClient.SVC {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Client", Namespace="http://schemas.datacontract.org/2004/07/ServiceAssembly")]
    [System.SerializableAttribute()]
    public partial class Client : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AvatarIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AvatarID {
            get {
                return this.AvatarIDField;
            }
            set {
                if ((this.AvatarIDField.Equals(value) != true)) {
                    this.AvatarIDField = value;
                    this.RaisePropertyChanged("AvatarID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/ServiceAssembly")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sender {
            get {
                return this.SenderField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderField, value) != true)) {
                    this.SenderField = value;
                    this.RaisePropertyChanged("Sender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FileMessage", Namespace="http://schemas.datacontract.org/2004/07/ServiceAssembly")]
    [System.SerializableAttribute()]
    public partial class FileMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FileNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileName {
            get {
                return this.FileNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FileNameField, value) != true)) {
                    this.FileNameField = value;
                    this.RaisePropertyChanged("FileName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sender {
            get {
                return this.SenderField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderField, value) != true)) {
                    this.SenderField = value;
                    this.RaisePropertyChanged("Sender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SVC.IChat", CallbackContract=typeof(WPFClient.SVC.IChatCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IChat {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/Connect", ReplyAction="http://tempuri.org/IChat/ConnectResponse")]
        bool Connect(WPFClient.SVC.Client client);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IChat/Connect", ReplyAction="http://tempuri.org/IChat/ConnectResponse")]
        System.IAsyncResult BeginConnect(WPFClient.SVC.Client client, System.AsyncCallback callback, object asyncState);
        
        bool EndConnect(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IChat/Say")]
        void Say(WPFClient.SVC.Message msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IChat/Say")]
        System.IAsyncResult BeginSay(WPFClient.SVC.Message msg, System.AsyncCallback callback, object asyncState);
        
        void EndSay(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IChat/Whisper")]
        void Whisper(WPFClient.SVC.Message msg, WPFClient.SVC.Client receiver);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IChat/Whisper")]
        System.IAsyncResult BeginWhisper(WPFClient.SVC.Message msg, WPFClient.SVC.Client receiver, System.AsyncCallback callback, object asyncState);
        
        void EndWhisper(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IChat/IsWriting")]
        void IsWriting(WPFClient.SVC.Client client);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IChat/IsWriting")]
        System.IAsyncResult BeginIsWriting(WPFClient.SVC.Client client, System.AsyncCallback callback, object asyncState);
        
        void EndIsWriting(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/SendFile", ReplyAction="http://tempuri.org/IChat/SendFileResponse")]
        bool SendFile(WPFClient.SVC.FileMessage fileMsg, WPFClient.SVC.Client receiver);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IChat/SendFile", ReplyAction="http://tempuri.org/IChat/SendFileResponse")]
        System.IAsyncResult BeginSendFile(WPFClient.SVC.FileMessage fileMsg, WPFClient.SVC.Client receiver, System.AsyncCallback callback, object asyncState);
        
        bool EndSendFile(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IChat/Disconnect")]
        void Disconnect(WPFClient.SVC.Client client);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IChat/Disconnect")]
        System.IAsyncResult BeginDisconnect(WPFClient.SVC.Client client, System.AsyncCallback callback, object asyncState);
        
        void EndDisconnect(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IChatCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/RefreshClients")]
        void RefreshClients(System.Collections.Generic.List<WPFClient.SVC.Client> clients);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IChat/RefreshClients")]
        System.IAsyncResult BeginRefreshClients(System.Collections.Generic.List<WPFClient.SVC.Client> clients, System.AsyncCallback callback, object asyncState);
        
        void EndRefreshClients(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Receive")]
        void Receive(WPFClient.SVC.Message msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IChat/Receive")]
        System.IAsyncResult BeginReceive(WPFClient.SVC.Message msg, System.AsyncCallback callback, object asyncState);
        
        void EndReceive(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiveWhisper")]
        void ReceiveWhisper(WPFClient.SVC.Message msg, WPFClient.SVC.Client receiver);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IChat/ReceiveWhisper")]
        System.IAsyncResult BeginReceiveWhisper(WPFClient.SVC.Message msg, WPFClient.SVC.Client receiver, System.AsyncCallback callback, object asyncState);
        
        void EndReceiveWhisper(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/IsWritingCallback")]
        void IsWritingCallback(WPFClient.SVC.Client client);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IChat/IsWritingCallback")]
        System.IAsyncResult BeginIsWritingCallback(WPFClient.SVC.Client client, System.AsyncCallback callback, object asyncState);
        
        void EndIsWritingCallback(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiverFile")]
        void ReceiverFile(WPFClient.SVC.FileMessage fileMsg, WPFClient.SVC.Client receiver);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IChat/ReceiverFile")]
        System.IAsyncResult BeginReceiverFile(WPFClient.SVC.FileMessage fileMsg, WPFClient.SVC.Client receiver, System.AsyncCallback callback, object asyncState);
        
        void EndReceiverFile(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/UserJoin")]
        void UserJoin(WPFClient.SVC.Client client);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IChat/UserJoin")]
        System.IAsyncResult BeginUserJoin(WPFClient.SVC.Client client, System.AsyncCallback callback, object asyncState);
        
        void EndUserJoin(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/UserLeave")]
        void UserLeave(WPFClient.SVC.Client client);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IChat/UserLeave")]
        System.IAsyncResult BeginUserLeave(WPFClient.SVC.Client client, System.AsyncCallback callback, object asyncState);
        
        void EndUserLeave(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IChatChannel : WPFClient.SVC.IChat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ConnectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ConnectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SendFileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SendFileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ChatClient : System.ServiceModel.DuplexClientBase<WPFClient.SVC.IChat>, WPFClient.SVC.IChat {
        
        private BeginOperationDelegate onBeginConnectDelegate;
        
        private EndOperationDelegate onEndConnectDelegate;
        
        private System.Threading.SendOrPostCallback onConnectCompletedDelegate;
        
        private BeginOperationDelegate onBeginSayDelegate;
        
        private EndOperationDelegate onEndSayDelegate;
        
        private System.Threading.SendOrPostCallback onSayCompletedDelegate;
        
        private BeginOperationDelegate onBeginWhisperDelegate;
        
        private EndOperationDelegate onEndWhisperDelegate;
        
        private System.Threading.SendOrPostCallback onWhisperCompletedDelegate;
        
        private BeginOperationDelegate onBeginIsWritingDelegate;
        
        private EndOperationDelegate onEndIsWritingDelegate;
        
        private System.Threading.SendOrPostCallback onIsWritingCompletedDelegate;
        
        private BeginOperationDelegate onBeginSendFileDelegate;
        
        private EndOperationDelegate onEndSendFileDelegate;
        
        private System.Threading.SendOrPostCallback onSendFileCompletedDelegate;
        
        private BeginOperationDelegate onBeginDisconnectDelegate;
        
        private EndOperationDelegate onEndDisconnectDelegate;
        
        private System.Threading.SendOrPostCallback onDisconnectCompletedDelegate;
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public event System.EventHandler<ConnectCompletedEventArgs> ConnectCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SayCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> WhisperCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> IsWritingCompleted;
        
        public event System.EventHandler<SendFileCompletedEventArgs> SendFileCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DisconnectCompleted;
        
        public bool Connect(WPFClient.SVC.Client client) {
            return base.Channel.Connect(client);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginConnect(WPFClient.SVC.Client client, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginConnect(client, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndConnect(System.IAsyncResult result) {
            return base.Channel.EndConnect(result);
        }
        
        private System.IAsyncResult OnBeginConnect(object[] inValues, System.AsyncCallback callback, object asyncState) {
            WPFClient.SVC.Client client = ((WPFClient.SVC.Client)(inValues[0]));
            return this.BeginConnect(client, callback, asyncState);
        }
        
        private object[] OnEndConnect(System.IAsyncResult result) {
            bool retVal = this.EndConnect(result);
            return new object[] {
                    retVal};
        }
        
        private void OnConnectCompleted(object state) {
            if ((this.ConnectCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ConnectCompleted(this, new ConnectCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ConnectAsync(WPFClient.SVC.Client client) {
            this.ConnectAsync(client, null);
        }
        
        public void ConnectAsync(WPFClient.SVC.Client client, object userState) {
            if ((this.onBeginConnectDelegate == null)) {
                this.onBeginConnectDelegate = new BeginOperationDelegate(this.OnBeginConnect);
            }
            if ((this.onEndConnectDelegate == null)) {
                this.onEndConnectDelegate = new EndOperationDelegate(this.OnEndConnect);
            }
            if ((this.onConnectCompletedDelegate == null)) {
                this.onConnectCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnConnectCompleted);
            }
            base.InvokeAsync(this.onBeginConnectDelegate, new object[] {
                        client}, this.onEndConnectDelegate, this.onConnectCompletedDelegate, userState);
        }
        
        public void Say(WPFClient.SVC.Message msg) {
            base.Channel.Say(msg);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSay(WPFClient.SVC.Message msg, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSay(msg, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndSay(System.IAsyncResult result) {
            base.Channel.EndSay(result);
        }
        
        private System.IAsyncResult OnBeginSay(object[] inValues, System.AsyncCallback callback, object asyncState) {
            WPFClient.SVC.Message msg = ((WPFClient.SVC.Message)(inValues[0]));
            return this.BeginSay(msg, callback, asyncState);
        }
        
        private object[] OnEndSay(System.IAsyncResult result) {
            this.EndSay(result);
            return null;
        }
        
        private void OnSayCompleted(object state) {
            if ((this.SayCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SayCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SayAsync(WPFClient.SVC.Message msg) {
            this.SayAsync(msg, null);
        }
        
        public void SayAsync(WPFClient.SVC.Message msg, object userState) {
            if ((this.onBeginSayDelegate == null)) {
                this.onBeginSayDelegate = new BeginOperationDelegate(this.OnBeginSay);
            }
            if ((this.onEndSayDelegate == null)) {
                this.onEndSayDelegate = new EndOperationDelegate(this.OnEndSay);
            }
            if ((this.onSayCompletedDelegate == null)) {
                this.onSayCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSayCompleted);
            }
            base.InvokeAsync(this.onBeginSayDelegate, new object[] {
                        msg}, this.onEndSayDelegate, this.onSayCompletedDelegate, userState);
        }
        
        public void Whisper(WPFClient.SVC.Message msg, WPFClient.SVC.Client receiver) {
            base.Channel.Whisper(msg, receiver);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginWhisper(WPFClient.SVC.Message msg, WPFClient.SVC.Client receiver, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginWhisper(msg, receiver, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndWhisper(System.IAsyncResult result) {
            base.Channel.EndWhisper(result);
        }
        
        private System.IAsyncResult OnBeginWhisper(object[] inValues, System.AsyncCallback callback, object asyncState) {
            WPFClient.SVC.Message msg = ((WPFClient.SVC.Message)(inValues[0]));
            WPFClient.SVC.Client receiver = ((WPFClient.SVC.Client)(inValues[1]));
            return this.BeginWhisper(msg, receiver, callback, asyncState);
        }
        
        private object[] OnEndWhisper(System.IAsyncResult result) {
            this.EndWhisper(result);
            return null;
        }
        
        private void OnWhisperCompleted(object state) {
            if ((this.WhisperCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.WhisperCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void WhisperAsync(WPFClient.SVC.Message msg, WPFClient.SVC.Client receiver) {
            this.WhisperAsync(msg, receiver, null);
        }
        
        public void WhisperAsync(WPFClient.SVC.Message msg, WPFClient.SVC.Client receiver, object userState) {
            if ((this.onBeginWhisperDelegate == null)) {
                this.onBeginWhisperDelegate = new BeginOperationDelegate(this.OnBeginWhisper);
            }
            if ((this.onEndWhisperDelegate == null)) {
                this.onEndWhisperDelegate = new EndOperationDelegate(this.OnEndWhisper);
            }
            if ((this.onWhisperCompletedDelegate == null)) {
                this.onWhisperCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnWhisperCompleted);
            }
            base.InvokeAsync(this.onBeginWhisperDelegate, new object[] {
                        msg,
                        receiver}, this.onEndWhisperDelegate, this.onWhisperCompletedDelegate, userState);
        }
        
        public void IsWriting(WPFClient.SVC.Client client) {
            base.Channel.IsWriting(client);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginIsWriting(WPFClient.SVC.Client client, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginIsWriting(client, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndIsWriting(System.IAsyncResult result) {
            base.Channel.EndIsWriting(result);
        }
        
        private System.IAsyncResult OnBeginIsWriting(object[] inValues, System.AsyncCallback callback, object asyncState) {
            WPFClient.SVC.Client client = ((WPFClient.SVC.Client)(inValues[0]));
            return this.BeginIsWriting(client, callback, asyncState);
        }
        
        private object[] OnEndIsWriting(System.IAsyncResult result) {
            this.EndIsWriting(result);
            return null;
        }
        
        private void OnIsWritingCompleted(object state) {
            if ((this.IsWritingCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.IsWritingCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void IsWritingAsync(WPFClient.SVC.Client client) {
            this.IsWritingAsync(client, null);
        }
        
        public void IsWritingAsync(WPFClient.SVC.Client client, object userState) {
            if ((this.onBeginIsWritingDelegate == null)) {
                this.onBeginIsWritingDelegate = new BeginOperationDelegate(this.OnBeginIsWriting);
            }
            if ((this.onEndIsWritingDelegate == null)) {
                this.onEndIsWritingDelegate = new EndOperationDelegate(this.OnEndIsWriting);
            }
            if ((this.onIsWritingCompletedDelegate == null)) {
                this.onIsWritingCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnIsWritingCompleted);
            }
            base.InvokeAsync(this.onBeginIsWritingDelegate, new object[] {
                        client}, this.onEndIsWritingDelegate, this.onIsWritingCompletedDelegate, userState);
        }
        
        public bool SendFile(WPFClient.SVC.FileMessage fileMsg, WPFClient.SVC.Client receiver) {
            return base.Channel.SendFile(fileMsg, receiver);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSendFile(WPFClient.SVC.FileMessage fileMsg, WPFClient.SVC.Client receiver, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSendFile(fileMsg, receiver, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndSendFile(System.IAsyncResult result) {
            return base.Channel.EndSendFile(result);
        }
        
        private System.IAsyncResult OnBeginSendFile(object[] inValues, System.AsyncCallback callback, object asyncState) {
            WPFClient.SVC.FileMessage fileMsg = ((WPFClient.SVC.FileMessage)(inValues[0]));
            WPFClient.SVC.Client receiver = ((WPFClient.SVC.Client)(inValues[1]));
            return this.BeginSendFile(fileMsg, receiver, callback, asyncState);
        }
        
        private object[] OnEndSendFile(System.IAsyncResult result) {
            bool retVal = this.EndSendFile(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSendFileCompleted(object state) {
            if ((this.SendFileCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SendFileCompleted(this, new SendFileCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SendFileAsync(WPFClient.SVC.FileMessage fileMsg, WPFClient.SVC.Client receiver) {
            this.SendFileAsync(fileMsg, receiver, null);
        }
        
        public void SendFileAsync(WPFClient.SVC.FileMessage fileMsg, WPFClient.SVC.Client receiver, object userState) {
            if ((this.onBeginSendFileDelegate == null)) {
                this.onBeginSendFileDelegate = new BeginOperationDelegate(this.OnBeginSendFile);
            }
            if ((this.onEndSendFileDelegate == null)) {
                this.onEndSendFileDelegate = new EndOperationDelegate(this.OnEndSendFile);
            }
            if ((this.onSendFileCompletedDelegate == null)) {
                this.onSendFileCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendFileCompleted);
            }
            base.InvokeAsync(this.onBeginSendFileDelegate, new object[] {
                        fileMsg,
                        receiver}, this.onEndSendFileDelegate, this.onSendFileCompletedDelegate, userState);
        }
        
        public void Disconnect(WPFClient.SVC.Client client) {
            base.Channel.Disconnect(client);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDisconnect(WPFClient.SVC.Client client, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDisconnect(client, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndDisconnect(System.IAsyncResult result) {
            base.Channel.EndDisconnect(result);
        }
        
        private System.IAsyncResult OnBeginDisconnect(object[] inValues, System.AsyncCallback callback, object asyncState) {
            WPFClient.SVC.Client client = ((WPFClient.SVC.Client)(inValues[0]));
            return this.BeginDisconnect(client, callback, asyncState);
        }
        
        private object[] OnEndDisconnect(System.IAsyncResult result) {
            this.EndDisconnect(result);
            return null;
        }
        
        private void OnDisconnectCompleted(object state) {
            if ((this.DisconnectCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DisconnectCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DisconnectAsync(WPFClient.SVC.Client client) {
            this.DisconnectAsync(client, null);
        }
        
        public void DisconnectAsync(WPFClient.SVC.Client client, object userState) {
            if ((this.onBeginDisconnectDelegate == null)) {
                this.onBeginDisconnectDelegate = new BeginOperationDelegate(this.OnBeginDisconnect);
            }
            if ((this.onEndDisconnectDelegate == null)) {
                this.onEndDisconnectDelegate = new EndOperationDelegate(this.OnEndDisconnect);
            }
            if ((this.onDisconnectCompletedDelegate == null)) {
                this.onDisconnectCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDisconnectCompleted);
            }
            base.InvokeAsync(this.onBeginDisconnectDelegate, new object[] {
                        client}, this.onEndDisconnectDelegate, this.onDisconnectCompletedDelegate, userState);
        }
    }
}
