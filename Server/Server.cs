using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : MaterialForm
    {
        IPEndPoint IP;
        Socket server;
        List<Socket> clientlist;
        public Server()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepOrange600, Primary.DeepOrange900, Primary.DeepOrange500, Accent.DeepOrange400, TextShade.WHITE);
            MoKetNoi();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                var selecteditem = lwClient.FocusedItem.Index;
                Socket item = clientlist[selecteditem];
                Gui(item);
                AddMessage("Server: " + txtMessage.Text);
                txtMessage.Clear();
            }
            catch
            {
                MessageBox.Show("Chưa chọn Client để gửi", "Gửi cho Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSendAll_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientlist)
            {
                Gui(item);
            }
            AddMessage("Server: " + txtMessage.Text);
            txtMessage.Clear();
        }
        void MoKetNoi()
        {
            clientlist = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
                        Thread receive = new Thread(Nhan);
                        receive.IsBackground = true;
                        receive.Start(client);

                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }
        void Dong()
        {
            server.Close();
        }
        void Gui(Socket client)
        {
            if (txtMessage.Text != string.Empty)
                client.Send(Serialize("Server: " + txtMessage.Text));
        }
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
                        serverClientStatus.Text = "Dang sách client đang kết nối: " + clientlist.Count;
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
                lwClient.Refresh();
                serverClientStatus.Text = "Dang sách client đang kết nối: " + clientlist.Count;
                client.Close();
            }
        }
        void AddMessage(string s)
        {
            lwMessageBox.Items.Add(new ListViewItem() { Text = s });
            lwMessageBox.Items[lwMessageBox.Items.Count - 1].EnsureVisible();

        }
        void AddClient(string clientinfo)
        {
            lwClient.Items.Add(new ListViewItem() { Text = clientinfo });
            lwClient.Items[lwClient.Items.Count - 1].EnsureVisible();
            lwClient.SelectedItems.Clear();
        }
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
        public int disconnect(Socket socket)
        {
            int i = 0;
            foreach (Socket item in clientlist)
            {
                if (item.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                {
                    return i;
                }
                else
                {
                    i = i + 1;
                }
            }
            return i;
        }
        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dong();
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != string.Empty)
            {
                for (int i = lwClient.Items.Count - 1; i >= 0; i--)
                {
                    var item = lwClient.Items[i];
                    if (item.Text.ToLower().Equals(txtTimKiem.Text.ToLower()))
                    {
                        if(lwClient.SelectedItems != null)
                        {
                            lwClient.SelectedItems.Clear();
                        }
                        item.Selected = true;
                        item.Focused = true;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                lwClient.Refresh();
            }
        }
    }
}