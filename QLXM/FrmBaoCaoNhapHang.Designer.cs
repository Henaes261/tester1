using System.Drawing;
using System.Windows.Forms;

namespace QLXM
{
    partial class FrmBaoCaoNhapHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.ComboBox cboMaHD;
        private System.Windows.Forms.ComboBox cboTenHang;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.DateTimePicker dateTuKhoang;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridView dgvHang;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTimLai;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.txtDongia = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblTuKhoang = new System.Windows.Forms.Label();
            this.lblDen = new System.Windows.Forms.Label();
            this.dateDenKhoang = new System.Windows.Forms.DateTimePicker();
            this.lblNCC = new System.Windows.Forms.Label();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.cboMaHD = new System.Windows.Forms.ComboBox();
            this.cboTenHang = new System.Windows.Forms.ComboBox();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.dateTuKhoang = new System.Windows.Forms.DateTimePicker();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.dgvHang = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTimLai = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(250, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(321, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO NHẬP HÀNG";
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.txtDongia);
            this.grpTimKiem.Controls.Add(this.lblDonGia);
            this.grpTimKiem.Controls.Add(this.lblTuKhoang);
            this.grpTimKiem.Controls.Add(this.lblDen);
            this.grpTimKiem.Controls.Add(this.dateDenKhoang);
            this.grpTimKiem.Controls.Add(this.lblNCC);
            this.grpTimKiem.Controls.Add(this.lblTenHang);
            this.grpTimKiem.Controls.Add(this.lblNhanVien);
            this.grpTimKiem.Controls.Add(this.lblMaHD);
            this.grpTimKiem.Controls.Add(this.cboMaHD);
            this.grpTimKiem.Controls.Add(this.cboTenHang);
            this.grpTimKiem.Controls.Add(this.cboNhaCungCap);
            this.grpTimKiem.Controls.Add(this.cboNhanVien);
            this.grpTimKiem.Controls.Add(this.dateTuKhoang);
            this.grpTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTimKiem.Location = new System.Drawing.Point(30, 75);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(769, 150);
            this.grpTimKiem.TabIndex = 1;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm";
            // 
            // txtDongia
            // 
            this.txtDongia.Location = new System.Drawing.Point(110, 111);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.ReadOnly = true;
            this.txtDongia.Size = new System.Drawing.Size(178, 26);
            this.txtDongia.TabIndex = 18;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(6, 116);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(68, 20);
            this.lblDonGia.TabIndex = 17;
            this.lblDonGia.Text = "Đơn Giá";
            // 
            // lblTuKhoang
            // 
            this.lblTuKhoang.AutoSize = true;
            this.lblTuKhoang.Location = new System.Drawing.Point(339, 117);
            this.lblTuKhoang.Name = "lblTuKhoang";
            this.lblTuKhoang.Size = new System.Drawing.Size(86, 20);
            this.lblTuKhoang.TabIndex = 16;
            this.lblTuKhoang.Text = "Từ Khoảng";
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(585, 117);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(39, 20);
            this.lblDen.TabIndex = 15;
            this.lblDen.Text = "Đến";
            // 
            // dateDenKhoang
            // 
            this.dateDenKhoang.CustomFormat = "_/__/____";
            this.dateDenKhoang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDenKhoang.Location = new System.Drawing.Point(642, 111);
            this.dateDenKhoang.Name = "dateDenKhoang";
            this.dateDenKhoang.Size = new System.Drawing.Size(92, 26);
            this.dateDenKhoang.TabIndex = 14;
            // 
            // lblNCC
            // 
            this.lblNCC.AutoSize = true;
            this.lblNCC.Location = new System.Drawing.Point(339, 75);
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.Size = new System.Drawing.Size(113, 20);
            this.lblNCC.TabIndex = 12;
            this.lblNCC.Text = "Nhà Cung Cấp";
            // 
            // lblTenHang
            // 
            this.lblTenHang.AutoSize = true;
            this.lblTenHang.Location = new System.Drawing.Point(339, 35);
            this.lblTenHang.Name = "lblTenHang";
            this.lblTenHang.Size = new System.Drawing.Size(79, 20);
            this.lblTenHang.TabIndex = 11;
            this.lblTenHang.Text = "Tên Hàng";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.Location = new System.Drawing.Point(6, 80);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(87, 20);
            this.lblNhanVien.TabIndex = 10;
            this.lblNhanVien.Text = "Nhân Viên ";
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.Location = new System.Drawing.Point(6, 40);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(99, 20);
            this.lblMaHD.TabIndex = 9;
            this.lblMaHD.Text = "Mã Hóa Đơn";
            // 
            // cboMaHD
            // 
            this.cboMaHD.Location = new System.Drawing.Point(110, 33);
            this.cboMaHD.Name = "cboMaHD";
            this.cboMaHD.Size = new System.Drawing.Size(178, 28);
            this.cboMaHD.TabIndex = 0;
            // 
            // cboTenHang
            // 
            this.cboTenHang.Location = new System.Drawing.Point(469, 32);
            this.cboTenHang.Name = "cboTenHang";
            this.cboTenHang.Size = new System.Drawing.Size(265, 28);
            this.cboTenHang.TabIndex = 1;
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.Location = new System.Drawing.Point(469, 72);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(265, 28);
            this.cboNhaCungCap.TabIndex = 2;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Location = new System.Drawing.Point(110, 72);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(178, 28);
            this.cboNhanVien.TabIndex = 3;
            // 
            // dateTuKhoang
            // 
            this.dateTuKhoang.CustomFormat = "_/__/____";
            this.dateTuKhoang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTuKhoang.Location = new System.Drawing.Point(469, 111);
            this.dateTuKhoang.Name = "dateTuKhoang";
            this.dateTuKhoang.Size = new System.Drawing.Size(110, 26);
            this.dateTuKhoang.TabIndex = 7;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.AllowUserToResizeColumns = false;
            this.dgvDanhSach.AllowUserToResizeRows = false;
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.ColumnHeadersHeight = 34;
            this.dgvDanhSach.Location = new System.Drawing.Point(30, 243);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersWidth = 62;
            this.dgvDanhSach.Size = new System.Drawing.Size(500, 150);
            this.dgvDanhSach.TabIndex = 2;
            // 
            // dgvHang
            // 
            this.dgvHang.AllowUserToAddRows = false;
            this.dgvHang.AllowUserToDeleteRows = false;
            this.dgvHang.AllowUserToResizeColumns = false;
            this.dgvHang.AllowUserToResizeRows = false;
            this.dgvHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHang.ColumnHeadersHeight = 34;
            this.dgvHang.Location = new System.Drawing.Point(561, 243);
            this.dgvHang.Name = "dgvHang";
            this.dgvHang.ReadOnly = true;
            this.dgvHang.RowHeadersWidth = 62;
            this.dgvHang.Size = new System.Drawing.Size(238, 150);
            this.dgvHang.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(140, 427);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(88, 31);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            // 
            // btnTimLai
            // 
            this.btnTimLai.Location = new System.Drawing.Point(308, 427);
            this.btnTimLai.Name = "btnTimLai";
            this.btnTimLai.Size = new System.Drawing.Size(80, 31);
            this.btnTimLai.TabIndex = 5;
            this.btnTimLai.Text = "Tìm lại";
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Location = new System.Drawing.Point(447, 427);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(102, 31);
            this.btnInBaoCao.TabIndex = 6;
            this.btnInBaoCao.Text = "In báo cáo";
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(600, 427);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 31);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "Đóng";
            // 
            // FrmBaoCaoNhapHang
            // 
            this.ClientSize = new System.Drawing.Size(820, 501);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.dgvHang);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnTimLai);
            this.Controls.Add(this.btnInBaoCao);
            this.Controls.Add(this.btnDong);
            this.Name = "FrmBaoCaoNhapHang";
            this.Text = "Báo cáo nhập hàng";
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblMaHD;
        private Label lblNCC;
        private Label lblTenHang;
        private Label lblNhanVien;
        private DateTimePicker dateDenKhoang;
        private Label lblTuKhoang;
        private Label lblDen;
        private TextBox txtDongia;
        private Label lblDonGia;
    }
}
