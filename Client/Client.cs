using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public Client()
        {
            InitializeComponent();
            Ketnoi();
            CheckForIllegalCrossThreadCalls = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Lab\LTM\Nhom20_LTM\LTM_DangNhap.mdf;Integrated Security=True;";
            conn.Open();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Gui();
            AddMessage(txtMessage.Text);
        }

        IPEndPoint IP;
        Socket client;
        // ket noi
        void Ketnoi()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Loi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                client.Send(Serialize(txtMessage.Text));
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
        }
    }
}
