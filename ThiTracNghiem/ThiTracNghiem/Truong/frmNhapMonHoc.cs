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
    public partial class frmNhapMonHoc : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        string ma = "";
        void loadData()
        {
            string sql = "";
            if (ma.Contains("VT"))
                sql = "select mamh,tenmh from Monhoc where mamh like 'VT%'";
            else
                sql = "select mamh,tenmh from Monhoc where mamh not like 'VT%'";

            command = conn.CreateCommand();
            command.CommandText = sql;
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvMH.DataSource = table;
            dgvMH.Refresh();
        }
        public frmNhapMonHoc(SqlConnection servername, string ma)
        {
            InitializeComponent();
            this.conn = servername;
            this.ma = ma;
            string sql = "";
            if (ma.Contains("VT"))
                sql = "select mamh,tenmh from Monhoc where mamh like 'VT%'";
            else
                sql = "select mamh,tenmh from Monhoc where mamh not like 'VT%'";
            conn = new SqlConnection(Program.constr);
            conn.Open();
            dgvMH.DataSource = sql;
            conn.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtMaMon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã MH");
                txtMaMon.Focus();
                return;
            }
            if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên MH");
                txtTenMH.Focus();
                return;
            }
            try
            {
                /// Them
                conn.Open();
                command = new SqlCommand("insert into MonHoc (MaMH,TenMH) values ('" + txtMaMon.Text + "','" + txtTenMH.Text + "')", conn);
                command.ExecuteNonQuery();
                loadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Mã môn này đã tồn tại. Không thêm mới được");
                return;

            }
            finally
            {
                conn.Close();
            }
        }

        private void DgvMH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ////txtMaMH.ReadOnly = true;
            //txtMaMon.Enabled = false;
            //int i;
            //i = dgvMH.CurrentRow.Index;
            //txtMaMon.Text = dgvMH.Rows[i].Cells[0].Value.ToString();
            //txtTenMH.Text = dgvMH.Rows[i].Cells[1].Value.ToString();
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
                command.CommandText = "delete from MonHoc where MaMH = '" + txtMaMon.Text + "'";
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
            command.CommandText = "update MonHoc set TenMH = N'" + txtTenMH.Text +"' where MaMH = '" + txtMaMon.Text + "'";
            command.ExecuteNonQuery();
            loadData();
            conn.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            /// Ghi, lam moi
            txtMaMon.Enabled = true;
            txtMaMon.Focus();
            txtMaMon.Text = "";
            txtTenMH.Text = "";
        }

        private void Button4_Click(object sender, EventArgs e)
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
        // tim kiem mon hoc
        public DataTable TimKiemMonHoc(string TimKiemMH)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand _cmd = new SqlCommand("sp_TimMon", conn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("tenmh", SqlDbType.NVarChar)).Value = TimKiemMH;
            SqlDataAdapter sda = new SqlDataAdapter(_cmd);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            if (txtTKMH.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập thông tin !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                table = new DataTable();
                table = TimKiemMonHoc(txtTKMH.Text.Trim());
                if (table.Rows.Count > 0)
                {
                    dgvMH.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    FrmNhapMonHoc_Load(null, null); // load dữ liệu lại 
                    txtTKMH.Text = "";
                }
            }
        }
        public DataTable LoadDataKhoa(string sql)
        {
            adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(table);
            conn.Close();
            return table;
        }
        private void FrmNhapMonHoc_Load(object sender, EventArgs e)
        {
            loadData();
       
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMon.Enabled = false;

            txtMaMon.Text = dgvMH.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenMH.Text = dgvMH.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
