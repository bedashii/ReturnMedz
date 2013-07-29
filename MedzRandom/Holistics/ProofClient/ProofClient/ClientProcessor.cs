using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ProofClient
{
    class ClientProcessor
    {
        public delegate void MessageReceivedHandler(string message);
        public event MessageReceivedHandler MessageReceived;

        public void SendMessage(string message)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Connecting.....");
                }

                string ip = "127.0.0.1";
                if (System.Configuration.ConfigurationSettings.AppSettings.Get("ServerIP") != null)
                    ip = System.Configuration.ConfigurationSettings.AppSettings.Get("ServerIP");

                tcpclnt.Connect(ip, 8001);
                // use the ipaddress as in the server program

                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Connected");
                    MessageReceived.Invoke("Enter the string to be transmitted : ");
                }

                String str = message;
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Transmitting.....");
                }

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                string responseMsg = "";

                for (int i = 0; i < k; i++)
                    responseMsg += Convert.ToChar(bb[i]).ToString();

                if (MessageReceived != null)
                {
                    MessageReceived.Invoke(responseMsg);
                }

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Error..... " + e.StackTrace);
                }
            }
        }

        public void SendMessage(string ip,string message)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Connecting.....");
                }

                tcpclnt.Connect(ip, 8001);
                // use the ipaddress as in the server program

                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Connected");
                    MessageReceived.Invoke("Enter the string to be transmitted : ");
                }

                String str = message;
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                if (MessageReceived != null)
                {
                    MessageReceived.Invoke("Transmitting.....");
                }

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                string responseMsg = "";

                for (int i = 0; i < k; i++)
                    responseMsg += Convert.ToChar(bb[i]).ToString();

                if (MessageReceived != null)
                {
                    MessageReceived.Invoke(responseMsg);
                }

                tcpclnt.Close();
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