using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            
            InitializeComponent();           
        }

        public static string TenDangNhap = "";
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["userinfo"].ToString();
            SqlCommand cmd = new SqlCommand("DangNhap", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDN", txtUser.Text);
            cmd.Parameters.AddWithValue("@MatKhau", txtPassword.Text);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                TenDangNhap = txtUser.Text;
                this.Hide();
                Client formClient = new Client();
                formClient.Show();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
    }
}
