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
    public partial class frmInDSSV : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void FrmNhapLop_Load(object sender, EventArgs e)
        {
            string sql1 = "select makhoa, tenkhoa from Khoa";
            cbMaKhoa.DataSource = LoadDataTable(sql1);
            cbMaKhoa.DisplayMember = "tenkhoa";
            cbMaKhoa.ValueMember = "makhoa";
            cbMaKhoa.SelectedIndex = 0;

            string sql2 = "select maLop, tenlop from Lop where makhoa='" + cbMaKhoa.SelectedValue.ToString() + "' ";
            cbMaLop.DataSource = LoadDataTable(sql2);
            cbMaLop.DisplayMember = "tenlop";
            cbMaLop.ValueMember = "maLop";
            cbMaLop.SelectedIndex = 0;
        }
        public DataTable LoadDataTable(string sql)
        {
            DataTable dt = new DataTable();
            //Conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }

        public frmInDSSV(SqlConnection servername)
        {
            InitializeComponent();
            this.conn = servername;
            conn = new SqlConnection(Program.constr);
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
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            command = conn.CreateCommand();
            command.CommandText = "SELECT MaSV, Ho, Ten, NgaySinh, noisinh,case when phai = 0 then N'Nữ' else 'Nam' end phai,DiaChi,case when nghihoc = 0 then N'Không' else N'Rồi' end nghihoc FROM SinhVien where malop='"+cbMaLop.SelectedValue.ToString()+"' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", table));
            this.reportViewer1.RefreshReport();
        }

        private void cbMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql1 = "select maLop, tenlop from Lop where makhoa='"+cbMaKhoa.SelectedValue.ToString()+"' ";
            cbMaLop.DataSource = LoadDataTable(sql1);
            cbMaLop.DisplayMember = "tenlop";
            cbMaLop.ValueMember = "maLop";
            //cbMaLop.SelectedIndex = 0;
        }
    }
}
