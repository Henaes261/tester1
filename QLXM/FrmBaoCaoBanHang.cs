using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QLXM
{
    public partial class FrmBaoCaoBanHang : Form
    {
        DataTable tblbc;
        DataTable tblbc1;
        public FrmBaoCaoBanHang()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoBanHang_Load(object sender, EventArgs e)
        {
            Function.connect();
            mskdenngay.Text = "";
            msktungay.Text = "";
            mskNgayban.Text = "";
            rdoNgay.Visible = true;
            rdoKhoang.Visible = true;
            btnIn.Enabled = true;
            btnTimkiem.Enabled = true;

            Function.FillCombo("select makhach, tenkhach from tblkhachhang", cboTenKH, "makhach", "tenkhach");
            cboTenKH.SelectedIndex = -1;
            Function.FillCombo("select manv, tennv from tblnhanvien", cboTenNV, "manv", "tennv");
            cboTenNV.SelectedIndex = -1;
            Function.FillCombo("select mahang, tenhang from tbldmhang", cboTenhang, "mahang", "tenhang");
            cboTenhang.SelectedIndex = -1;
            Function.FillCombo("select soddh from tbldondathang", cboSoddh, "soddh", "soddh");
            cboSoddh.SelectedIndex = -1;
            string sql = "SELECT a.mahang, b.tenhang, a.soluong, a.giamgia, a.thanhtien, c.tenkhach, d.tennv,ddh.ngaymua " +
                         "FROM tblchitietddh AS a " +
                         "INNER JOIN tbldmhang AS b ON a.mahang = b.mahang " +
                         "INNER JOIN tbldondathang AS ddh ON a.soddh = ddh.soddh " +
                         "JOIN tblkhachhang AS c ON ddh.makhach = c.makhach " +
                         "JOIN tblNhanvien AS d ON ddh.manv = d.manv "
                        ;
            Load_DataGridView1(sql);
            Load_DataGridView2("SELECT b.tenhang, SUM(a.soluong) AS soluong FROM tblchitietddh AS a JOIN tbldmhang AS b ON a.mahang = b.mahang GROUP BY b.tenhang ORDER BY SUM(a.soluong) DESC");
            btnLai.Enabled = false;
            btnIn.Enabled = false;
            mskdenngay.Enabled = false;
            mskNgayban.Enabled = false;
            msktungay.Enabled = false;
        }
        private void Load_DataGridView1(string sql)
        {
            tblbc = Function.GetDataToTable(sql);
            DataGridView1.DataSource = tblbc;
            DataGridView1.Columns[0].HeaderText = "Mã hàng";
            DataGridView1.Columns[1].HeaderText = "Tên hàng";
            DataGridView1.Columns[2].HeaderText = "Số lượng";
            DataGridView1.Columns[3].HeaderText = "Giảm giá (%)";
            DataGridView1.Columns[4].HeaderText = "Thành tiền";
            DataGridView1.Columns[5].HeaderText = "Tên khách hàng";
            DataGridView1.Columns[6].HeaderText = "Tên nhân viên";
            DataGridView1.Columns[7].HeaderText = "Ngày bán";
            DataGridView1.Columns[0].Width = 80;
            DataGridView1.Columns[1].Width = 100;
            DataGridView1.Columns[2].Width = 80;
            DataGridView1.Columns[3].Width = 90;
            DataGridView1.Columns[4].Width = 90;
            DataGridView1.Columns[5].Width = 100;
            DataGridView1.Columns[6].Width = 100;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_DataGridView2(string sql)
        {
            tblbc1 = Function.GetDataToTable(sql);
            DataGridView2.DataSource = tblbc1;
            DataGridView2.Columns[0].HeaderText = "Tên hàng";
            DataGridView2.Columns[1].HeaderText = "Số lượng bán";
            DataGridView2.Columns[0].Width = 70;
            DataGridView2.Columns[1].Width = 50;
            DataGridView2.AllowUserToAddRows = false;
            DataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql, dk;
            if ((cboSoddh.Text == "") && (cboTenhang.Text == "") &&
                (mskNgayban.Text == "  /  /") && (cboTenKH.Text == "") && (cboTenNV.Text == "") && (msktungay.Text == "  /  /") && (mskdenngay.Text == "  /  /"))
            {
                MessageBox.Show("Hãy nhập ít nhất 1 dữ liệu để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "SELECT a.mahang, b.tenhang, a.soluong, a.giamgia, a.thanhtien, c.tenkhach, d.tennv,ddh.ngaymua ";
            dk = "FROM tblchitietddh AS a " +
                  "INNER JOIN tbldmhang AS b ON a.mahang = b.mahang " +
                  "INNER JOIN tbldondathang AS ddh ON a.soddh = ddh.soddh " +
                  "JOIN tblkhachhang AS c ON ddh.makhach = c.makhach " +
                  "JOIN tblNhanvien AS d ON ddh.manv = d.manv where 1=1 ";

            if (cboSoddh.Text != "")
            {
                dk += " AND a.soddh=N'" + cboSoddh.Text + "'";
            }
            if (cboTenhang.Text != "")
            {
                dk += " AND b.mahang =N'" + cboTenhang.SelectedValue + "'";
            }
            if (mskNgayban.Text != "  /  /")
            {
                if (!Function.IsDate(mskNgayban.Text))
                {
                    MessageBox.Show("Hãy nhập lại ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskNgayban.Focus();
                    mskNgayban.Text = "";
                    return;
                }
                dk += " AND ddh.ngaymua ='" + Function.ConvertDateTime(mskNgayban.Text) + "'";
            }
            if (msktungay.Text != "  /  /" && mskdenngay.Text != "  /  /")
            {
                if (!Function.IsDate(mskdenngay.Text))
                {
                    MessageBox.Show("Hãy nhập lại ngày hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskdenngay.Text = "  /  /";
                    mskdenngay.Focus();
                    return;
                }
                if (!Function.IsDate(msktungay.Text))
                {
                    MessageBox.Show("Hãy nhập lại ngày hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msktungay.Text = "  /  /";
                    msktungay.Focus();
                    return;
                }
                if (DateTime.ParseExact(msktungay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(mskdenngay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskdenngay.Text = "  /  /";
                    msktungay.Text = "  /  /";
                    return;
                }
                dk += " AND (ddh.ngaymua BETWEEN '" + Function.ConvertDateTime(msktungay.Text) + "' AND '" + Function.ConvertDateTime(mskdenngay.Text) + "')";
            }
            if (cboTenKH.SelectedValue != null)
            {
                dk += " AND c.makhach =N'" + cboTenKH.SelectedValue + "'";
            }
            if (cboTenNV.SelectedValue != null)
            {
                dk += " AND d.manv=N'" + cboTenNV.SelectedValue + "'";
            }

            Load_DataGridView1(sql + dk);
            Load_DataGridView2("SELECT b.tenhang, SUM(a.soluong) as soluong " + dk + " GROUP BY b.tenhang ORDER BY SUM(a.soluong) DESC");

            if (tblbc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetValues();
                return;
            }
            cboSoddh.Enabled = false;
            cboTenhang.Enabled = false;
            cboTenKH.Enabled = false;
            cboTenNV.Enabled = false;
            mskdenngay.Enabled = false;
            mskNgayban.Enabled = false;
            msktungay.Enabled = false;
            rdoKhoang.Enabled = false;
            rdoNgay.Enabled = false;
            btnIn.Enabled = true;
            btnLai.Enabled = true;
            btnTimkiem.Enabled = false;
        }
        private void rdoNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNgay.Checked == true)
            {
                mskNgayban.Enabled = true;
                msktungay.Enabled = false;
                mskdenngay.Enabled = false;
            }
        }

        private void rdoKhoang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoKhoang.Checked == true)
            {
                msktungay.Enabled = true;
                mskdenngay.Enabled = true;
                mskNgayban.Enabled = false;
            }
        }
        private void ResetValues()
        {
            cboSoddh.SelectedIndex = -1;
            cboTenhang.SelectedIndex = -1;
            cboTenKH.SelectedIndex = -1;
            cboTenNV.SelectedIndex = -1;
            mskNgayban.Text = "";
            msktungay.Text = "";
            mskdenngay.Text = "";
            rdoNgay.Checked = false;
            rdoKhoang.Checked = false;
            string sql = "SELECT a.mahang, b.tenhang, a.soluong, a.giamgia, a.thanhtien, c.tenkhach, d.tennv,ddh.ngaymua " +
                         "FROM tblchitietddh AS a " +
                         "INNER JOIN tbldmhang AS b ON a.mahang = b.mahang " +
                         "INNER JOIN tbldondathang AS ddh ON a.soddh = ddh.soddh " +
                         "JOIN tblkhachhang AS c ON ddh.makhach = c.makhach " +
                         "JOIN tblNhanvien AS d ON ddh.manv = d.manv "
                        ;
            Load_DataGridView1(sql);
            Load_DataGridView2("SELECT b.tenhang, SUM(a.soluong) AS soluong FROM tblchitietddh AS a JOIN tbldmhang AS b ON a.mahang = b.mahang GROUP BY b.tenhang ORDER BY SUM(a.soluong) DESC");
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];
            exRange.Range["D10:E10:F10:H10"].Font.Size = 14;
            exRange.Range["D10:E10:F10:H10"].Font.Name = "Times new roman";
            exRange.Range["D10:E10:F10:H10"].Font.Bold = true;
            exRange.Range["D10:E10:F10:H10"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["D10:E10:F10:H10"].MergeCells = true;
            exRange.Range["D10:E10:F10: H10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D10:E10:F10:H10"].Value = "DANH SÁCH BÁN HÀNG ";
            exRange.Range["A12:I12"].Font.Bold = true;
            exRange.Range["A12:I12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A12:A12"].Value = "STT";
            exRange.Range["B12:B12"].Value = "Mã hàng";
            exRange.Range["C12:C12"].Value = "Tên hàng";
            exRange.Range["C12:C12"].ColumnWidth = 14;
            exRange.Range["D12:D12"].Value = "Số lượng";
            exRange.Range["E12:E12"].Value = "Giảm giá";
            exRange.Range["F12:I12"].ColumnWidth = 12;
            exRange.Range["F12:F12"].Value = "Thành tiền";
            exRange.Range["G12:G12"].Value = "Tên khách";
            exRange.Range["H12:H12"].Value = "Tên nhân viên";
            exRange.Range["I12:I12"].Value = "Ngày bán";


            for (hang = 0; hang < tblbc.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 13] = hang + 1;
                for (cot = 0; cot < tblbc.Columns.Count; cot++)
                {
                    if (tblbc.Columns[cot].ColumnName == "ngaymua")
                    {
                        exSheet.Cells[cot + 2][hang + 13] = tblbc.Rows[hang]["ngaymua"];
                    }
                    else exSheet.Cells[cot + 2][hang + 13] = tblbc.Rows[hang][cot].ToString();
                }
            }
            exRange.Range["N12:O12"].Font.Bold = true;
            exRange.Range["N12:N12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["N12:N12"].ColumnWidth = 14;
            exRange.Range["N12:N12"].Value = "Tên hàng";
            exRange.Range["O12:O12"].Value = "Số lượng bán";
            for (hang = 0; hang < tblbc1.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 13] = hang + 1;
                for (cot = 0; cot < tblbc1.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 14][hang + 13] = tblbc1.Rows[hang][cot].ToString();
                }
            }

            exApp.Visible = true;
        }

        private void btnLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            rdoNgay.Enabled = true;
            rdoKhoang.Enabled = true;
            cboSoddh.Enabled = true;
            cboTenhang.Enabled = true;
            cboTenKH.Enabled = true;
            cboTenNV.Enabled = true;
            btnIn.Enabled = false;
            btnLai.Enabled = false;
            btnTimkiem.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
