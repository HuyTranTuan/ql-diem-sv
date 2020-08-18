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
    public partial class frmNhapDiem : Form
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
            string sql = "";
            if(cbMaLop.Text.Contains("VT"))
                sql = "select mamh,tenmh from Monhoc where mamh like 'VT%'";
            else
                sql = "select mamh,tenmh from Monhoc where mamh not like 'VT%'";
            cbMonHoc.DataSource = LoadDataTable(sql);
            cbMonHoc.DisplayMember = "tenmh";
            cbMonHoc.ValueMember = "mamh";
        }

        public frmNhapDiem(SqlConnection servername)
        {
            InitializeComponent();
            this.conn = servername;
            conn = new SqlConnection(Program.constr);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ///// hieu chinh
            //conn.Open();
            //command = conn.CreateCommand();
            //string phai = "1";
            //if (chkPhai.Checked)
            //    phai = "1";
            //else
            //    phai = "0";

            //string nghiHoc = "1";
            //if (chkNghiHoc.Checked)
            //    nghiHoc = "1";
            //else
            //    nghiHoc = "0";
            //string ngaySinh = dtSV.Value.ToString("yyyy-MM-dd");
            //command.CommandText = "update SinhVien set MaLop = '" + cbMaLop.Text + "', Ho = '" + txtHoSV.Text + "', Ten = '" + txtTenSV.Text + "', NgaySinh = '" + ngaySinh + "', DiaChi = '"+ txtDiaChi.Text 
            //            + "' , NoiSinh = '" + txtNoiSinh.Text + "', phai = " + phai + " , nghihoc = " + nghiHoc + " where MaSV = '" + txtMaSV.Text + "'";
            //command.ExecuteNonQuery();
            //loadData();
            //conn.Close();
        }

        private void FrmNhapSinhVien_Load(object sender, EventArgs e)
        {
            loadCBMaLop();
            loadCBMonHoc();
            cbMaLop.SelectedIndex = 0;
            cbMonHoc.SelectedIndex = 0;
            cbLanThi.SelectedIndex = 0;
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

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == nutCapNhat.Index && e.RowIndex >= 0)
                {
                    float diem;
                    if (dgvSV.Rows[e.RowIndex].Cells[3].Value.ToString() == "")
                    {
                        MessageBox.Show("Vui lòng nhập điểm", "Thông báo");
                        return;
                    }
                    if (!float.TryParse(dgvSV.Rows[e.RowIndex].Cells[3].Value.ToString(), out diem))
                    {
                        MessageBox.Show("Điểm phải nhập là số", "Thông báo");
                        return;
                    }
                    diem = float.Parse(dgvSV.Rows[e.RowIndex].Cells[3].Value.ToString());
                    if (diem < 0 || diem > 10)
                    {
                        MessageBox.Show("Điểm phải nhập từ 0 đến 10", "Thông báo");
                        return;
                    }

                    string masv = dgvSV.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string mamh = cbMonHoc.SelectedValue.ToString();
                    try
                    {
                        if (cbLanThi.Text.Trim() == "1")
                        {
                            #region nhập điểm lần 1
                            int kt = KiemTraDiemTonTaiLan1(masv, mamh);
                            if (kt == 1)
                            {
                                conn.Open();
                                command = conn.CreateCommand();
                                command.CommandText = "update Diem set diem = " + diem + " where MaSV = '" + masv + "' and mamh = '" + cbMonHoc.SelectedValue.ToString().Trim() + "' and lan = '" + cbLanThi.Text + "'";
                                command.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Cập nhật điểm lần thi 1 thành công");
                            }
                            else
                            {
                                conn.Open();
                                command = conn.CreateCommand();
                                command = new SqlCommand("insert into Diem (masv,mamh,lan, diem) values ('" + masv + "','" + cbMonHoc.SelectedValue.ToString().Trim() + "','" + cbLanThi.Text + "', " + diem + ")", conn);
                                command.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Nhập điểm lần thi 1 thành công");
                            }
                            #endregion
                        }
                        else
                        {
                            int lan2 = KiemTraDiemTonTaiLan2(masv, mamh);
                            #region nhập điểm lần 2
                            if (lan2 == 1)
                            {
                                conn.Open();
                                command = conn.CreateCommand();
                                command.CommandText = "update Diem set diem = " + diem + " where MaSV = '" + masv + "' and mamh = '" + cbMonHoc.SelectedValue.ToString().Trim() + "' and lan = '" + cbLanThi.Text + "'";
                                command.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Cập nhật điểm lần thi 2 thành công");
                            }
                            else if (lan2 == 3)
                            {
                                conn.Open();
                                command = conn.CreateCommand();
                                command = new SqlCommand("insert into Diem (masv,mamh,lan, diem) values ('" + masv + "','" + cbMonHoc.SelectedValue.ToString().Trim() + "','" + cbLanThi.Text + "', " + diem + ")", conn);
                                command.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Nhập điểm lần thi 2 thành công");
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập điểm lần thi 1 của SV này trước khi nhập lần 2");
                                    return;
                            }
                            #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.ToString());
                    }
                    finally
                    {
                        conn.Close();

                        loadDanhSach();

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
            }
        }
        public int KiemTraDiemTonTaiLan1(string masv, string mamh)
        {
            conn.Open();
            SqlCommand _cmd = new SqlCommand("sp_KiemTraDiemTonTaiLan1", conn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("masv", SqlDbType.NVarChar)).Value = masv;
            _cmd.Parameters.Add(new SqlParameter("mamh", SqlDbType.NVarChar)).Value = mamh;
            _cmd.Parameters.Add(new SqlParameter("kq", SqlDbType.NVarChar)).Value = 0;
            var returnParameter = _cmd.Parameters.Add(new SqlParameter("kq", SqlDbType.NVarChar));
            returnParameter.Direction = ParameterDirection.ReturnValue;

            _cmd.ExecuteNonQuery();
            conn.Close();
            return Int32.Parse(returnParameter.Value.ToString());
        }
        public int KiemTraDiemTonTaiLan2(string masv, string mamh)
        {
            conn.Open();
            SqlCommand _cmd = new SqlCommand("sp_KiemTraDiemTonTaiLan2", conn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("masv", SqlDbType.NVarChar)).Value = masv;
            _cmd.Parameters.Add(new SqlParameter("mamh", SqlDbType.NVarChar)).Value = mamh;
            _cmd.Parameters.Add(new SqlParameter("kq", SqlDbType.NVarChar)).Value = 0;
            var returnParameter = _cmd.Parameters.Add(new SqlParameter("kq", SqlDbType.NVarChar));
            returnParameter.Direction = ParameterDirection.ReturnValue;

            _cmd.ExecuteNonQuery();
            conn.Close();
            return Int32.Parse(returnParameter.Value.ToString());
        }
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            loadDanhSach();
        }
        void loadDanhSach()
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
                                  Diem = leftJoin == null ? "" : leftJoin.Field<string>("Diem")
                              }).ToList();
            #endregion

            table.Clear();
            table = PhuongThuc.ToDataTable(JoinResult);
            dgvSV.DataSource = table;
            dgvSV.Refresh();


            //table.Clear();
            //adapter.Fill(table);
            //dgvSV.DataSource = table;
            //dgvSV.Refresh();
        }
        
        private void dgvSV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dgvSV[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void dgvSV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvSV.Columns["Diem"].Index)
            {
                dgvSV.Rows[e.RowIndex].ErrorText = "";
                int newInteger;

                // Don't try to validate the 'new row' until finished  
                // editing since there 
                // is not any point in validating its initial value. 
                if (dgvSV.Rows[e.RowIndex].IsNewRow) { return; }
                if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || (newInteger < 0) || (newInteger > 10))
                {
                    e.Cancel = true;
                    dgvSV.Rows[e.RowIndex].ErrorText = "Điểm phải là số và có giá trị từ 0 đến 10";
                }
            }
        }
    }
}
