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
    public partial class frmNhapSinhVien : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
            command = conn.CreateCommand();
            command.CommandText = "SELECT malop,MaSV,Ho,Ten,NgaySinh, noisinh,phai,DiaChi,nghihoc FROM SinhVien ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvSV.DataSource = table;
            dgvSV.Refresh();
        }

        public DataTable LoadDataLop(string sql)
        {
            adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(table);
            conn.Close();
            return table;
        }
        public void loadCBMaLop()
        {
            string sql = "select MaLop from Lop";
            adapter = new SqlDataAdapter(sql, conn);
            table = new DataTable();
            adapter.Fill(table);
            cbMaLop.DataSource = LoadDataLop(sql);
            cbMaLop.DisplayMember = "tenlop";
            cbMaLop.ValueMember = "MaLop";
        }

        public frmNhapSinhVien(SqlConnection servername)
        {
            InitializeComponent();
            this.conn = servername;
            conn.Open();
            dgvSV.DataSource = "select MaLop,tenlop from Lop";
            conn.Close();
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã SV");
                txtMaSV.Focus();
                return;
            }
            if (txtHoSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ SV");
                txtHoSV.Focus();
                return;
            }
            if (txtTenSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên SV");
                txtTenSV.Focus();
                return;
            }
            if (cbMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã lớp");
                cbMaLop.Focus();
                return;
            }
            string ngaySinh = dtSV.Value.ToString("yyyy-MM-dd");
            /// Them
            conn.Open();
            command = new SqlCommand("EXEC sp_ThemSinhvien '" + txtMaSV.Text+"', '"+txtHoSV.Text+ "', '" + txtTenSV.Text + "', '" + cbMaLop.Text + "', '" + (chkPhai.Checked == true ? 1 : 0)  
                                    + "', '" + ngaySinh + "', '" + txtNoiSinh.Text + "', '" + txtDiaChi.Text + "', '" + (chkNghiHoc.Checked == true ? 1 : 0) + "'", conn);
            int res = command.ExecuteNonQuery();
            if (res == 1)
            {
                MessageBox.Show("Thêm Thành Công!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm Thất bại Vui Lòng Kiểm Tra Lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadData();
            conn.Close();
        }

        private void DgvSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///// Dữ liệu
            ////txtMaSV.ReadOnly = true;
            //txtMaSV.Enabled = false;
            //int i;
            //i = dgvSV.CurrentRow.Index;
            //txtMaSV.Text = dgvSV.Rows[i].Cells[0].Value.ToString();
            //txtHoSV.Text = dgvSV.Rows[i].Cells[1].Value.ToString();
            //txtTenSV.Text = dgvSV.Rows[i].Cells[2].Value.ToString();
            //dtSV.Text = dgvSV.Rows[i].Cells[3].Value.ToString();
            //txtDiaChi.Text = dgvSV.Rows[i].Cells[4].Value.ToString();
            //cbMaLop.Text = dgvSV.Rows[i].Cells[6].Value.ToString();
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
                command.CommandText = "delete from SinhVien where MaSV = '" + txtMaSV.Text + "'";
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
            string phai = "1";
            if (chkPhai.Checked)
                phai = "1";
            else
                phai = "0";

            string nghiHoc = "1";
            if (chkNghiHoc.Checked)
                nghiHoc = "1";
            else
                nghiHoc = "0";
            string ngaySinh = dtSV.Value.ToString("yyyy-MM-dd");
            command.CommandText = "update SinhVien set MaLop = '" + cbMaLop.Text + "', Ho = '" + txtHoSV.Text + "', Ten = '" + txtTenSV.Text + "', NgaySinh = '" + ngaySinh + "', DiaChi = '"+ txtDiaChi.Text 
                        + "' , NoiSinh = '" + txtNoiSinh.Text + "', phai = " + phai + " , nghihoc = " + nghiHoc + " where MaSV = '" + txtMaSV.Text + "'";
            command.ExecuteNonQuery();
            loadData();
            conn.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            /// Ghi, lam moi
            txtMaSV.Enabled = true;
            txtMaSV.Focus();
            txtMaSV.Text = "";
            txtHoSV.Text = "";
            txtTenSV.Text = "";
            dtSV.Text = "01/01/1900";
            txtDiaChi.Text = "";
            txtNoiSinh.Text = "";
            chkPhai.Checked = true;
            chkNghiHoc.Checked = false;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmNhapSinhVien_Load(object sender, EventArgs e)
        {
            loadData();
            loadCBMaLop();
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

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }
        public DataTable TimKiemSinhVien(string TimKiemSV)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand _cmd = new SqlCommand("sp_TimSinhvien", conn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("tensv", SqlDbType.NVarChar)).Value = TimKiemSV;
            SqlDataAdapter sda = new SqlDataAdapter(_cmd);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            /// tìm kiếm
            if (txtTKSV.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập thông tin !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                table = new DataTable();
                table = TimKiemSinhVien(txtTKSV.Text.Trim());
                if (table.Rows.Count > 0)
                {
                    dgvSV.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    FrmNhapSinhVien_Load(null, null); // load dữ liệu lại 
                    txtTKSV.Text = "";
                }
            }
        }

        private void CbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //malop,MaSV,Ho,Ten,NgaySinh, noisinh,phai,DiaChi,nghihoc

            txtMaSV.Enabled = false;

            cbMaLop.Text = dgvSV.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMaSV.Text = dgvSV.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtHoSV.Text = dgvSV.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTenSV.Text = dgvSV.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtSV.Text = dgvSV.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtNoiSinh.Text = dgvSV.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (bool.Parse(dgvSV.Rows[e.RowIndex].Cells["phai"].Value.ToString()) == true)
                chkPhai.Checked = true;
            else
                chkPhai.Checked = false;
           
           
            txtDiaChi.Text = dgvSV.Rows[e.RowIndex].Cells[7].Value.ToString();
            if (bool.Parse(dgvSV.Rows[e.RowIndex].Cells["nghihoc"].Value.ToString()) == true)
                chkNghiHoc.Checked = true;
            else
                chkNghiHoc.Checked = false;
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            /// tìm kiếm
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn sinh viên để in phiếu điểm !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                frmInPhieuDiem frm = new frmInPhieuDiem(conn, txtMaSV.Text.Trim());
                frm.ShowDialog();
            }
        }
    }
}
