using MaterialSkin;
using MaterialSkin.Controls;
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

namespace Login
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        }
        public static string TenDangNhap = "";
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["LTM_DangNhap_Old"].ToString();
            SqlCommand cmd = new SqlCommand("DangNhap", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDN", txtUser.Text);
            cmd.Parameters.AddWithValue("@MatKhau", txtPassword.Text);
            try
            {
                conn.Open();
            }
            catch
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["LTM_DangNhap"].ToString();
                conn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                TenDangNhap = txtUser.Text;
                this.Hide();
                Client.Client logout = new Client.Client();
                logout.Show();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
    }
}