using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            Ketnoi();
            CheckForIllegalCrossThreadCalls = false;

        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dong();
        }

        // gui tin cho tat ca client
        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientlist)
            {
                Gui(item);
            }
            AddMessage("Server: " + txtMessage.Text);
            txtMessage.Clear();
        }

        IPEndPoint IP;
        Socket server;
        List<Socket> clientlist;
        // ket noi
        void Ketnoi()
        {
            clientlist = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            server.Bind(IP);
            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientlist.Add(client);
                        //AddClient(client.RemoteEndPoint.ToString());
                        Thread receive = new Thread(Nhan);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }
        // dong ket noi
        void Dong()
        {
            server.Close();
        }
        // gui tin
        void Gui(Socket client)
        {
            if (txtMessage.Text != string.Empty)
                client.Send(Serialize("Server: " + txtMessage.Text));
        }
        // nhan tin
        void Nhan(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    if (message.Contains("@"))
                    {
                        string name = message.Trim('@');
                        AddClient(name);
                    }
                    else
                    {
                        AddMessage(message);
                    }
                }
            }
            catch
            {
                clientlist.Remove(client);
                lwClient.Items.RemoveAt(disconnect(client));
                client.Close();
            } 
        }

        void AddMessage(string s)
        {
            lwMessageBox.Items.Add(new ListViewItem() { Text = s });
        }
        // phan manh

        void AddClient(string clientinfo)
        {
            lwClient.Items.Add(new ListViewItem() { Text = clientinfo });
        }

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
        // gom manh
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
        // ngat ket noi
        public int disconnect(Socket socket)
        {
            int i = 0;
            foreach(Socket item in clientlist)
            {
                if(item.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                {
                    return i;
                }
                else
                {
                    i=i+1;
                }
            }
            return i;
        }
    }
}
