﻿using Login;
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
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class Client : MaterialForm
    {
        IPEndPoint IP;
        Socket client;
        string sendto = string.Empty;
        Login.Login frmLogin;
        public Client()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue800, Primary.Blue500, Accent.LightBlue100, TextShade.WHITE);
            Ketnoi();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập tin nhắn", "Gửi cho Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                Gui();
        }
        private void btnSendClient_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập tin nhắn", "Gửi cho Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (sendto == string.Empty)
            {
                MessageBox.Show("Chưa chọn Client để gửi", "Gửi cho Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                GuiClient();
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
            System.Threading.Thread.Sleep(100);
            GuiTK();
            this.Text = "Ứng dụng chat (" + Login.Login.TenDangNhap + ")";
        }
        void Dong()
        {
            client.Close();
        }
        void Gui()
        {
            client.Send(Serialize(Login.Login.TenDangNhap + ": " + txtMessage.Text));
            AddMessage(Login.Login.TenDangNhap + ": " + txtMessage.Text);
        }
        void GuiClient()
        {
            client.Send(Serialize(Login.Login.TenDangNhap + ": " + txtMessage.Text + " => " + sendto));
            AddMessage(Login.Login.TenDangNhap + ": " + txtMessage.Text);
        }
        void GuiTK()
        {
            string acc = "account:" + Login.Login.TenDangNhap + "|" + Login.Login.Password;
            client.Send(Serialize(acc));
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
                    if (message.StartsWith("clist:"))
                    {
                        try
                        {
                            if (lwClient.Items.Count != 0)
                            {
                                lwClient.Items.Clear();
                            }
                            string messages = message.Replace("clist:", string.Empty);
                            string[] clientlist = messages.Split('|');
                            foreach (string client in clientlist)
                            {
                                if (client != Login.Login.TenDangNhap)
                                {
                                    AddClient(client);
                                }
                            }
                        }
                        catch
                        {
                            AddMessage(message);
                        }
                    }
                    else if (message.Contains(Login.Login.TenDangNhap))
                    {
                        if (message.Equals(Login.Login.TenDangNhap + " đăng nhập thành công"))
                        {
                            MessageBox.Show("Đăng nhập thành công", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMessage.Enabled = true;
                            btnSend.Enabled = true;
                            btnSendClient.Enabled = true;
                        }
                        else if (message.Equals("Thông tin đăng nhập của " + Login.Login.TenDangNhap + " không đúng"))
                        {
                            MessageBox.Show("Thông tin đăng nhập không đúng", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Dong();
                            Application.Exit();
                        }
                        else
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
                Close();
            }

        }
        void AddMessage(string s)
        {
            lwMessageBox.Items.Add(new ListViewItem() { Text = s });
            lwMessageBox.Items[lwMessageBox.Items.Count - 1].EnsureVisible();
            txtMessage.Clear();
        }
        void AddClient(string s)
        {
            lwClient.Items.Add(new ListViewItem() { Text = s });
            lwClient.Items[lwClient.Items.Count - 1].EnsureVisible();
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
        private void lwClient_Click(object sender, EventArgs e)
        {
            if (lwClient.SelectedItems.Count != 0)
            {
                sendto = lwClient.SelectedItems[0].Text;
                btnSendClient.Text = sendto;
            }
        }
    }
}