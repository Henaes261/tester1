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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QLXM
{
    public partial class FrmHoaDonBanHang : Form
    {
        public FrmHoaDonBanHang()
        {
            InitializeComponent();
        }
        DataTable tblchitietddh;

        private void FrmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            Function.connect();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            txtNgay.ReadOnly = true;
            txtsoddh.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtSdt.ReadOnly = true;
            btnBoqua.Enabled = false;
            txtTenhang.ReadOnly = true;
            txtThue.Text = "0";
            txtThue.ReadOnly = true;
            txtDatcoc.Text = "0";
            txtDatcoc.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtTongtien.Text = "0";
            txtGiamgia.Text = "0";
            Function.FillCombo("select makhach,tenkhach from tblkhachhang", cboMaKH, "makhach", "makhach");
            cboMaKH.SelectedIndex = -1;
            Function.FillCombo("select manv, tennv from tblnhanvien", cboMaNV, "manv", "manv");
            cboMaNV.SelectedIndex = -1;
            Function.FillCombo("select mahang,tenhang from tbldmhang", cboMahang, "mahang", "mahang");
            cboMahang.SelectedIndex = -1;
            Function.FillCombo("select soddh from tblchitietddh", cboMaHDBan, "soddh", "soddh");
            cboMaHDBan.SelectedIndex = -1;
            if (txtsoddh.Text != "")
            {
                Load_ThongtinHD();
                btnHuy.Enabled = true;
                btnIn.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }
        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT a.mahang, b.tenhang, a.soluong, a.giamgia, a.thanhtien FROM tblchitietddh as a, tbldmhang as b WHERE a.mahang=b.mahang and a.soddh = N'" + txtsoddh.Text + "'";
            tblchitietddh = Function.GetDataToTable(sql);
            DataGridViewChitiet.DataSource = tblchitietddh;
            DataGridViewChitiet.Columns[0].HeaderText = "Mã hàng";
            DataGridViewChitiet.Columns[1].HeaderText = "Tên hàng";
            DataGridViewChitiet.Columns[2].HeaderText = "Số lượng";
            DataGridViewChitiet.Columns[3].HeaderText = "Giảm giá (%)";
            DataGridViewChitiet.Columns[4].HeaderText = "Thành tiền";
            DataGridViewChitiet.Columns[0].Width = 80;
            DataGridViewChitiet.Columns[1].Width = 100;
            DataGridViewChitiet.Columns[2].Width = 80;
            DataGridViewChitiet.Columns[3].Width = 90;
            DataGridViewChitiet.Columns[4].Width = 90;
            DataGridViewChitiet.AllowUserToAddRows = false;
            DataGridViewChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str, d;
            str = "SELECT ngaymua FROM tbldondathang WHERE soddh = N'" + txtsoddh.Text + "'";
            d = Function.GetFieldValues(str);
            string[] parts = d.Split(' ');
            txtNgay.Text = parts[0];
            str = "SELECT manv FROM tbldondathang WHERE soddh = N'" + txtsoddh.Text + "'";
            cboMaNV.Text = Function.GetFieldValues(str);
            str = "SELECT makhach FROM tbldondathang WHERE soddh = N'" + txtsoddh.Text + "'";
            cboMaKH.Text = Function.GetFieldValues(str);
            str = "SELECT tongtien FROM tbldondathang WHERE soddh = N'" + txtsoddh.Text + "'";
            txtTongtien.Text = Function.GetFieldValues(str);
            lblBangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(txtTongtien.Text);
            str = "SELECT thue FROM tbldondathang WHERE soddh = N'" + txtsoddh.Text + "'";
            txtThue.Text = Function.GetFieldValues(str);
            str = "SELECT datcoc FROM tbldondathang WHERE soddh = N'" + txtsoddh.Text + "'";
            txtDatcoc.Text = Function.GetFieldValues(str);
        }
        private void ResetValues()
        {
            txtsoddh.Text = "";
            txtNgay.Text = DateTime.Now.ToShortDateString();
            cboMaNV.Text = "";
            cboMaKH.Text = "";
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
            cboMaHDBan.Text = "";
            txtThue.Text = "0";
            txtDatcoc.Text = "0";
        }
        private void ResetValuesHang()
        {
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            double s, sl, SLcon;
            string sql;
            sql = "SELECT soluong FROM tblchitietddh WHERE soddh = N'" + Mahoadon + "' AND mahang = N'" + Mahang + "'";
            s = Convert.ToDouble(Function.GetFieldValues(sql));
            sql = "DELETE FROM tblchitietddh WHERE soddh = N'" + Mahoadon + "' AND mahang = N'" + Mahang + "'";
            Function.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT soluong FROM tbldmhang WHERE mahang = N'" + Mahang + "'";
            sl = Convert.ToDouble(Function.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE tbldmhang SET soluong = " + SLcon + " WHERE mahang = N'" + Mahang + "'";
            Function.runsql(sql);
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            double tong, tongmoi;
            string sql;
            sql = "SELECT tongtien FROM tbldondathang WHERE soddh = N'" + Mahoadon + "'";
            tong = Convert.ToDouble(Function.GetFieldValues(sql));
            tongmoi = tong - Thanhtien;
            sql = "UPDATE tbldondathang SET tongtien = " + tongmoi + " WHERE soddh = N'" + Mahoadon + "'";
            Function.runsql(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(tongmoi.ToString());
        }
        public string soddh
        {
            get { return txtsoddh.Text; }
            set { txtsoddh.Text = value; }
        }

        private void FrmHoaDonBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            // Gán mã hóa đơn mới
            txtsoddh.Text = Function.CreateKey("DDH");
            // Gán ngày hiện tại cho ô txtNgay
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");       
            Load_DataGridViewChitiet();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] mahang = new string[20];
                string sql;
                int n = 0;
                sql = "SELECT mahang FROM tblchitietddh WHERE soddh = N'" + txtsoddh.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Function.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mahang[n] = reader.GetString(0).ToString();
                    n++;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (int i = 0; i <= n - 1; i++)
                    DelHang(txtsoddh.Text, mahang[i]);
                sql = "DELETE tbldondathang WHERE soddh=N'" + txtsoddh.Text + "'";
                Function.RunSqlDel(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                btnHuy.Enabled = false;
                btnIn.Enabled = false;
            }
        }

        private void cboMahang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMahang.Text == "")
            {
                txtTenhang.Text = "";
            }
            else
            {
                str = "SELECT Tenhang FROM tbldmHang WHERE Mahang =N'" + cboMahang.SelectedValue + "'";
                txtTenhang.Text = Function.GetFieldValues(str);
            }
        }

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMaHDBan_DropDown(object sender, EventArgs e)
        {
            Function.FillCombo("SELECT soddh FROM tbldondathang", cboMaHDBan, "soddh", "soddh");
            cboMaHDBan.SelectedIndex = -1;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Range["A1"];

            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng bán xe máy";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 046868686";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "ĐƠN ĐẶT HÀNG";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.soddh, a.ngaymua, a.tongtien, b.tenkhach, b.diachi, b.sdt, c.tennv,a.thue,a.datcoc FROM tbldondathang AS a, tblkhachhang AS b, tblnhanvien AS c WHERE a.soddh = N'" + txtsoddh.Text + "' AND a.makhach = b.makhach AND a.manv =c.manv";
            tblThongtinHD = Function.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Số đơn đặt hàng:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = "'" + tblThongtinHD.Rows[0][5].ToString();

            //Lấy thông tin các mặt hàng
            sql = "SELECT b.tenhang, a.soluong, a.giamgia, a.thanhtien FROM tblchitietddh AS a , tbldmhang AS b WHERE a.soddh = N'" + txtsoddh.Text + "' AND a.mahang = b.mahang";
            tblThongtinHang = Function.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Giảm giá";
            exRange.Range["E11:E11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Thuế:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][7].ToString();
            exRange = exSheet.Cells[cot][hang + 15];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 15];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 16]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[cot][hang + 17];
            exRange.Font.Bold = true;
            exRange.Value2 = "Đặt cọc:";
            exRange = exSheet.Cells[cot + 1][hang + 17];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][8].ToString();
            exRange = exSheet.Cells[4][hang + 19]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn bán hàng";
            exApp.Visible = true;
        }

        private void cboMaKH_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKH.Text == "")
            {
                txtTenKH.Text = "";
                txtDiachi.Text = "";
                txtSdt.Text = "";
            }
            // Khi kích chọn mã khách thì tên khách, địa chỉ, điện thoại sẽ tự động hiện ra
            else
            {
                str = "SELECT tenkhach FROM tblkhachhang WHERE makhach = N'" + cboMaKH.SelectedValue + "'";
                txtTenKH.Text = Function.GetFieldValues(str);
                str = "SELECT diachi FROM tblKhachhang WHERE makhach = N'" + cboMaKH.SelectedValue + "'";
                txtDiachi.Text = Function.GetFieldValues(str);
                str = "SELECT sdt FROM tblKhachhang WHERE makhach = N'" + cboMaKH.SelectedValue + "'";
                txtSdt.Text = Function.GetFieldValues(str);
            }
        }

        private void cboMaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNV.Text == "")
                txtTenNV.Text = "";
            else
            // Khi kích chọn mã nhân viên thì tên nhân viên sẽ tự động hiện ra
            {
                str = "SELECT tennv FROM tblnhanvien WHERE manv = N'" + cboMaNV.SelectedValue + "'";
                txtTenNV.Text = Function.GetFieldValues(str);
            }
        }

        private void DataGridViewChitiet_DoubleClick(object sender, EventArgs e)
        {
            string mahang;
            double thanhtien;
            if (DataGridViewChitiet.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                // Xóa hàng và cập nhật lại số lượng hàng 
                mahang = DataGridViewChitiet.CurrentRow.Cells["mahang"].Value.ToString();
                DelHang(txtsoddh.Text, mahang);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                thanhtien = Convert.ToDouble(DataGridViewChitiet.CurrentRow.Cells["thanhtien"].Value.ToString());
                DelUpdateTongtien(txtsoddh.Text, thanhtien);
                Load_DataGridViewChitiet();
            }
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (cboMahang.Text != "")
            {
                double tt, sl, gg, dg;
                if (txtSoluong.Text == "")
                    sl = 0;
                else
                    sl = Convert.ToDouble(txtSoluong.Text);
                if (txtGiamgia.Text == "")
                    gg = 0;
                else
                    gg = Convert.ToDouble(txtGiamgia.Text);
                string sql;
                sql = "select dongiaban from tbldmhang where mahang=N'" + cboMahang.Text + "'";
                dg = Convert.ToDouble(Function.GetFieldValues(sql));
                tt = sl * dg - sl * dg * gg / 100;
                txtThanhtien.Text = tt.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double SLcon;
            if (txtsoddh.Text.Trim().Length == 0 || cboMaNV.SelectedValue == null || cboMaKH.SelectedValue == null || txtNgay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT soddh FROM tbldondathang WHERE soddh=N'" + txtsoddh.Text + "'";
            if (!Function.CheckKey(sql))
            {

                if (txtNgay.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày mua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgay.Focus();
                    return;
                }
                if (Function.IsDate(txtNgay.Text) == false)
                {
                    MessageBox.Show("Bạn nhập sai ngày mua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgay.Text = "";
                    txtNgay.Focus();
                    return;
                }
                if (cboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaNV.Focus();
                    return;
                }
                if (cboMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaKH.Focus();
                    return;
                }

                sql = "INSERT INTO tbldondathang(soddh, manv, ngaymua, makhach, tongtien,thue,datcoc) VALUES(N'" + txtsoddh.Text.Trim() + "',N'" + cboMaNV.SelectedValue + "',N'" +
                        Function.ConvertDateTime(txtNgay.Text.Trim()) + "',N'" + cboMaKH.SelectedValue + "'," + txtTongtien.Text + "," + txtThue.Text + "," + txtDatcoc.Text + ")";
                Function.runsql(sql);
            }

            if (cboMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahang.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            sql = "SELECT mahang FROM tblchitietddh WHERE mahang=N'" + cboMahang.SelectedValue + "' AND soddh = N'" + txtsoddh.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                if ((MessageBox.Show("Mã hàng này đã có, bạn có muốn lưu lại dữ liệu mới này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    //Xóa hàng và cập nhật lại số lượng hàng 
                    DelHang(txtsoddh.Text, DataGridViewChitiet.CurrentRow.Cells["Mahang"].Value.ToString());
                    // Cập nhật lại tổng tiền cho hóa đơn bán
                    DelUpdateTongtien(txtsoddh.Text, Convert.ToDouble(DataGridViewChitiet.CurrentRow.Cells["Thanhtien"].Value.ToString()));
                }
                else
                {
                    cboMahang.SelectedIndex = -1;
                    cboMahang.Focus();
                    return;
                }
            }
            double sl;
            sl = Convert.ToDouble(Function.GetFieldValues("SELECT Soluong FROM tbldmHang WHERE Mahang = N'" + cboMahang.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }

            sql = "INSERT INTO tblchitietddh(soddh, mahang, soluong, giamgia, thanhtien) VALUES(N'" + txtsoddh.Text.Trim() + "', N'" + cboMahang.SelectedValue + "'," + txtSoluong.Text + "," + txtGiamgia.Text + "," + txtThanhtien.Text + ")";
            Function.runsql(sql);
            Load_DataGridViewChitiet();
            double soluong = Convert.ToDouble(txtSoluong.Text);
            //cap nhat lai so luong xe may vao bang tbldmhang
            sl = Convert.ToDouble(Function.GetFieldValues("SELECT soluong FROM tbldmhang WHERE mahang = N'" + cboMahang.SelectedValue + "'"));
            SLcon = sl - soluong;
            sql = "UPDATE tbldmhang SET soluong =" + SLcon + " WHERE mahang= N'" + cboMahang.SelectedValue + "'";
            Function.runsql(sql);
            // Tính tổng tiền có thuế
            double tong, tongmoi, thue, thuemoi, dc, dcmoi;
            tong = Convert.ToDouble(Function.GetFieldValues("SELECT TongTien FROM tbldondathang WHERE soddh = N'" + txtsoddh.Text + "'"));
            tongmoi = tong + Convert.ToDouble(txtThanhtien.Text) * 1.1;
            sql = "UPDATE tbldondathang SET TongTien =" + tongmoi + " WHERE soddh = N'" + txtsoddh.Text + "'";
            Function.runsql(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(tongmoi.ToString());
            thue = Convert.ToDouble(Function.GetFieldValues("SELECT thue FROM tbldondathang WHERE soddh = N'" + txtsoddh.Text + "'"));
            thuemoi = thue + Convert.ToDouble(txtThanhtien.Text) * 0.1;
            sql = "UPDATE tbldondathang SET thue =" + thuemoi + " WHERE soddh = N'" + txtsoddh.Text + "'";
            Function.runsql(sql);
            txtThue.Text = thuemoi.ToString();
            dc = Convert.ToDouble(Function.GetFieldValues("SELECT datcoc FROM tbldondathang WHERE soddh = N'" + txtsoddh.Text + "'"));
            dcmoi = dc + Convert.ToDouble(txtThanhtien.Text) * 0.55;
            sql = "UPDATE tbldondathang SET datcoc =" + dcmoi + " WHERE soddh = N'" + txtsoddh.Text + "'";
            Function.runsql(sql);
            txtDatcoc.Text = dcmoi.ToString();
            // Cập nhật tổng tiền có thuế vào tbldondathang
            btnHuy.Enabled = true;
            btnThem.Enabled = true;
            btnIn.Enabled = true;
            ResetValuesHang();
        }

        private void txtGiamgia_TextChanged(object sender, EventArgs e)
        {
            if (cboMahang.Text != "")
            {
                double tt, sl, gg, dg;
                if (txtSoluong.Text == "")
                    sl = 0;
                else
                    sl = Convert.ToDouble(txtSoluong.Text);
                if (txtGiamgia.Text == "")
                    gg = 0;
                else
                    gg = Convert.ToDouble(txtGiamgia.Text);
                string sql;
                sql = "select dongiaban from tbldmhang where mahang=N'" + cboMahang.Text + "'";
                dg = Convert.ToDouble(Function.GetFieldValues(sql));
                tt = sl * dg - sl * dg * gg / 100;
                txtThanhtien.Text = tt.ToString();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHDBan.Focus();
                return;
            }
            if (Function.CheckKey("select * from tbldondathang where soddh like N'" + cboMaHDBan.Text + "%'") == false)
            {
                MessageBox.Show("Không tồn tại đơn đặt hàng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHDBan.Focus();
                return;
            }
            txtsoddh.Text = cboMaHDBan.Text;
            Load_DataGridViewChitiet();
            Load_ThongtinHD();
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            if ((cboMahang.Text == "") && (txtSoluong.Text == "") && (txtGiamgia.Text == "0") && (txtThanhtien.Text == "0"))
            {
                ResetValues();
                btnIn.Enabled = false; ;
                btnThem.Enabled = true;
                btnTimkiem.Enabled = true;
                btnHuy.Enabled = false;
                btnBoqua.Enabled = false;
                btnLuu.Enabled = false;
                txtsoddh.Enabled = false;
                txtNgay.Text = "";
                Load_DataGridViewChitiet();
            }
            else ResetValuesHang();
        }

        private void DataGridViewChitiet_Click(object sender, EventArgs e)
        {
            if (tblchitietddh.Rows.Count == 0)//
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboMahang.Text = DataGridViewChitiet.CurrentRow.Cells["mahang"].Value.ToString();
            txtTenhang.Text = DataGridViewChitiet.CurrentRow.Cells["tenhang"].Value.ToString();
            txtSoluong.Text = DataGridViewChitiet.CurrentRow.Cells["soluong"].Value.ToString();
            txtGiamgia.Text = DataGridViewChitiet.CurrentRow.Cells["giamgia"].Value.ToString();
            txtThanhtien.Text = DataGridViewChitiet.CurrentRow.Cells["thanhtien"].Value.ToString();
        }

        private void txtsoddh_TextChanged(object sender, EventArgs e)
        {
            if (txtsoddh.Text == "") btnBoqua.Enabled = false;
            else btnBoqua.Enabled = true;
        }

        private void txtNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8) || (e.KeyChar == '/'))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
