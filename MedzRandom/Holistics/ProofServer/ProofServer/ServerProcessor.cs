using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ProofServer
{
    class ServerProcessor
    {
        public delegate void MessageReceivedHandler(string message);
        public event MessageReceivedHandler MessageReceived;

        public void RunServer()
        {
            try
            {
                string ip = "127.0.0.1";
                if (System.Configuration.ConfigurationSettings.AppSettings.Get("IPAddress") != null)
                    ip = System.Configuration.ConfigurationSettings.AppSettings.Get("IPAddress");

                IPAddress ipAd = IPAddress.Parse(ip);
                // use local m/c IP address, and 
                // use the same in the client

                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 8001);

                /* Start Listeneting at the specified port */
                myList.Start();

                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("The server is running at port 8001...");
                    MessageReceived.Invoke("The local End point is  :" + myList.LocalEndpoint);
                    MessageReceived.Invoke("Waiting for a connection.....");
                }

                Socket s = myList.AcceptSocket();
                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Connection accepted from " + s.RemoteEndPoint);
                }

                byte[] b = new byte[100];
                int k = s.Receive(b);
                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Recieved...");
                    string message = "";
                    for (int i = 0; i < k; i++)
                        message += Convert.ToChar(b[i]).ToString();
                    MessageReceived.Invoke(message);
                }


                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes("The string was recieved by the server."));
                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("\nSent Acknowledgement");
                }
                /* clean up */
                s.Close();
                myList.Stop();

            }
            catch (Exception e)
            {
                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Error..... " + e.StackTrace);
                }
            }
        }
    }
}
