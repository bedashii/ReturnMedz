using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HolisticsCommander
{
    public class ServerProcessor
    {
        public delegate void MessageReceivedHandler(string message);
        public event MessageReceivedHandler MessageReceived;

        string _serverIP = null;
        int _serverSocket = 0;

        public ServerProcessor()
        {

        }

        public void Initialize()
        {
            if (System.Configuration.ConfigurationManager.AppSettings.Get("ServerIP") != null)
                _serverIP = System.Configuration.ConfigurationManager.AppSettings.Get("ServerIP");
            else
                _serverIP = "127.0.0.1";

            if (System.Configuration.ConfigurationManager.AppSettings.Get("ServerSocket") != null)
                _serverSocket = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("ServerSocket"));
            else
                _serverSocket = 8001;

            RunServer();
        }

        public void RunServer()
        {
            try
            {
                TcpListener tcpListener = new TcpListener(IPAddress.Parse(_serverIP), _serverSocket);
                tcpListener.Start();

                MessageReceived("The server is running at port " + _serverSocket);
                MessageReceived("The local End point is  :" + tcpListener.LocalEndpoint);
                MessageReceived("Waiting for a connection.....\n");

                Socket socket = tcpListener.AcceptSocket();

                MessageReceived("Connection accepted from " + socket.RemoteEndPoint);

                byte[] b = new byte[100];
                int k = socket.Receive(b);

                string message = "";

                for (int i = 0; i < k; i++)
                    message += Convert.ToChar(b[i]).ToString();

                bool commandSuccesful = Command_Run(message);
                MessageReceived("Command " + (commandSuccesful ? "Succesful" : "Unsuccessful"));

                ASCIIEncoding asen = new ASCIIEncoding();
                socket.Send(asen.GetBytes(commandSuccesful.ToString()));

                socket.Close();
                tcpListener.Stop();
            }
            catch (Exception x)
            {
                MessageReceived("Err: " + x.ToString());
            }
        }

        private bool Command_Run(string message)
        {
            try
            {
                if (message.Substring(0, 1) == "k")
                {
                    return Command_Kill(message.Substring(1, message.Length - 1));
                }
                else if (message.Substring(0, 1) == "x")
                {
                    return Command_Execute(message.Substring(1, message.Length - 1));
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool Command_Kill(string message)
        {
            MessageReceived("About to kill " + message);

            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcesses())
                if (process.ProcessName == message)
                {
                    process.Kill();
                    return true;
                }

            return false;
        }

        private bool Command_Execute(string message)
        {
            MessageReceived("About to execute " + message);
            Process.Start(message);
            return true;
        }
    }
}
