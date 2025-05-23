using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXM
{
    public partial class FrmHangHoa : Form
    {
        public FrmHangHoa()
        {
            InitializeComponent();
        }

        private void FrmHangHoa_Load(object sender, EventArgs e)
        {
            Function.FillCombo("SELECT maloai, tenloai FROM tbltheloai", cboMaLoai, "maloai", "tenloai");
            Function.FillCombo("SELECT mahangsx, tenhangsx FROM tblhangsx", cboMaHangSX, "mahangsx", "tenhangsx");
            Function.FillCombo("SELECT mamau, tenmau FROM tblmausac", cboMaMau, "mamau", "tenmau");
            Function.FillCombo("SELECT maphanh, tenphanh FROM tblphanhxe", cboMaPhanh, "maphanh", "tenphanh");
            Function.FillCombo("SELECT madongco, tendongco FROM tbldongco", cboMaDongCo, "madongco", "tendongco");
            Function.FillCombo("SELECT manuocsx, tennuocsx FROM tblnuocsx", cboMaNuocSX, "manuocsx", "tennuocsx");
            Function.FillCombo("SELECT maTT, tenTT FROM tbltinhtrang", cboMaTT, "maTT", "tenTT");

            txtMaHang.Enabled = false; 
            txtSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            load_dgvHangHoa();
            Resetvalue();
        }
        DataTable tbldmhang;
        private void load_dgvHangHoa()
        {
            string sql;
            sql = "SELECT mahang, tenhang, namsx, maloai, mahangsx, mamau, maphanh, madongco, manuocsx, maTT, dungtichbinhxang, soluong, dongianhap, dongiaban, thoigianbaohanh FROM tbldmhang";
            tbldmhang = Function.GetDataToTable(sql);
            dgvHangHoa.DataSource = tbldmhang;

            dgvHangHoa.Columns[0].HeaderText = "Mã hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên hàng";
            dgvHangHoa.Columns[2].HeaderText = "Năm sản xuất";
            dgvHangHoa.Columns[3].HeaderText = "Mã loại";
            dgvHangHoa.Columns[4].HeaderText = "Mã hãng sản xuất";
            dgvHangHoa.Columns[5].HeaderText = "Mã màu";
            dgvHangHoa.Columns[6].HeaderText = "Mã phanh";
            dgvHangHoa.Columns[7].HeaderText = "Mã động cơ";
            dgvHangHoa.Columns[8].HeaderText = "Mã nước sản xuất";
            dgvHangHoa.Columns[9].HeaderText = "Mã tình trạng";
            dgvHangHoa.Columns[10].HeaderText = "Dung tích bình xăng";
            dgvHangHoa.Columns[11].HeaderText = "Số lượng";
            dgvHangHoa.Columns[12].HeaderText = "Đơn giá nhập";
            dgvHangHoa.Columns[13].HeaderText = "Đơn giá bán";
            dgvHangHoa.Columns[14].HeaderText = "Thời gian bảo hành";
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Resetvalue()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtNamSX.Text = "";
            txtDTBX.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtTGBH.Text = "";
            cboMaLoai.Text = "";
            cboMaHangSX.Text = "";
            cboMaMau.Text = "";
            cboMaPhanh.Text = "";
            cboMaDongCo.Text = "";
            cboMaNuocSX.Text = "";
            cboMaTT.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void dgvHangHoa_Click(object sender, EventArgs e)
        {
            txtMaHang.Text = dgvHangHoa.CurrentRow.Cells["mahang"].Value.ToString();
            txtTenHang.Text = dgvHangHoa.CurrentRow.Cells["tenhang"].Value.ToString();
            txtNamSX.Text = dgvHangHoa.CurrentRow.Cells["namsx"].Value.ToString();
            txtDTBX.Text = dgvHangHoa.CurrentRow.Cells["dungtichbinhxang"].Value.ToString();
            txtSoLuong.Text = dgvHangHoa.CurrentRow.Cells["soluong"].Value.ToString();
            txtDonGiaNhap.Text = dgvHangHoa.CurrentRow.Cells["dongianhap"].Value.ToString();
            txtDonGiaBan.Text = dgvHangHoa.CurrentRow.Cells["dongiaban"].Value.ToString();
            txtTGBH.Text = dgvHangHoa.CurrentRow.Cells["thoigianbaohanh"].Value.ToString();

            string ma;
            ma = dgvHangHoa.CurrentRow.Cells["maloai"].Value.ToString();
            cboMaLoai.Text = Function.GetFieldValues("SELECT tenloai FROM tbltheloai WHERE maloai = N'" + ma + "'");
            ma = dgvHangHoa.CurrentRow.Cells["mahangsx"].Value.ToString();
            cboMaHangSX.Text = Function.GetFieldValues("SELECT tenhangsx FROM tblhangsx WHERE mahangsx = N'" + ma + "'");
            ma = dgvHangHoa.CurrentRow.Cells["mamau"].Value.ToString();
            cboMaMau.Text = Function.GetFieldValues("SELECT tenmau FROM tblmausac WHERE mamau = N'" + ma + "'");
            ma = dgvHangHoa.CurrentRow.Cells["maphanh"].Value.ToString();
            cboMaPhanh.Text = Function.GetFieldValues("SELECT tenphanh FROM tblphanhxe WHERE maphanh = N'" + ma + "'");
            ma = dgvHangHoa.CurrentRow.Cells["madongco"].Value.ToString();
            cboMaDongCo.Text = Function.GetFieldValues("SELECT tendongco FROM tbldongco WHERE madongco = N'" + ma + "'");
            ma = dgvHangHoa.CurrentRow.Cells["manuocsx"].Value.ToString();
            cboMaNuocSX.Text = Function.GetFieldValues("SELECT tennuocsx FROM tblnuocsx WHERE manuocsx = N'" + ma + "'");
            ma = dgvHangHoa.CurrentRow.Cells["maTT"].Value.ToString();
            cboMaTT.Text = Function.GetFieldValues("SELECT tentt FROM tbltinhtrang WHERE maTT = N'" + ma + "'");
            
            txtAnh.Text = Function.GetFieldValues("SELECT anh FROM tbldmhang WHERE mahang = N'" + txtMaHang.Text + "'");

            string fileName = txtAnh.Text;
            string fullPath = Path.Combine(@"C:\Users\TTT\Downloads\tester1-master\tester1-master\QLXM\ảnh", fileName);

            if (File.Exists(fullPath))
            {
                try
                {
                    if (picAnh.Image != null)
                        picAnh.Image.Dispose();
                    picAnh.Image = Image.FromFile(fullPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở ảnh: " + ex.Message);
                }
            }
            else
            {
                picAnh.Image = null;
                MessageBox.Show("Ảnh không tồn tại: " + fullPath);
            }

            txtMaHang.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "Hình ảnh (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif|Tất cả tập tin (*.*)|*.*";
            a.FilterIndex = 1;

            // Kiểm tra thư mục ảnh tồn tại
            string imageFolder = @"C:\Users\Admin\Downloads\QLXM\ảnh";
            if (Directory.Exists(imageFolder))
                a.InitialDirectory = imageFolder;
            else
                a.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            a.Title = "Chọn ảnh để hiển thị";

            if (a.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Giải phóng ảnh cũ nếu có
                    if (picAnh.Image != null)
                        picAnh.Image.Dispose();

                    // Hiển thị ảnh
                    picAnh.Image = Image.FromFile(a.FileName);

                    // Lưu chỉ tên file vào textbox để lưu vào database
                    txtAnh.Text = Path.GetFileName(a.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở ảnh. Chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Resetvalue();
            load_dgvHangHoa();
            txtMaHang.Enabled = true;
            txtMaHang.Focus();
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //textbox
            if (txtMaHang.Text.Trim() == "")
            {
                MessageBox.Show("Mã hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim() == "")
            {
                MessageBox.Show("Tên hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            if (txtNamSX.Text.Trim() == "")
            {
                MessageBox.Show("Năm sản xuất không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNamSX.Focus();
                return;
            }
            if ((Function.ktSoNguyen(txtNamSX.Text.Trim()) == false) || (Convert.ToInt32(txtNamSX.Text) > DateTime.Today.Year)) 
            {
                MessageBox.Show("Hãy nhập lại năm sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNamSX.Focus();
                txtNamSX.Text = "";
                return;
            }
            if (txtDTBX.Text.Trim() == "")
            {
                MessageBox.Show("Dung tích bình xăng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDTBX.Focus();
                return;
            }
            if (Function.ktSoNguyen(txtDTBX.Text.Trim()) == false || Convert.ToInt32(txtDTBX.Text) < 0)
            {
                MessageBox.Show("Hãy nhập lại dung tích bình xăng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDTBX.Focus();
                txtDTBX.Text = "";
                return;
            }
            if (txtTGBH.Text.Trim() == "")
            {
                MessageBox.Show("Thời gian bảo hành không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTGBH.Focus();
                return;
            }
            if (Function.ktSoThuc(txtTGBH.Text.Trim()) == false)
            {
                MessageBox.Show("Hãy nhập lại thời gian bảo hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTGBH.Focus();
                txtTGBH.Text = "";
                return;
            }
            //combobox
            if (cboMaLoai.Text.Trim() == "")
            {
                MessageBox.Show("Mã loại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaLoai.Focus();
                return;
            }
            if (cboMaHangSX.Text.Trim() == "")
            {
                MessageBox.Show("Mã hãng sản xuất không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHangSX.Focus();
                return;
            }
            if (cboMaMau.Text.Trim() == "")
            {
                MessageBox.Show("Mã màu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaMau.Focus();
                return;
            }
            if (cboMaPhanh.Text.Trim() == "")
            {
                MessageBox.Show("Mã phanh không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaPhanh.Focus();
                return;
            }
            if (cboMaDongCo.Text.Trim() == "")
            {
                MessageBox.Show("Mã động cơ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaDongCo.Focus();
                return;
            }
            if (cboMaNuocSX.Text.Trim() == "")
            {
                MessageBox.Show("Mã nước sản xuất không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNuocSX.Focus();
                return;
            }
            if (cboMaTT.Text.Trim() == "")
            {
                MessageBox.Show("Mã tình trạng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaTT.Focus();
                return;
            }
            //ảnh
            if (txtAnh.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn ảnh hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            //Kiểm tra mã hàng trùng
            string sql;
            sql = "SELECT mahang FROM tbldmhang WHERE mahang = N'" + txtMaHang.Text.Trim() + "'";
            if (Function.CheckKey(sql) == true)
            {
                MessageBox.Show("Mã hàng đã tồn tại, yêu cầu nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                txtMaHang.Text = "";
                return;
            }

            sql = "INSERT INTO tbldmhang " +
                "(mahang, tenhang, namsx, maloai, mahangsx, mamau, maphanh, madongco, manuocsx, maTT, dungtichbinhxang, anh, soluong, dongianhap, dongiaban, thoigianbaohanh) " +
                "VALUES (" +
                "N'" + txtMaHang.Text.Trim() + "', " +
                "N'" + txtTenHang.Text.Trim() + "', " +
                "N'" + txtNamSX.Text.Trim() + "', " +
                "N'" + cboMaLoai.SelectedValue.ToString() + "', " +
                "N'" + cboMaHangSX.SelectedValue.ToString() + "', " +
                "N'" + cboMaMau.SelectedValue.ToString() + "', " +
                "N'" + cboMaPhanh.SelectedValue.ToString() + "', " +
                "N'" + cboMaDongCo.SelectedValue.ToString() + "', " +
                "N'" + cboMaNuocSX.SelectedValue.ToString() + "', " +
                "N'" + cboMaTT.SelectedValue.ToString() + "', " +
                txtDTBX.Text.Trim() + ", " +
                "N'" + txtAnh.Text.Trim() + "', " +
                txtSoLuong.Text.Trim() + ", " +
                txtDonGiaNhap.Text.Trim() + ", " +
                txtDonGiaBan.Text.Trim() + ", " +
                txtTGBH.Text.Trim() +
                ");";

            Function.runsql(sql);
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            load_dgvHangHoa(); 
            Resetvalue();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaHang.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn bản ghi để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE tbldmhang WHERE mahang = N'" + txtMaHang.Text + "'";
                Function.runsql(sql);
                Resetvalue();
                load_dgvHangHoa();
                btnBoQua.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //textbox
            if (txtMaHang.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn bản ghi để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim() == "")
            {
                MessageBox.Show("Tên hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            if (txtNamSX.Text.Trim() == "")
            {
                MessageBox.Show("Năm sản xuất không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNamSX.Focus();
                return;
            }
            if ((Function.ktSoNguyen(txtNamSX.Text.Trim()) == false) || (Convert.ToInt32(txtNamSX.Text) > DateTime.Today.Year))
            {
                MessageBox.Show("Hãy nhập lại năm sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNamSX.Focus();
                txtNamSX.Text = "";
                return;
            }
            if (txtDTBX.Text.Trim() == "")
            {
                MessageBox.Show("Dung tích bình xăng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDTBX.Focus();
                return;
            }
            if (Function.ktSoNguyen(txtDTBX.Text.Trim()) == false || Convert.ToInt32(txtDTBX.Text) < 0)
            {
                MessageBox.Show("Hãy nhập lại dung tích bình xăng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDTBX.Focus();
                txtDTBX.Text = "";
                return;
            }
            if (txtTGBH.Text.Trim() == "")
            {
                MessageBox.Show("Thời gian bảo hành không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTGBH.Focus();
                return;
            }
            if (Function.ktSoThuc(txtTGBH.Text.Trim()) == false)
            {
                MessageBox.Show("Hãy nhập lại thời gian bảo hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTGBH.Focus();
                txtTGBH.Text = "";
                return;
            }
            //combobox
            if (cboMaLoai.Text.Trim() == "")
            {
                MessageBox.Show("Mã loại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaLoai.Focus();
                return;
            }
            if (cboMaHangSX.Text.Trim() == "")
            {
                MessageBox.Show("Mã hãng sản xuất không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHangSX.Focus();
                return;
            }
            if (cboMaMau.Text.Trim() == "")
            {
                MessageBox.Show("Mã màu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaMau.Focus();
                return;
            }
            if (cboMaPhanh.Text.Trim() == "")
            {
                MessageBox.Show("Mã phanh không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaPhanh.Focus();
                return;
            }
            if (cboMaDongCo.Text.Trim() == "")
            {
                MessageBox.Show("Mã động cơ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaDongCo.Focus();
                return;
            }
            if (cboMaNuocSX.Text.Trim() == "")
            {
                MessageBox.Show("Mã nước sản xuất không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNuocSX.Focus();
                return;
            }
            if (cboMaTT.Text.Trim() == "")
            {
                MessageBox.Show("Mã tình trạng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaTT.Focus();
                return;
            }
            //ảnh
            if (txtAnh.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn ảnh hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }

            string sql;
            sql = "UPDATE tbldmhang SET " +
                "tenhang = N'" + txtTenHang.Text.Trim() + "', " +
                "namsx = N'" + txtNamSX.Text.Trim() + "', " +
                "maloai = N'" + cboMaLoai.SelectedValue.ToString() + "', " +
                "mahangsx = N'" + cboMaHangSX.SelectedValue.ToString() + "', " +
                "mamau = N'" + cboMaMau.SelectedValue.ToString() + "', " +
                "maphanh = N'" + cboMaPhanh.SelectedValue.ToString() + "', " +
                "madongco = N'" + cboMaDongCo.SelectedValue.ToString() + "', " +
                "manuocsx = N'" + cboMaNuocSX.SelectedValue.ToString() + "', " +
                "maTT = N'" + cboMaTT.SelectedValue.ToString() + "', " +
                "dungtichbinhxang = " + txtDTBX.Text.Trim() + ", " +
                "anh = N'" + txtAnh.Text.Trim() + "', " +
                "soluong = " + txtSoLuong.Text.Trim() + ", " +
                "dongianhap = " + txtDonGiaNhap.Text.Trim() + ", " +
                "dongiaban = " + txtDonGiaBan.Text.Trim() + ", " +
                "thoigianbaohanh = " + txtTGBH.Text.Trim() + " " +
                "WHERE mahang = N'" + txtMaHang.Text.Trim() + "';";

            Function.runsql(sql);
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Resetvalue();
            load_dgvHangHoa();
            btnBoQua.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            Resetvalue();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaHang.Enabled = false;
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

