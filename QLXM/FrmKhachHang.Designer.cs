using System.Drawing;
using System.Windows.Forms;

namespace QLXM
{
    partial class FrmKhachHang
    {
       
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpThongtinchung = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.mskSDT = new System.Windows.Forms.MaskedTextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblThongtinkhachhang = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.lblTkMaKh = new System.Windows.Forms.Label();
            this.txtTimkiemKH = new System.Windows.Forms.TextBox();
            this.grpThongtinchung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpThongtinchung
            // 
            this.grpThongtinchung.Controls.Add(this.btnLuu);
            this.grpThongtinchung.Controls.Add(this.dataGridView1);
            this.grpThongtinchung.Controls.Add(this.btnXoa);
            this.grpThongtinchung.Controls.Add(this.lbl);
            this.grpThongtinchung.Controls.Add(this.txtDiaChi);
            this.grpThongtinchung.Controls.Add(this.btnSua);
            this.grpThongtinchung.Controls.Add(this.mskSDT);
            this.grpThongtinchung.Controls.Add(this.lblSDT);
            this.grpThongtinchung.Controls.Add(this.btnThem);
            this.grpThongtinchung.Controls.Add(this.txtHoten);
            this.grpThongtinchung.Controls.Add(this.lblHoTen);
            this.grpThongtinchung.Controls.Add(this.txtMaKH);
            this.grpThongtinchung.Controls.Add(this.lblMaKH);
            this.grpThongtinchung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongtinchung.Location = new System.Drawing.Point(39, 75);
            this.grpThongtinchung.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpThongtinchung.Name = "grpThongtinchung";
            this.grpThongtinchung.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpThongtinchung.Size = new System.Drawing.Size(958, 502);
            this.grpThongtinchung.TabIndex = 0;
            this.grpThongtinchung.TabStop = false;
            this.grpThongtinchung.Text = "Thông tin chung";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(771, 445);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(84, 31);
            this.btnLuu.TabIndex = 34;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 234);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(878, 172);
            this.dataGridView1.TabIndex = 30;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(548, 445);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(84, 31);
            this.btnXoa.TabIndex = 33;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(34, 183);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(60, 20);
            this.lbl.TabIndex = 14;
            this.lbl.Text = "Địa Chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(126, 174);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(256, 26);
            this.txtDiaChi.TabIndex = 13;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(327, 445);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(84, 31);
            this.btnSua.TabIndex = 32;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // mskSDT
            // 
            this.mskSDT.Location = new System.Drawing.Point(126, 122);
            this.mskSDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mskSDT.Mask = "(999) 000-0000";
            this.mskSDT.Name = "mskSDT";
            this.mskSDT.Size = new System.Drawing.Size(180, 26);
            this.mskSDT.TabIndex = 12;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(34, 131);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(41, 20);
            this.lblSDT.TabIndex = 11;
            this.lblSDT.Text = "SDT";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(98, 445);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(84, 31);
            this.btnThem.TabIndex = 31;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(126, 80);
            this.txtHoten.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(180, 26);
            this.txtHoten.TabIndex = 3;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(33, 89);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(61, 20);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ Tên";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(126, 31);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(116, 26);
            this.txtMaKH.TabIndex = 1;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(34, 40);
            this.lblMaKH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(57, 20);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã KH";
            // 
            // lblThongtinkhachhang
            // 
            this.lblThongtinkhachhang.AutoSize = true;
            this.lblThongtinkhachhang.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongtinkhachhang.ForeColor = System.Drawing.Color.Black;
            this.lblThongtinkhachhang.Location = new System.Drawing.Point(346, 26);
            this.lblThongtinkhachhang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongtinkhachhang.Name = "lblThongtinkhachhang";
            this.lblThongtinkhachhang.Size = new System.Drawing.Size(428, 36);
            this.lblThongtinkhachhang.TabIndex = 1;
            this.lblThongtinkhachhang.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(897, 585);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 31);
            this.btnThoat.TabIndex = 37;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.Location = new System.Drawing.Point(642, 585);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(112, 31);
            this.btnTimkiem.TabIndex = 38;
            this.btnTimkiem.Text = "Tìm Kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            // 
            // lblTkMaKh
            // 
            this.lblTkMaKh.AutoSize = true;
            this.lblTkMaKh.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTkMaKh.Location = new System.Drawing.Point(242, 595);
            this.lblTkMaKh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTkMaKh.Name = "lblTkMaKh";
            this.lblTkMaKh.Size = new System.Drawing.Size(64, 20);
            this.lblTkMaKh.TabIndex = 17;
            this.lblTkMaKh.Text = "Mã KH";
            // 
            // txtTimkiemKH
            // 
            this.txtTimkiemKH.Location = new System.Drawing.Point(324, 588);
            this.txtTimkiemKH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimkiemKH.Name = "txtTimkiemKH";
            this.txtTimkiemKH.Size = new System.Drawing.Size(266, 26);
            this.txtTimkiemKH.TabIndex = 17;
            // 
            // FrmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 632);
            this.Controls.Add(this.txtTimkiemKH);
            this.Controls.Add(this.lblTkMaKh);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblThongtinkhachhang);
            this.Controls.Add(this.grpThongtinchung);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmKhachHang";
            this.Text = "Thông Tin Khách Hàng";
            this.grpThongtinchung.ResumeLayout(false);
            this.grpThongtinchung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox grpThongtinchung;
        private Label lblThongtinkhachhang;
        private TextBox txtMaKH;
        private Label lblMaKH;
        private TextBox txtHoten;
        private Label lblHoTen;
        private Label lblSDT;
        private MaskedTextBox mskSDT;
        private Label lbl;
        private TextBox txtDiaChi;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private DataGridView dataGridView1;
        private Button btnThoat;
        private Button btnTimkiem;
        private Label lblTkMaKh;
        private TextBox txtTimkiemKH;
    }
}
