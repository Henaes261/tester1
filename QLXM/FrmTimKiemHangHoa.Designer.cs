namespace QLXM
{
    partial class FrmTimKiemHangHoa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.cboHangSX = new System.Windows.Forms.ComboBox();
            this.txtMaHang = new System.Windows.Forms.TextBox();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(233, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "TÌM KIẾM HÀNG HÓA";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTheLoai);
            this.groupBox1.Controls.Add(this.cboHangSX);
            this.groupBox1.Controls.Add(this.txtMaHang);
            this.groupBox1.Controls.Add(this.txtTenHang);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 74);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(731, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(190, 648);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(112, 35);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(172, 140);
            this.cboTheLoai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(161, 28);
            this.cboTheLoai.TabIndex = 7;
            // 
            // cboHangSX
            // 
            this.cboHangSX.FormattingEnabled = true;
            this.cboHangSX.Location = new System.Drawing.Point(507, 34);
            this.cboHangSX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboHangSX.Name = "cboHangSX";
            this.cboHangSX.Size = new System.Drawing.Size(194, 28);
            this.cboHangSX.TabIndex = 6;
            // 
            // txtMaHang
            // 
            this.txtMaHang.Location = new System.Drawing.Point(172, 34);
            this.txtMaHang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaHang.Name = "txtMaHang";
            this.txtMaHang.Size = new System.Drawing.Size(161, 26);
            this.txtMaHang.TabIndex = 5;
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(172, 89);
            this.txtTenHang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(161, 26);
            this.txtTenHang.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hãng sản xuất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 145);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thể loại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hàng:";
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Location = new System.Drawing.Point(18, 301);
            this.dgvHangHoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.RowHeadersWidth = 62;
            this.dgvHangHoa.Size = new System.Drawing.Size(731, 307);
            this.dgvHangHoa.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(535, 648);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(112, 35);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(357, 648);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(112, 35);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // lblTongSo
            // 
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Location = new System.Drawing.Point(19, 631);
            this.lblTongSo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(157, 20);
            this.lblTongSo.TabIndex = 9;
            this.lblTongSo.Text = "Tổng số: 0 sản phẩm";
            // 
            // FrmTimKiemHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 697);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.lblTongSo);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvHangHoa);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmTimKiemHangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm hàng hóa";
            this.Load += new System.EventHandler(this.FrmTimKiemHangHoa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.TextBox txtMaHang;
        private System.Windows.Forms.ComboBox cboHangSX;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label lblTongSo;
    }
}
