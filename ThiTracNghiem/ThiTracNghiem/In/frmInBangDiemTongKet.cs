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
    public partial class frmInBangDiemTongKet : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapterAll = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmInBangDiemTongKet(SqlConnection servername)
        {
            InitializeComponent();
            this.conn = servername;
            conn = new SqlConnection(Program.constr);
        }
        private void FrmNhapLop_Load(object sender, EventArgs e)
        {
            loadCBMaLop();
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
        public void loadCBMaLop()
        {
            string sql2 = "select malop,tenlop from Lop";
            cbMaLop.DataSource = LoadDataTable(sql2);
            cbMaLop.DisplayMember = "tenlop";
            cbMaLop.ValueMember = "maLop";
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
            command.CommandText = " select l.tenlop, s.masv, s.ho +' '+s.ten as hoten, m.tenmh, max(d.diem) diem "
                                + " from SinhVien s inner join Lop l on s.malop = l.malop "
                                + " inner join Diem d on s.masv = d.masv "
                                + " inner join MonHoc m on d.mamh = m.mamh "
                                + " where s.malop = '"+cbMaLop.SelectedValue.ToString()+ "' group by l.tenlop, s.masv, s.ho, s.ten, m.tenmh order by s.masv";
            adapterAll.SelectCommand = command;
            table.Clear();
            adapterAll.Fill(table);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", table));
            this.reportViewer1.RefreshReport();
        }

    }
}
