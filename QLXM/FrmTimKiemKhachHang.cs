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
    public partial class FrmTimKiemKhachHang : Form
    {
        public FrmTimKiemKhachHang()
        {
            InitializeComponent();
        }

        DataTable tblkhachhang;

        private void FrmTimKiemKhachHang_Load(object sender, EventArgs e)
        {
            cboMaKhach.Focus();
            Resetvalue();
            dgvTKKH.DataSource = null;
            Function.FillCombo("SELECT makhach FROM tblkhachhang", cboMaKhach, "makhach", "makhach");
            Function.FillCombo("SELECT diachi FROM tblkhachhang", cboDiaChi, "diachi", "diachi");
            load_dgvTKKH();
        }
        private void Resetvalue()
        {
            cboMaKhach.Text = "";
            txtTenKhach.Text = "";
            cboDiaChi.Text = "";
            txtSDT.Text = "";
        }
        private void load_dgvTKKH()
        {
            string query = "SELECT makhach, tenkhach, diachi, sdt FROM tblkhachhang";
            dgvTKKH.DataSource = Function.GetDataToTable(query);

            dgvTKKH.Columns[0].HeaderText = "Mã khách";
            dgvTKKH.Columns[1].HeaderText = "Tên khách";
            dgvTKKH.Columns[2].HeaderText = "Địa chỉ";
            dgvTKKH.Columns[3].HeaderText = "Số điện thoại";

            dgvTKKH.AllowUserToAddRows = false;
            dgvTKKH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<string> conditions = new List<string>();

            if (!string.IsNullOrWhiteSpace(cboMaKhach.Text))
                conditions.Add("makhach = N'" + cboMaKhach.Text.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(txtTenKhach.Text))
                conditions.Add("tenkhach = N'" + txtTenKhach.Text.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(cboDiaChi.Text))
                conditions.Add("diachi = N'" + cboDiaChi.Text.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(txtSDT.Text) && txtSDT.Text != "(   )    -")
                conditions.Add("sdt = N'" + txtSDT.Text.Trim() + "'");

            if (conditions.Count == 0)
            {
                MessageBox.Show("Hãy nhập ít nhất một điều kiện để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "SELECT * FROM tblkhachhang WHERE " + string.Join(" OR ", conditions);

            tblkhachhang = Function.GetDataToTable(sql);

            if (tblkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Không có khách hàng thỏa mãn điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có " + tblkhachhang.Rows.Count + " khách hàng thỏa mãn điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTKKH.DataSource = tblkhachhang;
            }

            // Cho phép nhấn Tìm kiếm lại
            btnTimKiemLai.Enabled = true;
        }

        private void btnTimKiemLai_Click(object sender, EventArgs e)
        {
            // Reset các ô nhập
            Resetvalue();

            // Tải lại toàn bộ danh sách
            load_dgvTKKH();

            // Cập nhật trạng thái nút
            btnTimKiem.Enabled = true;
            btnTimKiemLai.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
