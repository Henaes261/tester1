using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace QLXM
{
    public partial class FrmBaoCaoKetQuaHoatDongKinhDoanh : Form
    {
        public FrmBaoCaoKetQuaHoatDongKinhDoanh()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoKetQuaHoatDongKinhDoanh_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            
            // Thiết lập DataGridView
            SetupDataGridView();
        }
        
        private void SetupDataGridView()
        {
            try
            {
                // Thiết lập định dạng cho DataGridView
                dgvBaoCaoKQKD.AutoGenerateColumns = false;
                
                // Tạo các cột cho DataGridView
                dgvBaoCaoKQKD.Columns.Clear();
                dgvBaoCaoKQKD.Columns.Add("NgayGD", "Ngày");
                dgvBaoCaoKQKD.Columns.Add("DoanhThu", "Doanh thu");
                dgvBaoCaoKQKD.Columns.Add("ChiPhi", "Chi phí");
                dgvBaoCaoKQKD.Columns.Add("LoiNhuan", "Lợi nhuận");
                
                // Thiết lập độ rộng cột
                dgvBaoCaoKQKD.Columns["NgayGD"].Width = 100;
                dgvBaoCaoKQKD.Columns["DoanhThu"].Width = 200;
                dgvBaoCaoKQKD.Columns["ChiPhi"].Width = 200;
                dgvBaoCaoKQKD.Columns["LoiNhuan"].Width = 200;
                
                // Định dạng hiển thị
                dgvBaoCaoKQKD.Columns["NgayGD"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvBaoCaoKQKD.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                dgvBaoCaoKQKD.Columns["ChiPhi"].DefaultCellStyle.Format = "N0";
                dgvBaoCaoKQKD.Columns["LoiNhuan"].DefaultCellStyle.Format = "N0";
                
                // Canh phải cho các cột số
                dgvBaoCaoKQKD.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBaoCaoKQKD.Columns["ChiPhi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBaoCaoKQKD.Columns["LoiNhuan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                
                // Không cho phép người dùng thêm dòng mới
                dgvBaoCaoKQKD.AllowUserToAddRows = false;
                // Không cho phép chỉnh sửa dòng
                dgvBaoCaoKQKD.ReadOnly = true;
                // Cho phép chọn cả dòng
                dgvBaoCaoKQKD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thiết lập DataGridView: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Đảm bảo kết nối đã được mở và khởi tạo đúng
                Function.connect();

                // Kiểm tra ngày hợp lệ
                if (dtpTuNgay.Value > dtpDenNgay.Value)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // Lấy tham số tìm kiếm
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                
                // Thay đổi cách tiếp cận - không dùng DataAdapter riêng lẻ mà dùng cách đơn giản hơn
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("NgayGD", typeof(DateTime));
                dtResult.Columns.Add("DoanhThu", typeof(decimal));
                dtResult.Columns.Add("ChiPhi", typeof(decimal));
                dtResult.Columns.Add("LoiNhuan", typeof(decimal));
                
                // Tạo dictionary để lưu doanh thu
                Dictionary<DateTime, decimal> doanhThuByDate = new Dictionary<DateTime, decimal>();
                Dictionary<DateTime, decimal> chiPhiByDate = new Dictionary<DateTime, decimal>(); 
                
                // Lấy dữ liệu doanh thu
                string queryDoanhThu = @"
                    SELECT CONVERT(DATE, NgayMua) AS NgayGD, SUM(TongTien) AS DoanhThu 
                    FROM tbldondathang 
                    WHERE NgayMua BETWEEN @TuNgay AND @DenNgay 
                    GROUP BY CONVERT(DATE, NgayMua)";

                using (SqlCommand cmdDoanhThu = new SqlCommand(queryDoanhThu, Function.conn))
                {
                    cmdDoanhThu.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmdDoanhThu.Parameters.AddWithValue("@DenNgay", denNgay);

                    using (SqlDataReader reader = cmdDoanhThu.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime ngayGD = Convert.ToDateTime(reader["NgayGD"]).Date;
                            decimal doanhThu = Convert.ToDecimal(reader["DoanhThu"]);
                            doanhThuByDate[ngayGD] = doanhThu;
                        }
                    }
                }

                // Lấy dữ liệu chi phí
                string queryChiPhi = @"
                    SELECT CONVERT(DATE, NgayNhap) AS NgayGD, SUM(TongTien) AS ChiPhi 
                    FROM tblhoadonnhap 
                    WHERE NgayNhap BETWEEN @TuNgay AND @DenNgay 
                    GROUP BY CONVERT(DATE, NgayNhap)";

                using (SqlCommand cmdChiPhi = new SqlCommand(queryChiPhi, Function.conn))
                {
                    cmdChiPhi.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmdChiPhi.Parameters.AddWithValue("@DenNgay", denNgay);

                    using (SqlDataReader reader = cmdChiPhi.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime ngayGD = Convert.ToDateTime(reader["NgayGD"]).Date;
                            decimal chiPhi = Convert.ToDecimal(reader["ChiPhi"]);
                            chiPhiByDate[ngayGD] = chiPhi;
                        }
                    }
                }

                // Tạo danh sách ngày từ ngày bắt đầu đến ngày kết thúc
                for (DateTime date = tuNgay.Date; date <= denNgay.Date; date = date.AddDays(1))
                {
                    DataRow newRow = dtResult.NewRow();
                    newRow["NgayGD"] = date;
                    
                    // Lấy doanh thu cho ngày
                    newRow["DoanhThu"] = doanhThuByDate.ContainsKey(date) ? doanhThuByDate[date] : 0m;
                    
                    // Lấy chi phí cho ngày
                    newRow["ChiPhi"] = chiPhiByDate.ContainsKey(date) ? chiPhiByDate[date] : 0m;
                    
                    // Tính lợi nhuận
                    newRow["LoiNhuan"] = Convert.ToDecimal(newRow["DoanhThu"]) - Convert.ToDecimal(newRow["ChiPhi"]);
                    
                    dtResult.Rows.Add(newRow);
                }
                
                // Hiển thị kết quả trong DataGridView
                dgvBaoCaoKQKD.Rows.Clear();
                foreach (DataRow row in dtResult.Rows)
                {
                    int index = dgvBaoCaoKQKD.Rows.Add();
                    dgvBaoCaoKQKD.Rows[index].Cells["NgayGD"].Value = row["NgayGD"];
                    dgvBaoCaoKQKD.Rows[index].Cells["DoanhThu"].Value = row["DoanhThu"];
                    dgvBaoCaoKQKD.Rows[index].Cells["ChiPhi"].Value = row["ChiPhi"];
                    dgvBaoCaoKQKD.Rows[index].Cells["LoiNhuan"].Value = row["LoiNhuan"];
                }
                
                // Tính tổng kết
                decimal tongDoanhThu = dtResult.AsEnumerable().Sum(r => Convert.ToDecimal(r["DoanhThu"]));
                decimal tongChiPhi = dtResult.AsEnumerable().Sum(r => Convert.ToDecimal(r["ChiPhi"]));
                decimal tongLoiNhuan = dtResult.AsEnumerable().Sum(r => Convert.ToDecimal(r["LoiNhuan"]));
                
                // Hiển thị tổng kết
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");
                txtTongChiPhi.Text = tongChiPhi.ToString("N0");
                txtTongLoiNhuan.Text = tongLoiNhuan.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm dữ liệu: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvBaoCaoKQKD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in báo cáo!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // Code in báo cáo sẽ được thêm sau
            MessageBox.Show("Chức năng in báo cáo đang được phát triển!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
