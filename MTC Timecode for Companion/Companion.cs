using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace MTC_Timecode_for_Companion
{
    class Companion
    {
        private string ip = "127.0.0.1";
        private int port = 51235;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public void PushButton(int page, int bank)
        {
            
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                try
                {
                    string message = ("BANK-PRESS " + page.ToString() + " " + bank.ToString());

                    byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes(message);

                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);


                    client.SendTo(packetData, ep);

                    Console.WriteLine("Pressing button " + page + "-" + bank);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error sending UDP packet to companion");
                    Console.WriteLine(e);
                }


        }











        //
        //TCP ISSUE
        //
        //Companion gets connection, but no message. Works with stand alone TCP viewer
        private void SendTCP(string message)        
        {
            //---data to send to the server---
            string textToSend = message;

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(ip, port);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            Console.WriteLine("Sending : " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            

            //---read back the text---
            /*byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            Console.ReadLine();*/
            client.Close();
        }

      
    }
}
