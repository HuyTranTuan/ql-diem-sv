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
    public partial class frmInBangDiem : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmInBangDiem(SqlConnection servername)
        {
            InitializeComponent();
            this.conn = servername;
            conn = new SqlConnection(Program.constr);
        }
        private void FrmNhapLop_Load(object sender, EventArgs e)
        {
            loadCBMaLop();
            loadCBMonHoc();
            cbMaLop.SelectedIndex = 0;
            cbMonHoc.SelectedIndex = 0;
            cbLanThi.SelectedIndex = 0;
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
            string sql = "select malop,tenlop from Lop";
            cbMaLop.DataSource = LoadDataTable(sql);
            cbMaLop.DisplayMember = "tenlop";
            cbMaLop.ValueMember = "malop";
        }

        public void loadCBMonHoc()
        {
            string sql = "select mamh,tenmh from Monhoc";
            cbMonHoc.DataSource = LoadDataTable(sql);
            cbMonHoc.DisplayMember = "tenmh";
            cbMonHoc.ValueMember = "mamh";
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
            #region lấy ds SV theo lớp
            command = conn.CreateCommand();
            command.CommandText = " select  s.MaSV, s.ho+' '+ s.ten as HoTen "//, '' as Diem "
                                + " from Sinhvien s "
                                + " WHERE s.malop = '" + cbMaLop.SelectedValue.ToString().Trim() + "' and s.nghihoc = 0 "
                                + " order by s.masv";
            adapter.SelectCommand = command;
            DataTable tblSV = new DataTable("SinhVien");
            tblSV.Columns.Add("MaSV", typeof(string));
            tblSV.Columns.Add("HoTen", typeof(string));
            //tblSV.Columns.Add("Diem", typeof(string));
            adapter.Fill(tblSV);
            #endregion

            #region lấy ds điểm theo môn học và lần thi
            command = conn.CreateCommand();
            command.CommandText = " select d.MaSV, d.Diem  "
                                + " from Diem d "
                                + " WHERE d.mamh = '" + cbMonHoc.SelectedValue.ToString().Trim() + "' and d.lan = '" + cbLanThi.Text + "' ";
            adapter.SelectCommand = command;
            DataTable tblDiem = new DataTable("Diem");
            tblDiem.Columns.Add("MaSV", typeof(string));
            tblDiem.Columns.Add("Diem", typeof(string));
            adapter.Fill(tblDiem);
            #endregion

            #region join
            var JoinResult = (from dSV in tblSV.AsEnumerable()
                              join dDiem in tblDiem.AsEnumerable() on dSV.Field<string>("MaSV") equals dDiem.Field<string>("MaSV") into tempJoin
                              from leftJoin in tempJoin.DefaultIfEmpty()
                              select new
                              {
                                  MaSV = dSV.Field<string>("MaSV"),
                                  HoTen = dSV.Field<string>("HoTen"),
                                  Diem = leftJoin == null ? "Chưa nhập" : leftJoin.Field<string>("Diem")
                              }).ToList();
            #endregion

            table.Clear();
            table = PhuongThuc.ToDataTable(JoinResult);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", table));
            this.reportViewer1.RefreshReport();
        }

    }
}
