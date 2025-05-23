using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Printing;

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

            try
            {
                // Tạo đối tượng PrintDocument để điều khiển quá trình in
                PrintDocument printDocument = new PrintDocument();

                // Thiết lập giấy A4
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                printDocument.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

                // Đăng ký sự kiện để vẽ nội dung khi in
                printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

                // Tạo đối tượng PrintPreviewDialog để hiển thị xem trước
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument;

                // Thiết lập các thuộc tính của cửa sổ xem trước
                printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
                printPreviewDialog.ClientSize = new Size(800, 600);

                // Thiết lập kích thước cửa sổ xem trước
                printPreviewDialog.AutoScaleDimensions = new SizeF(6F, 13F);
                printPreviewDialog.AutoScaleMode = AutoScaleMode.Font;

                // Hiển thị cửa sổ xem trước
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị bản xem trước: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm phương thức PrintPage để vẽ nội dung khi in
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Thiết lập font chữ và màu sắc
                Font titleFont = new Font("Arial", 18, FontStyle.Bold);
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                Font normalFont = new Font("Arial", 12);
                Font boldFont = new Font("Arial", 12, FontStyle.Bold);
                Brush brush = Brushes.Black;

                // Thiết lập vị trí bắt đầu
                float y = 50;
                float x = 50;
                float width = e.PageBounds.Width - 100;

                // In tiêu đề báo cáo
                string title = "BÁO CÁO KẾT QUẢ HOẠT ĐỘNG KINH DOANH";
                e.Graphics.DrawString(title, titleFont, brush, new RectangleF(x, y, width, 30), new StringFormat() { Alignment = StringAlignment.Center });
                y += 40;

                // In thông tin thời gian báo cáo
                string period = "Từ ngày: " + dtpTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày: " + dtpDenNgay.Value.ToString("dd/MM/yyyy");
                e.Graphics.DrawString(period, headerFont, brush, new RectangleF(x, y, width, 25), new StringFormat() { Alignment = StringAlignment.Center });
                y += 40;

                // Thiết lập chiều rộng cột
                float dateWidth = 100;
                float numberWidth = (width - dateWidth) / 3;

                // In tiêu đề cột
                e.Graphics.DrawString("Ngày", boldFont, brush, x, y);
                e.Graphics.DrawString("Doanh Thu", boldFont, brush, x + dateWidth, y);
                e.Graphics.DrawString("Chi Phí", boldFont, brush, x + dateWidth + numberWidth, y);
                e.Graphics.DrawString("Lợi Nhuận", boldFont, brush, x + dateWidth + 2 * numberWidth, y);
                y += 25;

                // Vẽ đường kẻ ngang
                e.Graphics.DrawLine(Pens.Black, x, y - 5, x + width, y - 5);

                // In dữ liệu từ DataGridView
                foreach (DataGridViewRow row in dgvBaoCaoKQKD.Rows)
                {
                    if (row.Cells["NgayGD"].Value != null)
                    {
                        // Ngày
                        DateTime ngay = Convert.ToDateTime(row.Cells["NgayGD"].Value);
                        e.Graphics.DrawString(ngay.ToString("dd/MM/yyyy"), normalFont, brush, x, y);

                        // Doanh thu
                        decimal doanhThu = Convert.ToDecimal(row.Cells["DoanhThu"].Value);
                        e.Graphics.DrawString(doanhThu.ToString("N0"), normalFont, brush, x + dateWidth + numberWidth - e.Graphics.MeasureString(doanhThu.ToString("N0"), normalFont).Width, y);

                        // Chi phí
                        decimal chiPhi = Convert.ToDecimal(row.Cells["ChiPhi"].Value);
                        e.Graphics.DrawString(chiPhi.ToString("N0"), normalFont, brush, x + dateWidth + 2 * numberWidth - e.Graphics.MeasureString(chiPhi.ToString("N0"), normalFont).Width, y);

                        // Lợi nhuận
                        decimal loiNhuan = Convert.ToDecimal(row.Cells["LoiNhuan"].Value);
                        e.Graphics.DrawString(loiNhuan.ToString("N0"), normalFont, brush, x + dateWidth + 3 * numberWidth - e.Graphics.MeasureString(loiNhuan.ToString("N0"), normalFont).Width, y);

                        y += 25;

                        // Kiểm tra nếu đã hết trang
                        if (y > e.MarginBounds.Bottom - 150)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }
                }

                // Vẽ đường kẻ ngang trước tổng cộng
                e.Graphics.DrawLine(Pens.Black, x, y, x + width, y);
                y += 10;

                // In dòng tổng cộng
                e.Graphics.DrawString("TỔNG CỘNG:", boldFont, brush, x, y);

                // Tổng doanh thu
                decimal tongDoanhThu = decimal.Parse(txtTongDoanhThu.Text.Replace(",", ""));
                e.Graphics.DrawString(tongDoanhThu.ToString("N0"), boldFont, brush, x + dateWidth + numberWidth - e.Graphics.MeasureString(tongDoanhThu.ToString("N0"), boldFont).Width, y);

                // Tổng chi phí
                decimal tongChiPhi = decimal.Parse(txtTongChiPhi.Text.Replace(",", ""));
                e.Graphics.DrawString(tongChiPhi.ToString("N0"), boldFont, brush, x + dateWidth + 2 * numberWidth - e.Graphics.MeasureString(tongChiPhi.ToString("N0"), boldFont).Width, y);

                // Tổng lợi nhuận
                decimal tongLoiNhuan = decimal.Parse(txtTongLoiNhuan.Text.Replace(",", ""));
                e.Graphics.DrawString(tongLoiNhuan.ToString("N0"), boldFont, brush, x + dateWidth + 3 * numberWidth - e.Graphics.MeasureString(tongLoiNhuan.ToString("N0"), boldFont).Width, y);

                // Đã hoàn thành, không cần in thêm trang nào nữa
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo bản in: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.HasMorePages = false;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
