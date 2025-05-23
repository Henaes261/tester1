using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXM
{
    public partial class FrmTimKiemHoaDonNhapHang : Form
    {
        public FrmTimKiemHoaDonNhapHang()
        {
            InitializeComponent();
        }
        DataTable hoadonnhap;
        private void FrmTimKiemHoaDonNhapHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Function.FillCombo("select mancc,tenncc from tblnhacungcap", cboMaNCC, "mancc", "mancc");
            cboMaNCC.SelectedIndex = -1;
            Function.FillCombo("select manv,tennv from tblnhanvien", cboMaNV, "manv", "manv");
            cboMaNV.SelectedIndex = -1;
            Function.FillCombo("select sohdn from tblchitiethdn", cboMaHDN, "sohdn", "sohdn");
            cboMaHDN.SelectedIndex = -1;
            for (int i = 1; i < 13; i++) cboThang.Items.Add(i.ToString());
            cboThang.SelectedIndex = -1;
            for (int i = 2020; i <= DateTime.Now.Year; i++) cboNam.Items.Add(i.ToString());
            cboNam.SelectedIndex = -1;
            btnTimlai.Enabled = false;

            // Load dữ liệu ban đầu và hiển thị
            LoadAllHoaDonNhap();
            dataGridView1.DataSource = hoadonnhap; // Gán DataSource trước
            Load_DataGridView();
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is ComboBox)
                    Ctl.Text = "";
            cboMaHDN.Focus();
        }

        private void LoadAllHoaDonNhap()
        {
            string sql = "SELECT a.sohdn, a.ngaynhap, a.tongtien, a.manv, nv.tennv, a.mancc, ncc.tenncc " +
                 "FROM tblhoadonnhap a " +
                 "JOIN tblnhanvien nv ON a.manv = nv.manv " +
                 "JOIN tblnhacungcap ncc ON a.mancc = ncc.mancc";
            hoadonnhap = Function.GetDataToTable(sql);
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboMaHDN.Text == "" && cboThang.Text == "" && cboNam.Text == "" &&
        cboMaNV.Text == "" && cboMaNCC.Text == "")
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rows = hoadonnhap.AsEnumerable();

            if (!string.IsNullOrEmpty(cboMaHDN.Text))
            {
                rows = rows.Where(r => r.Field<string>("sohdn").Contains(cboMaHDN.Text));
            }

            if (!string.IsNullOrEmpty(cboMaNCC.Text))
            {
                rows = rows.Where(r => r.Field<string>("mancc").Contains(cboMaNCC.Text));
            }

            if (!string.IsNullOrEmpty(cboMaNV.Text))
            {
                rows = rows.Where(r => r.Field<string>("manv").Contains(cboMaNV.Text));
            }

            if (!string.IsNullOrEmpty(cboThang.Text))
            {
                int thang;
                if (int.TryParse(cboThang.Text, out thang) && thang >= 1 && thang <= 12)
                {
                    rows = rows.Where(r => r.Field<DateTime>("ngaynhap").Month == thang);
                }
                else
                {
                    MessageBox.Show("Bạn nhập sai tháng, hãy nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboThang.Text = "";
                    cboThang.Focus();
                    return;
                }
            }

            if (!string.IsNullOrEmpty(cboNam.Text))
            {
                int nam;
                if (int.TryParse(cboNam.Text, out nam) && nam >= 2020 && nam <= DateTime.Today.Year)
                {
                    rows = rows.Where(r => r.Field<DateTime>("ngaynhap").Year == nam);
                }
                else
                {
                    MessageBox.Show("Bạn nhập sai năm, hãy nhập lại\n Cửa hàng mở từ năm 2020, vui lòng không nhập các năm trước đó", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboNam.Text = "";
                    cboNam.Focus();
                    return;
                }
            }

            DataTable filtered = rows.Any() ? rows.CopyToDataTable() : hoadonnhap.Clone();

            if (filtered.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView1.DataSource = filtered;
                return;
            }
            else
            {
                MessageBox.Show("Có " + filtered.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = filtered;
            }

            foreach (Control Ctl in this.Controls)
                if ((Ctl is TextBox) || (Ctl is ComboBox))
                    Ctl.Enabled = false;

            btnTimkiem.Enabled = false;
            btnTimlai.Enabled = true;
        }
        private void Load_DataGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Mã hoá đơn nhập";
            dataGridView1.Columns[1].HeaderText = "Ngày nhập";
            dataGridView1.Columns[2].HeaderText = "Tổng tiền";
            dataGridView1.Columns[3].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[4].HeaderText = "Tên NCC";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            foreach (Control Ctl in this.Controls)
                if ((Ctl is TextBox) || (Ctl is ComboBox))
                    Ctl.Enabled = true;
            dataGridView1.DataSource = null;
            btnTimlai.Enabled = false;
            btnTimkiem.Enabled = true;

            // Load lại toàn bộ dữ liệu
            LoadAllHoaDonNhap();
            dataGridView1.DataSource = hoadonnhap;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cboNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
