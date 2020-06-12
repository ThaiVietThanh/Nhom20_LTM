using Login;
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

namespace Client
{
    public partial class Client : MaterialForm
    {
        IPEndPoint IP;
        Socket client;
        public Client()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue800, Primary.Blue500, Accent.LightBlue100, TextShade.WHITE);
            Ketnoi();
            this.Text = "Ứng dụng chat (" + Login.Login.TenDangNhap + ")";
            CheckForIllegalCrossThreadCalls = false;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            Gui();
            AddMessage(Login.Login.TenDangNhap + ": " + txtMessage.Text);
        }
        void Ketnoi()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(IP);
                client.Send(Serialize("@" + Login.Login.TenDangNhap));
            }
            catch
            {
                MessageBox.Show("Không thể kết nối tới server", "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread listen = new Thread(Nhan);
            listen.IsBackground = true;
            listen.Start();
        }
        void Dong()
        {
            client.Close();
        }
        void Gui()
        {
            if (txtMessage.Text != string.Empty)
                client.Send(Serialize(Login.Login.TenDangNhap + ": " + txtMessage.Text));
        }
        void Nhan()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);
                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }

        }
        void AddMessage(string s)
        {
            lwMessageBox.Items.Add(new ListViewItem() { Text = s });
            lwMessageBox.Items[lwMessageBox.Items.Count - 1].EnsureVisible();
            txtMessage.Clear();
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

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dong();
            Application.Exit();
        }
    }
}