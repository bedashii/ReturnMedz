using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using HolisticsCommander.Lib;
using HolisticsCommander.Lib.Business;
using HolisticsCommander.Lib.List;

namespace HolisticsCommander
{
    public class ClientProcessor
    {
        public delegate void MessageReceivedHandler(string Message);
        public event MessageReceivedHandler MessageReceived;
        public CommApplicationList CommApplicationsList;
        CommApplication _selectedApplication;
        string _serverIP = null;
        int _serverSocket = 0;
        string[] _serverIPs;

        internal string ServerDetails
        {
            get
            {
                return " [" + _serverIP + ": " + _serverSocket + "]";
            }
        }

        public ClientProcessor()
        {
            RefreshDataSource();
            _serverIPs = System.Configuration.ConfigurationManager.AppSettings.Get("ServerIP").Split(',');

            if (System.Configuration.ConfigurationManager.AppSettings.Get("ServerIP") != null)
                _serverIP = _serverIPs[0];
            else
                _serverIP = "127.0.0.1";

            if (System.Configuration.ConfigurationManager.AppSettings.Get("ServerSocket") != null)
                _serverSocket = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("ServerSocket"));
            else
                _serverSocket = 8001;
        }

        internal void RefreshDataSource()
        {
            CommApplicationsList = new CommApplicationList();
            CommApplicationsList.GetAll();
        }

        internal object CreateNewCommApp()
        {
            _selectedApplication = new CommApplication();
            return _selectedApplication;
        }

        internal void SaveNewCommApp(string name, string path)
        {
            _selectedApplication.Name = name;
            _selectedApplication.Path = path;
            CommApplicationsList.Add(_selectedApplication);
            SaveCommApp();
        }

        internal void SaveCommApp()
        {
            CommApplicationsList.UpdateAll();
        }

        internal void DeleteItem(CommApplication item)
        {
            CommApplicationsList.Delete(item);
        }

        internal void Command_Execute(string message)
        {
            message = "x" + message;
            Command_Send(message);
        }

        internal void Command_Kill(string message)
        {
            message = "k" + message;
            Command_Send(message);
        }

        private void Command_Send(string message)
        {
            try
            {
                TcpClient tcpclient = new TcpClient();
                tcpclient.Connect(_serverIP, _serverSocket);

                Stream stream = tcpclient.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] bytesSend = asen.GetBytes(message);

                stream.Write(bytesSend, 0, bytesSend.Length);

                byte[] bytesRecieved = new byte[100];
                int k = stream.Read(bytesRecieved, 0, 100);

                string receivedMessage = "";

                for (int i = 0; i < k; i++)
                    receivedMessage += Convert.ToChar(bytesRecieved[i]).ToString();

                MessageReceived(receivedMessage);

                stream.Close();
                tcpclient.Close();
            }
            catch (Exception)
            {
                MessageReceived(null);
            }
        }
    }
}
