using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem.Truong
{
    public partial class frmMainTruong : Form
    {
        SqlConnection con;
        string ma = "";
        string idgroup;
        public frmMainTruong(SqlConnection servername, string idgroup)
        {
            InitializeComponent();
            this.con = servername;
            this.idgroup = idgroup;
        }

        private void FrmMainTruong_Load(object sender, EventArgs e)
        {
            if(idgroup.Contains("Khoa_CNTT"))
            {
                khoaCôngNghệThôngTinToolStripMenuItem.Visible = true;
                viễnThôngToolStripMenuItem.Visible = false;
            }
            else if (idgroup.Contains("Khoa_VT"))
            {
                khoaCôngNghệThôngTinToolStripMenuItem.Visible = false;
                viễnThôngToolStripMenuItem.Visible = true;
            }
            else if (idgroup.Contains("User"))
            {
                giảngViênToolStripMenuItem.Visible = false;
            }
        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Thông báo"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void GiảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmNhapGiangVien NhapGiangVienUI = new frmNhapGiangVien(con);
            //NhapGiangVienUI.MdiParent = this;
            //NhapGiangVienUI.Show();

            frmPhanQuyen frm = new frmPhanQuyen(con);
            frm.MdiParent = this;
            frm.Show();
        }
        private void khoaCôngNghệThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                con = Connection.sql(@"DESKTOP-GAP3GBT\COSOCUAHUY1");
                ma = "CNTT";
                MessageBox.Show("Kết nối csdl khoa CNTT thành công. Vui lòng tắt form đang mở để cập nhật ");
            }
            catch
            {
                MessageBox.Show("Kết nối csdl khoa CNTT thất bại ");
            }
        }

        private void viễnThôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                con = Connection.sql(@"DESKTOP-GAP3GBT\COSOCUAHUY2");
                ma = "VT";
                MessageBox.Show("Kết nối csdl khoa Viễn thông thành công. Vui lòng tắt form đang mở để cập nhật ");
            }
            catch
            {
                MessageBox.Show("Kết nối csdl khoa Viễn thông thất bại ");
            }
        }

        private void SinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapSinhVien NhapSinhVienUI = new frmNhapSinhVien(con);
            NhapSinhVienUI.MdiParent = this;
            NhapSinhVienUI.Show();
        }

        private void MônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapMonHoc NhapMonHocUI = new frmNhapMonHoc(con, ma);
            NhapMonHocUI.MdiParent = this;
            NhapMonHocUI.Show();
        }

        private void KhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmNhapKhoa NhapKhoaUI = new frmNhapKhoa(con);
            //NhapKhoaUI.MdiParent = this;
            //NhapKhoaUI.Show();
        }

        private void LớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapLop NhapLopUI = new frmNhapLop(con);
            NhapLopUI.MdiParent = this;
            NhapLopUI.Show();
        }

        private void MônHọcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmNhapMonHoc NhapMonHocUI = new frmNhapMonHoc(con, ma);
            NhapMonHocUI.MdiParent = this;
            NhapMonHocUI.Show();
        }

        private void CơSở1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.con = Connection.sql("USER-PC\\CS1");
        }

        private void CơSở2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.con = Connection.sql("NGAN\\THUYNGAN3");
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapDiem frm = new frmNhapDiem(con);
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMainTruong_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Thông báo"
                                 , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void danhSáchSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInDSSV frm = new frmInDSSV(con);
            frm.MdiParent = this;
            frm.Show();
        }

        private void bảngĐiểmMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInBangDiem frm = new frmInBangDiem(con);
            frm.MdiParent = this;
            frm.Show();
        }

        private void phiếuĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInBangDiemTongKet frm = new frmInBangDiemTongKet(con);
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
