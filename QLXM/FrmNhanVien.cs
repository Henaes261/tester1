using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QLXM
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        DataTable tblnhanvien;
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            txtmanhanvien.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            Load_DataGridView();
            Function.FillCombo("SELECT macv, tencv FROM tblcongviec", cbomacv, "macv", "tencv");
            cbomacv.SelectedIndex = -1;
            resetvalues();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM  tblnhanvien";
            tblnhanvien = Function.GetDataToTable(sql);
            dataGridView1.DataSource = tblnhanvien;
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[2].HeaderText = "Giới tính";
            dataGridView1.Columns[3].HeaderText = "Ngày sinh";
            dataGridView1.Columns[4].HeaderText = "Số điện thoại";
            dataGridView1.Columns[5].HeaderText = "Địa chỉ";
            dataGridView1.Columns[6].HeaderText = "Mã công việc";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void resetvalues()
        {
            txtmanhanvien.Text = "";
            txttennhanvien.Text = "";
            txtdiachi.Text = "";
            chkNam.Checked = false;
            chkNu.Checked = false;
            mskDienthoai.Text = "";
            mskNgaysinh.Text = "";
            cbomacv.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanhanvien.Focus();
                return;
            }
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanhanvien.Text = dataGridView1.CurrentRow.Cells["manv"].Value.ToString();
            txttennhanvien.Text = dataGridView1.CurrentRow.Cells["tennv"].Value.ToString();
            chkNam.Checked = dataGridView1.CurrentRow.Cells["gioitinh"].Value.ToString() == "Nam";
            chkNu.Checked = dataGridView1.CurrentRow.Cells["gioitinh"].Value.ToString() == "Nữ";
            txtdiachi.Text = dataGridView1.CurrentRow.Cells["diachi"].Value.ToString();
            mskDienthoai.Text = dataGridView1.CurrentRow.Cells["sdt"].Value.ToString();
            mskNgaysinh.Text = dataGridView1.CurrentRow.Cells["ngaysinh"].Value.ToString();

            ma = dataGridView1.CurrentRow.Cells["macv"].Value.ToString();
            cbomacv.Text = Function.GetFieldValues("select tencv from tblcongviec where macv=N'" + ma + "'");
            //cbomacv.SelectedValue = ma; // Thiết lập SelectedValue thay vì Text
            txtmanhanvien.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            txtmanhanvien.Enabled = true;
            txtmanhanvien.Focus();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnBoQua.Enabled = false; ;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt = "";
            if (txtmanhanvien.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhanvien.Focus();
                return;
            }
            if (txttennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennhanvien.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (!Function.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            if (chkNam.Checked && !chkNu.Checked)
            {
                gt = "Nam";
            }
            else if (!chkNam.Checked && chkNu.Checked)
            {
                gt = "Nữ";
            }
            else
            {
                MessageBox.Show("Bạn phải chọn chính xác giới tính Nam hoặc Nữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbomacv.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã công việc ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomacv.Focus();
                return;
            }
            sql = "Select manv from tblnhanvien where manv = N'" + txtmanhanvien.Text.Trim() + "'";

            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanhanvien.Focus();
                txtmanhanvien.Text = "";
                return;
            }
            sql = $"INSERT INTO tblnhanvien(manv, tennv, gioitinh, ngaysinh, sdt, diachi, macv) VALUES(N'{txtmanhanvien.Text.Trim()}', N'{txttennhanvien.Text.Trim()}', N'{gt}', '{Function.ConvertDateTime(mskNgaysinh.Text)}', N'{mskDienthoai.Text}', N'{txtdiachi.Text.Trim()}', N'{cbomacv.SelectedValue}')";
            Function.runsql(sql);
            Load_DataGridView();
            resetvalues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = $"DELETE FROM tblnhanvien WHERE manv=N'{txtmanhanvien.Text}'";
                Function.RunSqlDel(sql);
                Load_DataGridView();
                resetvalues();
                btnBoQua.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtmanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennhanvien.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (!Function.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            if (chkNam.Checked && !chkNu.Checked)
            {
                gt = "Nam";
            }
            else if (!chkNam.Checked && chkNu.Checked)
            {
                gt = "Nữ";
            }
            else
            {
                MessageBox.Show("Bạn phải chọn chính xác giới tính Nam hoặc Nữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = $"UPDATE tblnhanvien SET tennv=N'{txttennhanvien.Text.Trim()}', gioitinh=N'{gt}', ngaysinh='{Function.ConvertDateTime(mskNgaysinh.Text)}', sdt='{mskDienthoai.Text}', diachi=N'{txtdiachi.Text.Trim()}', macv=N'{cbomacv.SelectedValue}' WHERE manv=N'{txtmanhanvien.Text}'";
            Function.runsql(sql);
            Load_DataGridView();
            resetvalues();
            btnBoQua.Enabled = false;
        }
    }
}

