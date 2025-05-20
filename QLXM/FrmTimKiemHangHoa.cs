using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLXM
{
    public partial class FrmTimKiemHangHoa : Form
    {
        public FrmTimKiemHangHoa()
        {
            InitializeComponent();
        }

        private void FrmTimKiemHangHoa_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            SetupDataGridView();
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Load combobox Hãng sản xuất
                string sqlHangSX = "SELECT mahangsx, tenhangsx FROM tblhangsx";
                DataTable dtHangSX = Function.GetDataToTable(sqlHangSX);

                // Thêm mục "Tất cả" vào đầu danh sách
                DataRow drHangSX = dtHangSX.NewRow();
                drHangSX["mahangsx"] = "0";
                drHangSX["tenhangsx"] = "Tất cả";
                dtHangSX.Rows.InsertAt(drHangSX, 0);

                cboHangSX.DataSource = dtHangSX;
                cboHangSX.DisplayMember = "tenhangsx";
                cboHangSX.ValueMember = "mahangsx";

                // Load combobox Thể loại
                string sqlTheLoai = "SELECT maloai, tenloai FROM tbltheloai";
                DataTable dtTheLoai = Function.GetDataToTable(sqlTheLoai);

                // Thêm mục "Tất cả" vào đầu danh sách
                DataRow drTheLoai = dtTheLoai.NewRow();
                drTheLoai["maloai"] = "0";
                drTheLoai["tenloai"] = "Tất cả";
                dtTheLoai.Rows.InsertAt(drTheLoai, 0);

                cboTheLoai.DataSource = dtTheLoai;
                cboTheLoai.DisplayMember = "tenloai";
                cboTheLoai.ValueMember = "maloai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            try
            {
                // Thiết lập định dạng cho DataGridView
                dgvHangHoa.AutoGenerateColumns = false;

                // Tạo các cột cho DataGridView
                dgvHangHoa.Columns.Clear();
                dgvHangHoa.Columns.Add("mahang", "Mã hàng");
                dgvHangHoa.Columns.Add("tenhang", "Tên hàng");
                dgvHangHoa.Columns.Add("tenhangsx", "Hãng sản xuất");
                dgvHangHoa.Columns.Add("tenloai", "Thể loại");
                dgvHangHoa.Columns.Add("namsx", "Năm SX");
                dgvHangHoa.Columns.Add("soluong", "Số lượng");
                dgvHangHoa.Columns.Add("dongianhap", "Đơn giá nhập");
                dgvHangHoa.Columns.Add("dongiaban", "Đơn giá bán");

                // Thiết lập độ rộng cột
                dgvHangHoa.Columns["mahang"].Width = 80;
                dgvHangHoa.Columns["tenhang"].Width = 150;
                dgvHangHoa.Columns["tenhangsx"].Width = 120;
                dgvHangHoa.Columns["tenloai"].Width = 100;
                dgvHangHoa.Columns["namsx"].Width = 80;
                dgvHangHoa.Columns["soluong"].Width = 80;
                dgvHangHoa.Columns["dongianhap"].Width = 100;
                dgvHangHoa.Columns["dongiaban"].Width = 100;

                // Định dạng số tiền
                dgvHangHoa.Columns["dongianhap"].DefaultCellStyle.Format = "N0";
                dgvHangHoa.Columns["dongiaban"].DefaultCellStyle.Format = "N0";

                // Canh phải cho các cột số
                dgvHangHoa.Columns["namsx"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHangHoa.Columns["soluong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHangHoa.Columns["dongianhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHangHoa.Columns["dongiaban"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Không cho phép người dùng thêm dòng mới
                dgvHangHoa.AllowUserToAddRows = false;
                // Không cho phép chỉnh sửa dòng
                dgvHangHoa.ReadOnly = true;
                // Cho phép chọn cả dòng
                dgvHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Load dữ liệu
                LoadAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thiết lập DataGridView: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllProducts()
        {
            try
            {
                string sql = @"SELECT h.mahang, h.tenhang, hsx.tenhangsx, tl.tenloai, h.namsx, 
                                h.soluong, h.dongianhap, h.dongiaban
                               FROM tbldmhang h
                               INNER JOIN tblhangsx hsx ON h.mahangsx = hsx.mahangsx
                               INNER JOIN tbltheloai tl ON h.maloai = tl.maloai";

                DataTable dt = Function.GetDataToTable(sql);

                // Xóa dữ liệu cũ trong DataGridView
                dgvHangHoa.Rows.Clear();

                // Thêm dữ liệu vào DataGridView
                foreach (DataRow row in dt.Rows)
                {
                    int index = dgvHangHoa.Rows.Add();
                    dgvHangHoa.Rows[index].Cells["mahang"].Value = row["mahang"];
                    dgvHangHoa.Rows[index].Cells["tenhang"].Value = row["tenhang"];
                    dgvHangHoa.Rows[index].Cells["tenhangsx"].Value = row["tenhangsx"];
                    dgvHangHoa.Rows[index].Cells["tenloai"].Value = row["tenloai"];
                    dgvHangHoa.Rows[index].Cells["namsx"].Value = row["namsx"];
                    dgvHangHoa.Rows[index].Cells["soluong"].Value = row["soluong"];
                    dgvHangHoa.Rows[index].Cells["dongianhap"].Value = row["dongianhap"];
                    dgvHangHoa.Rows[index].Cells["dongiaban"].Value = row["dongiaban"];
                }

                // Cập nhật số lượng sản phẩm
                lblTongSo.Text = "Tổng số: " + dt.Rows.Count + " sản phẩm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo câu truy vấn tìm kiếm cơ bản
                string sql = @"SELECT h.mahang, h.tenhang, hsx.tenhangsx, tl.tenloai, h.namsx, 
                               h.soluong, h.dongianhap, h.dongiaban
                               FROM tbldmhang h
                               INNER JOIN tblhangsx hsx ON h.mahangsx = hsx.mahangsx
                               INNER JOIN tbltheloai tl ON h.maloai = tl.maloai
                               WHERE 1=1";

                // Thêm điều kiện tìm kiếm theo mã hàng
                if (!string.IsNullOrEmpty(txtMaHang.Text))
                {
                    sql += " AND h.mahang LIKE '%" + txtMaHang.Text.Trim() + "%'";
                }

                // Thêm điều kiện tìm kiếm theo tên hàng
                if (!string.IsNullOrEmpty(txtTenHang.Text))
                {
                    sql += " AND h.tenhang LIKE N'%" + txtTenHang.Text.Trim() + "%'";
                }

                // Thêm điều kiện tìm kiếm theo hãng sản xuất
                if (cboHangSX.SelectedIndex > 0) // 0 là "Tất cả"
                {
                    sql += " AND h.mahangsx = '" + cboHangSX.SelectedValue.ToString() + "'";
                }

                // Thêm điều kiện tìm kiếm theo thể loại
                if (cboTheLoai.SelectedIndex > 0) // 0 là "Tất cả"
                {
                    sql += " AND h.maloai = '" + cboTheLoai.SelectedValue.ToString() + "'";
                }

                // Truy vấn dữ liệu
                DataTable dt = Function.GetDataToTable(sql);

                // Xóa dữ liệu cũ trong DataGridView
                dgvHangHoa.Rows.Clear();

                // Thêm dữ liệu vào DataGridView
                foreach (DataRow row in dt.Rows)
                {
                    int index = dgvHangHoa.Rows.Add();
                    dgvHangHoa.Rows[index].Cells["mahang"].Value = row["mahang"];
                    dgvHangHoa.Rows[index].Cells["tenhang"].Value = row["tenhang"];
                    dgvHangHoa.Rows[index].Cells["tenhangsx"].Value = row["tenhangsx"];
                    dgvHangHoa.Rows[index].Cells["tenloai"].Value = row["tenloai"];
                    dgvHangHoa.Rows[index].Cells["namsx"].Value = row["namsx"];
                    dgvHangHoa.Rows[index].Cells["soluong"].Value = row["soluong"];
                    dgvHangHoa.Rows[index].Cells["dongianhap"].Value = row["dongianhap"];
                    dgvHangHoa.Rows[index].Cells["dongiaban"].Value = row["dongiaban"];
                }

                // Cập nhật số lượng sản phẩm tìm được
                lblTongSo.Text = "Tổng số: " + dt.Rows.Count + " sản phẩm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Code in báo cáo sẽ được thêm sau
            MessageBox.Show("Chức năng in báo cáo đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
