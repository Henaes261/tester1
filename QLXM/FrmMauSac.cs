using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLXM
{
    public partial class FrmMauSac : Form
    {
        private bool isAddingNew = false;
        private string selectedId = "";
        
        public FrmMauSac()
        {
            InitializeComponent();
        }

        private void FrmMauSac_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }

        private void SetControlState(bool isEditing)
        {
            // Thiết lập trạng thái của các điều khiển
            txtMaMau.Enabled = isEditing && isAddingNew; // Chỉ cho phép nhập mã khi thêm mới
            txtTenMau.Enabled = isEditing;

            // Cập nhật trạng thái các nút
            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing && dgvMauSac.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditing && dgvMauSac.SelectedRows.Count > 0;
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;
        }
        
        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ CSDL
                string sql = "SELECT mamau, tenmau FROM tblmausac";
                DataTable dt = Function.GetDataToTable(sql);
                
                // Hiển thị dữ liệu trên DataGridView
                dgvMauSac.DataSource = dt;
                
                // Định dạng DataGridView
                dgvMauSac.Columns[0].HeaderText = "Mã màu";
                dgvMauSac.Columns[1].HeaderText = "Tên màu";
                dgvMauSac.Columns[0].Width = 100;
                dgvMauSac.Columns[1].Width = 200;
                
                // Thiết lập lựa chọn toàn bộ hàng
                dgvMauSac.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ClearInputs()
        {
            txtMaMau.Text = "";
            txtTenMau.Text = "";
        }
        
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaMau.Text))
            {
                MessageBox.Show("Vui lòng nhập mã màu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMau.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtTenMau.Text))
            {
                MessageBox.Show("Vui lòng nhập tên màu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMau.Focus();
                return false;
            }
            
            return true;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            ClearInputs();
            SetControlState(true);
            txtMaMau.Focus();
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvMauSac.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn màu sắc cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            isAddingNew = false;
            selectedId = dgvMauSac.SelectedRows[0].Cells["mamau"].Value.ToString();
            
            // Hiển thị dữ liệu của hàng được chọn lên các điều khiển
            txtMaMau.Text = selectedId;
            txtTenMau.Text = dgvMauSac.SelectedRows[0].Cells["tenmau"].Value.ToString();
            
            // Không cho phép sửa mã
            txtMaMau.Enabled = false;
            txtTenMau.Enabled = true;
            
            SetControlState(true);
            txtTenMau.Focus();
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMauSac.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn màu sắc cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            string maMau = dgvMauSac.SelectedRows[0].Cells["mamau"].Value.ToString();
            string tenMau = dgvMauSac.SelectedRows[0].Cells["tenmau"].Value.ToString();
            
            // Kiểm tra màu sắc có đang được sử dụng không
            string sqlCheck = "SELECT COUNT(*) FROM tbldmhang WHERE mamau = '" + maMau + "'";
            int count = int.Parse(Function.GetFieldValues(sqlCheck));
            if (count > 0)
            {
                MessageBox.Show("Màu sắc này đang được sử dụng trong danh mục hàng, không thể xóa!", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Xác nhận xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa màu sắc '" + tenMau + "' không?", 
                                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblmausac WHERE mamau = '" + maMau + "'";
                Function.RunSqlDel(sql);
                LoadData();
                ClearInputs();
            }
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;
            
            try
            {
                string maMau = txtMaMau.Text.Trim();
                string tenMau = txtTenMau.Text.Trim();
                
                if (isAddingNew)
                {
                    // Kiểm tra mã đã tồn tại chưa
                    string sqlCheck = "SELECT COUNT(*) FROM tblmausac WHERE mamau = '" + maMau + "'";
                    int count = int.Parse(Function.GetFieldValues(sqlCheck));
                    if (count > 0)
                    {
                        MessageBox.Show("Mã màu '" + maMau + "' đã tồn tại!", "Thông báo", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaMau.Focus();
                        return;
                    }
                    
                    // Thêm mới
                    string sql = "INSERT INTO tblmausac VALUES('" + maMau + "', N'" + tenMau + "')";
                    Function.runsql(sql);
                    MessageBox.Show("Thêm màu sắc thành công!", "Thông báo", 
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cập nhật
                    string sql = "UPDATE tblmausac SET tenmau = N'" + tenMau + "' WHERE mamau = '" + maMau + "'";
                    Function.runsql(sql);
                    MessageBox.Show("Cập nhật màu sắc thành công!", "Thông báo", 
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                LoadData();
                ClearInputs();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInputs();
            isAddingNew = false;
            SetControlState(false);
        }
        
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void dgvMauSac_Click(object sender, EventArgs e)
        {
            if (dgvMauSac.CurrentRow != null)
            {
                try
                {
                    txtMaMau.Text = dgvMauSac.CurrentRow.Cells["mamau"].Value?.ToString() ?? "";
                    txtTenMau.Text = dgvMauSac.CurrentRow.Cells["tenmau"].Value?.ToString() ?? "";
                    
                    // Cập nhật trạng thái nút
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message, "Lỗi", 
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMauSac_SelectionChanged(object sender, EventArgs e)
        {
            // Cập nhật trạng thái nút Sửa và Xóa khi người dùng chọn hàng
            btnSua.Enabled = dgvMauSac.SelectedRows.Count > 0;
            btnXoa.Enabled = dgvMauSac.SelectedRows.Count > 0;
            
            if (dgvMauSac.SelectedRows.Count > 0)
            {
                // Hiển thị thông tin từ dòng được chọn lên các textbox
                txtMaMau.Text = dgvMauSac.SelectedRows[0].Cells["mamau"].Value?.ToString() ?? "";
                txtTenMau.Text = dgvMauSac.SelectedRows[0].Cells["tenmau"].Value?.ToString() ?? "";
            }
        }
    }
}
