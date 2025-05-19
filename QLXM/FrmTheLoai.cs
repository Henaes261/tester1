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
    public partial class FrmTheLoai : Form
    {
        public FrmTheLoai()
        {
            InitializeComponent();
        }

        DataTable tbltheloai;

        private void FrmTheLoai_Load(object sender, EventArgs e)
        {
            txtMaTL.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string query = "SELECT * FROM tbltheloai";
            tbltheloai = Function.GetDataToTable(query);
            dgvTheLoai.DataSource = tbltheloai;
            dgvTheLoai.Columns[0].HeaderText = "Mã thể loại";
            dgvTheLoai.Columns[1].HeaderText = "Tên thể loại";
            dgvTheLoai.AllowUserToAddRows = false;
            dgvTheLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoai.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaTL.Text = "";
            txtTenTL.Text = "";
        }
        private void dgvTheLoai_Click(object sender, EventArgs e)
        {
            txtMaTL.Text = dgvTheLoai.CurrentRow.Cells["maloai"].Value.ToString();
            txtTenTL.Text = dgvTheLoai.CurrentRow.Cells["tenloai"].Value.ToString();
            txtMaTL.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            txtMaTL.Enabled = true;
            txtMaTL.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaTL.Show();
            string query;
            if (txtMaTL.Text == "")
            {
                MessageBox.Show("Hãy chọn bản ghi để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenTL.Text == "")
            {
                MessageBox.Show("Tên thể loại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTL.Focus();
                return; // Không thực hiện sửa khi tên trống
            }

            query = "UPDATE tbltheloai SET tenloai=N'" + txtTenTL.Text.ToString() + "' WHERE maloai=N'" + txtMaTL.Text + "'";
            Function.runsql(query);
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Load_DataGridView();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            ResetValues();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query;
            if (txtMaTL.Text == "")
            {
                MessageBox.Show("Hãy chọn bản ghi để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query = "DELETE tbltheloai WHERE maloai=N'" + txtMaTL.Text + "'";
                Function.RunSqlDel(query);
                Load_DataGridView();
                btnBoQua.Enabled = false;
                btnThem.Enabled = true;
                ResetValues();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string query;
            if (txtMaTL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã thể loại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTL.Focus();
                return;
            }

            if (txtTenTL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên thể loại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTL.Focus();
                return;
            }

            query = "SELECT maloai FROM tbltheloai WHERE maloai = N'" + txtMaTL.Text.Trim() + "'";

            if (Function.CheckKey(query))
            {
                MessageBox.Show("Mã thể loại đã tồn tại, yêu cầu nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTL.Focus();
                txtMaTL.Text = "";
                return;
            }

            query = "INSERT INTO tbltheloai VALUES(N'" + txtMaTL.Text.Trim() + "', N'" + txtTenTL.Text.Trim() + "')";
            Function.runsql(query);
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaTL.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaTL.Enabled = false;
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
