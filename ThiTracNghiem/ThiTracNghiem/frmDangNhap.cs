using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ThiTracNghiem.Truong;

namespace ThiTracNghiem
{
    public partial class frmDangNhap : Form
    {
        SqlConnection con;
        SqlDataAdapter sda;
        DataTable dt;
        SqlCommand cmd;

        public frmDangNhap()
        {
            InitializeComponent();

        }



        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            cbbKhoa.Text = "Khoa Công Nghệ Thông Tin";
            txtDangNhap.Focus();
        }

        void XuLyDangNhap(string username, string pass, string server)
        {


        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            if (cbbKhoa.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn khoa");
                cbbKhoa.Focus();
                return;
            }
            con = Connection.sql(@"DESKTOP-GAP3GBT\SERVERGOCCUAHUY");
            string sql = "select * from TaiKhoan t inner join Nhomtaikhoan n on t.idgroup = n.idgroup where userid = '" + txtDangNhap.Text.Trim() + "' and password='" + txtPw.Text.Trim() + "' ";
            sda = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["idgroup"].ToString().Trim() == "PGV" || dt.Rows[0]["idgroup"].ToString().Trim() == "User")
                {
                    if (cbbKhoa.Text.ToString().Trim() == "Khoa Viễn Thông")
                    {
                        con = Connection.sql(@"DESKTOP-GAP3GBT\COSOCUAHUY2");
                    }
                    else
                    {
                        con = Connection.sql(@"DESKTOP-GAP3GBT\COSOCUAHUY1");
                    }
                }
                else if (dt.Rows[0]["idgroup"].ToString().Trim() == "Khoa_CNTT")
                {

                    con = Connection.sql(@"DESKTOP-GAP3GBT\COSOCUAHUY1");
                }
                else if (dt.Rows[0]["idgroup"].ToString().Trim() == "Khoa_VT")
                {

                    con = Connection.sql(@"DESKTOP-GAP3GBT\COSOCUAHUY2");
                }
                frmMainTruong f = new frmMainTruong(con, dt.Rows[0]["idgroup"].ToString().Trim());
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Thất bại !");
                txtDangNhap.SelectAll();
                txtDangNhap.Focus();
                txtPw.Text = "";
            }


            //string select_username = "SELECT 1 FROM sys.sql_logins WHERE name='" + txtDangNhap.Text + "' AND PWDCOMPARE('" + txtPw.Text + "', password_hash) = 1";

            //SqlCommand cmd = new SqlCommand(select_username, con);

            //int name = Convert.ToInt32(cmd.ExecuteScalar());

            //con.Close();

            //if (name == 1)
            //{
            //    con.Open();

            //    string select_role = "SELECT DP1.name AS DatabaseRoleName FROM sys.database_role_members AS DRM RIGHT OUTER JOIN sys.database_principals AS DP1 ON DRM.role_principal_id = DP1.principal_id LEFT OUTER JOIN sys.database_principals AS DP2  ON DRM.member_principal_id = DP2.principal_id WHERE DP1.type = 'R' and DP2.name = '" + username.Text + "'";
            //    SqlCommand cmd1 = new SqlCommand(select_role, con);
            //    string role = Convert.ToString(cmd1.ExecuteScalar());
            //    if (role.Equals("admin"))
            //    {
            //        frmMainTruong trangchu = new frmMainTruong();
            //        trangchu.Show();
            //        this.Hide();
            //    }
            //    else if (role.Equals("KHOA_CNTT"))
            //    {
            //        CoSo.frmMainGiangVien trangchu = new CoSo.frmMainGiangVien();
            //        trangchu.Show();
            //        this.Hide();
            //    }
            //    else if (role.Equals("KHOA_VT"))
            //    {
            //        CoSo.frmMainSinhVien trangchu = new CoSo.frmMainSinhVien();
            //        trangchu.Show();
            //        this.Hide();
            //    }
            //    con.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Sai thông tin tài khoản, mật khẩu!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void Login_Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //frmDangKy fmainDK = new frmDangKy();
            //fmainDK.Show();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_Button_Click(sender, e);
            }
        }
    }
}
