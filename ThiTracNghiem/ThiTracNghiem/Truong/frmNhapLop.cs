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

namespace ThiTracNghiem.Truong
{
    public partial class frmNhapLop : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
             command = conn.CreateCommand();
             command.CommandText = "SELECT makhoa,malop,tenlop FROM Lop ";
             adapter.SelectCommand = command;
             table.Clear();
             adapter.Fill(table);
             dgvL.DataSource = table;
             dgvL.Refresh();
        }

        public DataTable LoadDataKhoa(string sql)
        {
            DataTable dt = new DataTable();
            //Conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }

        public frmNhapLop(SqlConnection servername)
        {
            InitializeComponent();
            this.conn = servername;
            conn = new SqlConnection(Program.constr);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(txtMaLop.Text.Trim()=="")
            {
                MessageBox.Show("Vui lòng nhập mã lớp");
                txtMaLop.Focus();
                return;
            }
            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên lớp");
                txtTenLop.Focus();
                return;
            }
            try
            {
                /// Them
                conn.Open();
                command = new SqlCommand("insert into Lop (malop,tenlop,makhoa) values ('" + txtMaLop.Text + "','" + txtTenLop.Text + "','" + cbMaKhoa.Text + "')", conn);
                command.ExecuteNonQuery();
                loadData();
              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lớp này đã tồn tại. Không thêm mới được");
                return;

            }
            finally
            {
                conn.Close();
            }
        }

        private void DgvL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtMaLop.Enabled = false;
            //int i;
            //i = dgvL.CurrentRow.Index;
            //txtMaLop.Text = dgvL.Rows[i].Cells["malop"].Value.ToString();
            //txtTenLop.Text = dgvL.Rows[i].Cells["tenlop"].Value.ToString();
            //cbMaKhoa.Text = dgvL.Rows[i].Cells["makhoa"].Value.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo"
                              , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                /// xoa
                conn.Open();
                command = conn.CreateCommand();
                command.CommandText = "delete from Lop where malop = '" + txtMaLop.Text + "'";
                command.ExecuteNonQuery();
                loadData();
                conn.Close();
            }
            else
            {
                return;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            /// hieu chinh
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = "update Lop set TenLop = '" + txtTenLop.Text + "' where malop = '" + txtMaLop.Text + "' and makhoa = '" + cbMaKhoa.Text + "'";
            command.ExecuteNonQuery();
            loadData();
            conn.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            /// Ghi, lam moi
            txtMaLop.Enabled = true;
            txtMaLop.Focus();
            txtMaLop.Text = "";
            txtTenLop.Text = "";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn đóng không?", "Thông báo"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
        public DataTable TimKiemLop(string TimKiemL)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand _cmd = new SqlCommand("sp_TimLop", conn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("TenLop", SqlDbType.NVarChar)).Value = TimKiemL;
            SqlDataAdapter sda = new SqlDataAdapter(_cmd);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (txtTKL.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập thông tin !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtTKL.Focus();
            }
            else
            {
                table = new DataTable();
                table = TimKiemLop(txtTKL.Text.Trim());
                if (table.Rows.Count > 0)
                {
                    dgvL.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    FrmNhapLop_Load(null, null); // load dữ liệu lại 
                    txtTKL.Text = "";
                }
            }
        }

        private void FrmNhapLop_Load(object sender, EventArgs e)
        {
            loadData();
            string sql1 = "select * from Khoa";
            cbMaKhoa.DataSource = LoadDataKhoa(sql1);
            cbMaKhoa.DisplayMember = "makhoa";
            cbMaKhoa.ValueMember = "makhoa";
        }

        private void TxtMaKhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLop.Enabled = false;
            //int i;
            //i = dgvL.CurrentRow.Index;
            //txtMaLop.Text = dgvL.Rows[i].Cells["malop"].Value.ToString();
            //txtTenLop.Text = dgvL.Rows[i].Cells["tenlop"].Value.ToString();
            //cbMaKhoa.Text = dgvL.Rows[i].Cells["makhoa"].Value.ToString();
            txtMaLop.Text = dgvL.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenLop.Text = dgvL.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbMaKhoa.Text = dgvL.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
