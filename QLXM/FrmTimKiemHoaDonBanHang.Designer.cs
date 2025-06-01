using System.Drawing;
using System.Windows.Forms;

namespace QLXM
{
    partial class FrmTimKiemHoaDonBanHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.txtDatCoc = new System.Windows.Forms.TextBox();
            this.txtThue = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.cboMaKH = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTimLai = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.lblDatCoc = new System.Windows.Forms.Label();
            this.lblThue = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.dateNgayBan = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(164, 67);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(172, 21);
            this.txtSoHoaDon.TabIndex = 0;
            // 
            // txtDatCoc
            // 
            this.txtDatCoc.Location = new System.Drawing.Point(490, 70);
            this.txtDatCoc.Name = "txtDatCoc";
            this.txtDatCoc.ReadOnly = true;
            this.txtDatCoc.Size = new System.Drawing.Size(100, 21);
            this.txtDatCoc.TabIndex = 1;
            // 
            // txtThue
            // 
            this.txtThue.Location = new System.Drawing.Point(490, 110);
            this.txtThue.Name = "txtThue";
            this.txtThue.ReadOnly = true;
            this.txtThue.Size = new System.Drawing.Size(100, 21);
            this.txtThue.TabIndex = 2;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(490, 150);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(100, 21);
            this.txtTongTien.TabIndex = 3;
            // 
            // cboMaNV
            // 
            this.cboMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboMaNV.Location = new System.Drawing.Point(164, 105);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(172, 26);
            this.cboMaNV.TabIndex = 4;
            // 
            // cboMaKH
            // 
            this.cboMaKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboMaKH.ForeColor = System.Drawing.Color.Black;
            this.cboMaKH.Location = new System.Drawing.Point(164, 148);
            this.cboMaKH.Name = "cboMaKH";
            this.cboMaKH.Size = new System.Drawing.Size(172, 25);
            this.cboMaKH.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.Location = new System.Drawing.Point(59, 244);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(600, 173);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(112, 436);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(97, 39);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            // 
            // btnTimLai
            // 
            this.btnTimLai.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimLai.Location = new System.Drawing.Point(286, 436);
            this.btnTimLai.Name = "btnTimLai";
            this.btnTimLai.Size = new System.Drawing.Size(103, 39);
            this.btnTimLai.TabIndex = 10;
            this.btnTimLai.Text = "Tìm lại";
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(460, 436);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(87, 39);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "Đóng";
            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoHoaDon.Location = new System.Drawing.Point(40, 70);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(100, 23);
            this.lblSoHoaDon.TabIndex = 12;
            this.lblSoHoaDon.Text = "Số hóa đơn";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.Location = new System.Drawing.Point(40, 110);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(139, 23);
            this.lblNhanVien.TabIndex = 13;
            this.lblNhanVien.Text = "Tên Nhân Viên";
            // 
            // lblMaKH
            // 
            this.lblMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.Location = new System.Drawing.Point(40, 155);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(100, 23);
            this.lblMaKH.TabIndex = 14;
            this.lblMaKH.Text = "Tên Khách Hàng";
            // 
            // lblThang
            // 
            this.lblThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThang.Location = new System.Drawing.Point(40, 201);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(100, 23);
            this.lblThang.TabIndex = 15;
            this.lblThang.Text = "Ngày Bán";
            // 
            // lblDatCoc
            // 
            this.lblDatCoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatCoc.Location = new System.Drawing.Point(400, 73);
            this.lblDatCoc.Name = "lblDatCoc";
            this.lblDatCoc.Size = new System.Drawing.Size(65, 21);
            this.lblDatCoc.TabIndex = 17;
            this.lblDatCoc.Text = "Đặt cọc";
            // 
            // lblThue
            // 
            this.lblThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThue.Location = new System.Drawing.Point(400, 117);
            this.lblThue.Name = "lblThue";
            this.lblThue.Size = new System.Drawing.Size(65, 16);
            this.lblThue.TabIndex = 18;
            this.lblThue.Text = "Thuế";
            this.lblThue.Click += new System.EventHandler(this.lblThue_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(400, 152);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(100, 21);
            this.lblTongTien.TabIndex = 19;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Black;
            this.lblTieuDe.Location = new System.Drawing.Point(106, 19);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(330, 24);
            this.lblTieuDe.TabIndex = 20;
            this.lblTieuDe.Text = "TÌM KIẾM HÓA ĐƠN BÁN HÀNG";
            // 
            // dateNgayBan
            // 
            this.dateNgayBan.Checked = false;
            this.dateNgayBan.CustomFormat = "_/__/____";
            this.dateNgayBan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayBan.Location = new System.Drawing.Point(164, 201);
            this.dateNgayBan.Name = "dateNgayBan";
            this.dateNgayBan.Size = new System.Drawing.Size(172, 21);
            this.dateNgayBan.TabIndex = 21;
            // 
            // FrmTimKiemHoaDonBanHang
            // 
            this.ClientSize = new System.Drawing.Size(700, 486);
            this.Controls.Add(this.dateNgayBan);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.txtDatCoc);
            this.Controls.Add(this.txtThue);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.cboMaNV);
            this.Controls.Add(this.cboMaKH);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnTimLai);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.lblSoHoaDon);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.lblDatCoc);
            this.Controls.Add(this.lblThue);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTimKiemHoaDonBanHang";
            this.Text = "Tìm kiếm Hóa đơn Bán hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.TextBox txtDatCoc;
        private System.Windows.Forms.TextBox txtThue;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.ComboBox cboMaKH;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTimLai;
        private System.Windows.Forms.Button btnDong;

        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.Label lblDatCoc;
        private System.Windows.Forms.Label lblThue;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTieuDe;
        public DateTimePicker dateNgayBan;
    }
}
