using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class Client : Form
    {
        IPEndPoint IP;
        Socket client;
        public Client()
        {
            InitializeComponent();
            menuStripuser.Text = "Đã đăng nhập (" + DangNhap.TenDangNhap + ")";
            Ketnoi();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Gui();
            AddMessage(DangNhap.TenDangNhap + ": " + txtMessage.Text);
        }


        // ket noi
        void Ketnoi()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(IP);
                client.Send(Serialize("@" + DangNhap.TenDangNhap));
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
        // dong ket noi
        void Dong()
        {
            client.Close();
        }
        // gui tin
        void Gui()
        {
            if (txtMessage.Text != string.Empty)
                client.Send(Serialize(DangNhap.TenDangNhap + ": " + txtMessage.Text));
        }
        // nhan tin
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
            txtMessage.Clear();
        }
        // phan manh

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

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dong();
            Application.Exit();
        }

        private void menuScript1dangxuat_Click(object sender, EventArgs e)
        {
            Dong();
            this.Hide();
            DangNhap logout = new DangNhap();
            logout.Show();
            
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dong();
            Application.Exit();
        }
    }
}
