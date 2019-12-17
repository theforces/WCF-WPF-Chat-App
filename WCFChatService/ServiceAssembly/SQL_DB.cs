using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ServiceAssembly
{
    class SQL_DB
    {
        static string connectionString;

        static SqlConnection cnn;
        //cream o variabila de tip DataReader care este folosita sa ia toate datele specificate in SQL query. Apoi putem citi toate randurile unul cate unul din baza de date
        static SqlDataReader dataReader;
        //cream o variabila de tip SqlCommand( aceasta clasa este folosita sa se efectueze operatii de citire si scriere in baza de date) care va fi folosita sa citeasca din baza de date 
        static SqlCommand command, commandID;

        //cream 2 variabile de tip String: sql care este folosita sa retina comanda string de SQL si Output care va contine toate valorile din tabel 
        static String sql;


        static SqlDataAdapter adapter;
        private static string mesaj;
        public static bool Validate(string arguser, string argpass)
        {
            //creare string-ului de conexiune care consta in Data Source=numele serverului pe care se gaseste baza de date, Initial Catalog=e folosit ca sa se specifice numele bazei de date, si eventual username-ul si parola daca este nevoie
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True";

            //Asociem string-ul de conexiune cu variabila cnn, care este de tip SqlConnection si este folosita ca se faca leagtura la baza de date
            cnn = new SqlConnection(connectionString);

            //folosim metoda Open a variabilei cnn pentru a deschide o conexiune catre baza de date
            cnn.Open();

            //Afisam catre utilizator un mesaj cum ca legatura catre baza de date este facuta
            // MessageBox.Show("Connection Open  !");

            if (cnn.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Connection closed!!");
            }


            //trecem la definirea statement-ului SQL care va fi folosit asupra bazei de date. Astfel vom avea la dispozitie toate randurile din tabelul Accounts
            sql = String.Format("Select Username,Password from Accounts WHERE Username=\'{0}\' and Password=\'{1}\'", arguser, argpass);

            //apoi cream obiectul command care este folosit pentru executarea statement-ului SQL asupra bazei de date. Aici trebuie sa dam ca argumente 
            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();


            //acuma ca avem toate randurile trebuie sa le accesam unul cate unul. Pentru asta folosim un while care va lua randurile de la dataReader pe rand. Folosim apoi metoda GetValue ca sa luam valoarea lui Username si Password
            if (dataReader.HasRows)
            {
                return true;
            }
            else
            { return false; }
        }

        public static bool Register(string user, string pass)
        {
            try
            {
                connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                sql = "Insert into Accounts(Username,Password) values('" + user + "','" + pass + "')";

                command = new SqlCommand(sql, cnn);

                adapter = new SqlDataAdapter();

                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }



        }

        public static bool Delete(string user)
        {
            try
            {
                connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                sql = "Delete From Accounts Where Username='" + user + "' ;";

                adapter = new SqlDataAdapter();
                command = new SqlCommand(sql, cnn);

                adapter.DeleteCommand = new SqlCommand(sql, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();


                command.Dispose();
                cnn.Close();
                return true;

            }
            catch (Exception ex)
            {
                mesaj = ex.ToString();
                return false;
                throw;
            }
        }

        public static bool Update(string user, string pass)
        {
            try
            {
                connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                cnn.Open();


                var query = "Select Id from Accounts where Username='" + user + "' ";

                commandID = new SqlCommand(query, cnn);

                dataReader = commandID.ExecuteReader();

                List<int> idList = new List<int>();

                while (dataReader.Read())
                {
                    idList.Add((int)dataReader.GetValue(0));

                }
                dataReader.Close();
                foreach (int item in idList)
                    Debug.WriteLine(item);
             
                cnn.Close();

                cnn.Open();


                sql = "Update Accounts set Username='" + user + "',Password= '" + pass + "' where Id='" + idList[0] + "' ";



                command = new SqlCommand(sql, cnn);

                adapter = new SqlDataAdapter();

                adapter.UpdateCommand = new SqlCommand(sql, cnn);
                adapter.UpdateCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
                return true;
            }

            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}
