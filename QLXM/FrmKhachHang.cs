using System;
using System.Data;
using System.Windows.Forms;

namespace QLXM
{
    public partial class FrmKhachHang : Form
    {
        DataTable tblKhachHang;

        public FrmKhachHang()
        {
            InitializeComponent();
            this.Load += FrmKhachHang_Load;
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            btnLuu.Click += btnLuu_Click;
            btnThoat.Click += btnDong_Click;
            btnTimkiem.Click += btnTimkiem_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            Function.connect();
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql = "SELECT * FROM tblkhachhang";
            tblKhachHang = Function.GetDataToTable(sql);
            dataGridView1.DataSource = tblKhachHang;

            // Đổi tên hiển thị các cột
            dataGridView1.Columns["makhach"].HeaderText = "Mã KH";
            dataGridView1.Columns["tenkhach"].HeaderText = "Tên khách hàng";
            dataGridView1.Columns["diachi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["sdt"].HeaderText = "Số điện thoại";

            // Tùy chọn: Căn độ rộng
            dataGridView1.Columns["makhach"].Width = 100;
            dataGridView1.Columns["tenkhach"].Width = 200;
            dataGridView1.Columns["diachi"].Width = 250;
            dataGridView1.Columns["sdt"].Width = 120;
        }

        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtHoten.Text = "";
            txtDiaChi.Text = "";
            mskSDT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtHoten.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng mã
            foreach (DataRow row in tblKhachHang.Rows)
            {
                if (row["makhach"].ToString() == txtMaKH.Text)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại trong danh sách!", "Cảnh báo");
                    return;
                }
            }

            // Thêm vào bảng tạm (DataTable)
            DataRow newRow = tblKhachHang.NewRow();
            newRow["makhach"] = txtMaKH.Text;
            newRow["tenkhach"] = txtHoten.Text;
            newRow["sdt"] = mskSDT.Text;
            newRow["diachi"] = txtDiaChi.Text;
            tblKhachHang.Rows.Add(newRow);

            dataGridView1.DataSource = tblKhachHang;
            ResetValues();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            int soDongLuu = 0;

            // Duyệt từng dòng trong DataTable đang hiển thị
            foreach (DataRow row in tblKhachHang.Rows)
            {
                string maKH = row["makhach"].ToString().Trim();

                // Câu lệnh kiểm tra xem đã tồn tại trong CSDL chưa
                string sqlCheck = "SELECT * FROM tblkhachhang WHERE makhach = N'" + maKH + "'";

                if (!Function.CheckKey(sqlCheck))
                {
                    // Nếu chưa tồn tại, thêm vào CSDL
                    string sqlInsert = "INSERT INTO tblkhachhang (makhach, tenkhach, sdt, diachi) VALUES " +
                                       "(N'" + row["makhach"] + "', N'" + row["tenkhach"] + "', '" + row["sdt"] + "', N'" + row["diachi"] + "')";
                    Function.runsql(sqlInsert);
                    soDongLuu++;
                }
            }

            if (soDongLuu > 0)
            {
                MessageBox.Show("Đã lưu " + soDongLuu + " khách hàng mới vào CSDL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có khách hàng nào mới cần lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Nạp lại dữ liệu từ CSDL để hiển thị đúng nhất
            Load_DataGridView();
            ResetValues();
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = txtMaKH.Text.Trim();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Xóa chi tiết đơn đặt hàng trước (liên quan tới các đơn của khách)
                    Function.RunSqlDel($@"
                DELETE FROM tblchitietddh 
                WHERE soddh IN (SELECT soddh FROM tbldondathang WHERE makhach = N'{maKH}')");

                    // Xóa đơn đặt hàng
                    Function.RunSqlDel($"DELETE FROM tbldondathang WHERE makhach = N'{maKH}'");

                    // Xóa khách hàng
                    Function.RunSqlDel($"DELETE FROM tblkhachhang WHERE makhach = N'{maKH}'");

                    Load_DataGridView();
                    ResetValues();
                    MessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để sửa!", "Thông báo");
                return;
            }

            string sql = "UPDATE tblkhachhang SET tenkhach=N'" + txtHoten.Text +
                         "', sdt='" + mskSDT.Text +
                         "', diachi=N'" + txtDiaChi.Text +
                         "' WHERE makhach=N'" + txtMaKH.Text + "'";
            Function.runsql(sql);
            Load_DataGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimkiemKH.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                Load_DataGridView();
                return;
            }

            string sql = "SELECT * FROM tblkhachhang WHERE makhach LIKE N'%" + keyword + "%'";
            tblKhachHang = Function.GetDataToTable(sql);
            dataGridView1.DataSource = tblKhachHang;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMaKH.Text = row.Cells["makhach"].Value?.ToString() ?? "";
                    txtHoten.Text = row.Cells["tenkhach"].Value?.ToString() ?? "";
                    txtDiaChi.Text = row.Cells["diachi"].Value?.ToString() ?? "";
                    mskSDT.Text = row.Cells["sdt"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu từ dòng: " + ex.Message);
                }
            }
        }
    }
}
