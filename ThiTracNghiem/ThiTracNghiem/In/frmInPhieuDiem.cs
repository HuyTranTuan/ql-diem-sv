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
    public partial class frmInPhieuDiem : Form
    {
        string maSV = "";
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmInPhieuDiem(SqlConnection servername, string maSV)
        {
            InitializeComponent();
            this.conn = servername;
            this.maSV = maSV;
            conn = new SqlConnection(Program.constr);
        }
        private void FrmNhapLop_Load(object sender, EventArgs e)
        {
            command = conn.CreateCommand();
            command.CommandText = " select d.mamh, m.tenmh, max(d.diem) as diem from Diem d "
                                + " inner join Monhoc m on d.mamh = m.mamh "
                                + " where d.masv = '"+maSV+"' group by d.mamh, m.tenmh order by d.mamh";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", table));
            this.reportViewer1.RefreshReport();
        }
       
    }
}
