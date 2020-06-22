using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
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
        SqlConnection conn = new SqlConnection();
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
            if (txtMessage.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập tin nhắn", "Gửi cho Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lwClient.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chưa chọn Client để gửi", "Gửi cho Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var selecteditem = lwClient.FocusedItem.Index;
                Socket item = clientlist[selecteditem];
                Gui(item);
                AddMessage("Server: " + txtMessage.Text);
                txtMessage.Clear();
            }
        }
        private void btnSendAll_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập tin nhắn", "Gửi cho tất cả Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (Socket item in clientlist)
                {
                    Gui(item);
                }
                AddMessage("Server: " + txtMessage.Text);
                txtMessage.Clear();
            }
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
            client.Send(Serialize("Server: " + txtMessage.Text));
        }
        void GuiDSClient()
        {
            foreach (Socket item in clientlist)
            {
                DSClient(item);
            }
        }
        void ChuyenTin(Socket client, string message)
        {
            client.Send(Serialize(message));
        }
        void Login(string user)
        {
            for (int i = lwClient.Items.Count - 1; i >= 0; i--)
            {
                var item = lwClient.Items[i];
                if (item.Text.Equals(user))
                {
                    if (lwClient.SelectedItems != null)
                    {
                        lwClient.SelectedItems.Clear();
                    }
                    item.Selected = true;
                    item.Focused = true;
                }
            }
            var selecteditem = lwClient.FocusedItem.Index;
            Socket login = clientlist[selecteditem];
            login.Send(Serialize(user + " đăng nhập thành công"));
            lwClient.SelectedItems.Clear();
        }
        void LoginError(string user)
        {
            for (int i = lwClient.Items.Count - 1; i >= 0; i--)
            {
                var item = lwClient.Items[i];
                if (item.Text.Equals(user))
                {
                    if (lwClient.SelectedItems != null)
                    {
                        lwClient.SelectedItems.Clear();
                    }
                    item.Selected = true;
                    item.Focused = true;
                }
            }
            var selecteditem = lwClient.FocusedItem.Index;
            Socket login = clientlist[selecteditem];
            login.Send(Serialize("Thông tin đăng nhập của " + user + " không đúng"));
            lwClient.SelectedItems.Clear();
        }
        void ChuyenTinNhan(string message, string user)
        {
            for (int i = lwClient.Items.Count - 1; i >= 0; i--)
            {
                var item = lwClient.Items[i];
                if (item.Text.Equals(user))
                {
                    if (lwClient.SelectedItems != null)
                    {
                        lwClient.SelectedItems.Clear();
                    }
                    item.Selected = true;
                    item.Focused = true;
                }
            }
            var selecteditem = lwClient.FocusedItem.Index;
            Socket sendto = clientlist[selecteditem];
            ChuyenTin(sendto, message);
            lwClient.SelectedItems.Clear();
        }
        void DSClient(Socket client)
        {
            List<string> ds = new List<string>();
            if (ds != null)
            {
                ds = new List<string>();
            }
            foreach (ListViewItem item in lwClient.Items)
            {
                ds.Add(item.Text);
            }
            string clist = String.Join("|", ds.ToArray());
            client.Send(Serialize("clist:" + clist));
        }
        void Nhan(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    GuiDSClient();
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    if (message.Contains("@"))
                    {
                        string name = message.Trim('@');
                        AddClient(name);
                        serverClientStatus.Text = "Dang sách client đang kết nối: " + clientlist.Count;
                    }
                    else if (message.Contains("=>"))
                    {
                        try
                        {
                            string[] info = message.Split(new string[] { " => " }, StringSplitOptions.None);
                            ChuyenTinNhan(info[0], info[1]);
                        }
                        catch
                        {
                            AddMessage(message);
                        }

                    }
                    else if (message.Contains("account:"))
                    {
                        try
                        {
                            string messages = message.Replace("account:", string.Empty);
                            string[] acc = messages.Split('|');
                            XacThuc(acc[0], acc[1]);
                        }
                        catch
                        {
                            AddMessage(message);
                        }
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
                GuiDSClient();
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
            if (rdSearchIndex.Checked == true)
            {
                if (txtTimKiem.Text != string.Empty)
                {
                    int i = Int16.Parse(txtTimKiem.Text) - 1;
                    try
                    {
                        var item = lwClient.Items[i];
                        if (lwClient.SelectedItems != null)
                        {
                            lwClient.SelectedItems.Clear();
                        }
                        item.Selected = true;
                        item.Focused = true;
                    }
                    catch
                    {
                        MessageBox.Show("Số thứ tự tìm kiếm không được phép lớn hơn số Client đang kết nối", "Tìm kiếm theo số thứ tự", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            else if (rdSearchName.Checked == true)
            {
                if (txtTimKiem.Text != string.Empty)
                {
                    for (int i = lwClient.Items.Count - 1; i >= 0; i--)
                    {
                        var item = lwClient.Items[i];
                        if (item.Text.ToLower().Equals(txtTimKiem.Text.ToLower()))
                        {
                            if (lwClient.SelectedItems != null)
                            {
                                lwClient.SelectedItems.Clear();
                            }
                            item.Selected = true;
                            item.Focused = true;
                        }
                        else if (item.Text.ToLower().Contains(txtTimKiem.Text))
                        {
                            item.BackColor = Color.White;
                            item.ForeColor = Color.Black;
                        }
                        else
                        {
                            item.BackColor = Color.FromArgb(255, 51, 51, 51);
                            item.ForeColor = Color.White;
                            if (lwClient.SelectedItems != null)
                            {
                                lwClient.SelectedItems.Clear();
                            }
                        }
                    }
                }
                else
                {
                }
            }
        }
        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdSearchIndex.Checked == true)
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = !char.IsNumber(e.KeyChar);
                }
            }
            else if (rdSearchName.Checked == true)
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = !char.IsLetterOrDigit(e.KeyChar);
                }
            }
        }
        private void rdSearchIndex_CheckedChanged(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.Hint = "Tìm kiếm theo số thứ tự";
        }
        private void rdSearchName_CheckedChanged(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.Hint = "Tìm kiếm theo tên";
        }
        public void XacThuc(string Username, string Password)
        {
            if (Username != string.Empty && Password != string.Empty)
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["LTM_DangNhap"].ToString();
                conn.Open();
                SqlCommand cmd = new SqlCommand("DangNhap", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TenDN", Username);
                cmd.Parameters.AddWithValue("@MatKhau", Password);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Login(Username);
                }
                else
                {
                    LoginError(Username);
                }
                conn.Close();
            }
        }
    }
}