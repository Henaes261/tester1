using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLXM
{
    public partial class FrmTinhTrang : Form
    {
        private bool isAddingNew = false;
        private string selectedId = "";
        
        public FrmTinhTrang()
        {
            InitializeComponent();
        }

        private void FrmTinhTrang_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }

        private void SetControlState(bool isEditing)
        {
            // Thiết lập trạng thái của các điều khiển
            txtMaTT.Enabled = isEditing && isAddingNew; // Chỉ cho phép nhập mã khi thêm mới
            txtTenTT.Enabled = isEditing;

            // Cập nhật trạng thái các nút
            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing && dgvTinhTrang.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditing && dgvTinhTrang.SelectedRows.Count > 0;
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;
        }
        
        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ CSDL
                string sql = "SELECT maTT, tenTT FROM tbltinhtrang";
                DataTable dt = Function.GetDataToTable(sql);
                
                // Hiển thị dữ liệu trên DataGridView
                dgvTinhTrang.DataSource = dt;
                
                // Định dạng DataGridView
                dgvTinhTrang.Columns[0].HeaderText = "Mã tình trạng";
                dgvTinhTrang.Columns[1].HeaderText = "Tên tình trạng";
                dgvTinhTrang.Columns[0].Width = 150;
                dgvTinhTrang.Columns[1].Width = 450;
                
                // Thiết lập lựa chọn toàn bộ hàng
                dgvTinhTrang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTinhTrang.ReadOnly = true; // Không cho phép chỉnh sửa trực tiếp trên DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ClearInputs()
        {
            txtMaTT.Text = "";
            txtTenTT.Text = "";
        }
        
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaTT.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tình trạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTT.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtTenTT.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tình trạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTT.Focus();
                return false;
            }
            
            return true;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            ClearInputs();
            SetControlState(true);
            txtMaTT.Focus();
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTinhTrang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tình trạng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            isAddingNew = false;
            selectedId = dgvTinhTrang.SelectedRows[0].Cells["maTT"].Value.ToString();
            
            // Hiển thị dữ liệu của hàng được chọn lên các điều khiển
            txtMaTT.Text = selectedId;
            txtTenTT.Text = dgvTinhTrang.SelectedRows[0].Cells["tenTT"].Value.ToString();
            
            // Không cho phép sửa mã
            txtMaTT.Enabled = false;
            txtTenTT.Enabled = true;
            
            SetControlState(true);
            txtTenTT.Focus();
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTinhTrang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tình trạng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            string maTT = dgvTinhTrang.SelectedRows[0].Cells["maTT"].Value.ToString();
            string tenTT = dgvTinhTrang.SelectedRows[0].Cells["tenTT"].Value.ToString();
            
            // Kiểm tra tình trạng có đang được sử dụng không
            string sqlCheck = "SELECT COUNT(*) FROM tbldmhang WHERE maTT = '" + maTT + "'";
            int count = int.Parse(Function.GetFieldValues(sqlCheck));
            if (count > 0)
            {
                MessageBox.Show("Tình trạng này đang được sử dụng trong danh mục hàng, không thể xóa!", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Xác nhận xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tình trạng '" + tenTT + "' không?", 
                                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM tbltinhtrang WHERE maTT = '" + maTT + "'";
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
                string maTT = txtMaTT.Text.Trim();
                string tenTT = txtTenTT.Text.Trim();
                
                if (isAddingNew)
                {
                    // Kiểm tra mã đã tồn tại chưa
                    string sqlCheck = "SELECT COUNT(*) FROM tbltinhtrang WHERE maTT = '" + maTT + "'";
                    int count = int.Parse(Function.GetFieldValues(sqlCheck));
                    if (count > 0)
                    {
                        MessageBox.Show("Mã tình trạng '" + maTT + "' đã tồn tại!", "Thông báo", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaTT.Focus();
                        return;
                    }
                    
                    // Thêm mới
                    string sql = "INSERT INTO tbltinhtrang VALUES('" + maTT + "', N'" + tenTT + "')";
                    Function.runsql(sql);
                    MessageBox.Show("Thêm tình trạng thành công!", "Thông báo", 
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cập nhật
                    string sql = "UPDATE tbltinhtrang SET tenTT = N'" + tenTT + "' WHERE maTT = '" + maTT + "'";
                    Function.runsql(sql);
                    MessageBox.Show("Cập nhật tình trạng thành công!", "Thông báo", 
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
        
        private void dgvTinhTrang_Click(object sender, EventArgs e)
        {
            if (dgvTinhTrang.CurrentRow != null)
            {
                try
                {
                    txtMaTT.Text = dgvTinhTrang.CurrentRow.Cells["maTT"].Value?.ToString() ?? "";
                    txtTenTT.Text = dgvTinhTrang.CurrentRow.Cells["tenTT"].Value?.ToString() ?? "";
                    
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
        
        private void dgvTinhTrang_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dgvTinhTrang.SelectedRows.Count > 0;
            btnXoa.Enabled = dgvTinhTrang.SelectedRows.Count > 0;
        }
    }
}
