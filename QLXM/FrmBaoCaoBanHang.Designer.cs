namespace QLXM
{
    partial class FrmBaoCaoBanHang
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
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnLai = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mskdenngay = new System.Windows.Forms.MaskedTextBox();
            this.msktungay = new System.Windows.Forms.MaskedTextBox();
            this.mskNgayban = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoNgay = new System.Windows.Forms.RadioButton();
            this.rdoKhoang = new System.Windows.Forms.RadioButton();
            this.cboTenNV = new System.Windows.Forms.ComboBox();
            this.cboTenKH = new System.Windows.Forms.ComboBox();
            this.cboTenhang = new System.Windows.Forms.ComboBox();
            this.cboSoddh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(744, 561);
            this.btnDong.Margin = new System.Windows.Forms.Padding(2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(101, 34);
            this.btnDong.TabIndex = 27;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(271, 561);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(131, 34);
            this.btnTimkiem.TabIndex = 24;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnLai
            // 
            this.btnLai.Location = new System.Drawing.Point(443, 561);
            this.btnLai.Name = "btnLai";
            this.btnLai.Size = new System.Drawing.Size(120, 34);
            this.btnLai.TabIndex = 25;
            this.btnLai.Text = "Tìm lại";
            this.btnLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLai.UseVisualStyleBackColor = true;
            this.btnLai.Click += new System.EventHandler(this.btnLai_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(596, 561);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(120, 34);
            this.btnIn.TabIndex = 26;
            this.btnIn.Text = "In báo cáo";
            this.btnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // DataGridView2
            // 
            this.DataGridView2.BackgroundColor = System.Drawing.Color.Silver;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.GridColor = System.Drawing.Color.Silver;
            this.DataGridView2.Location = new System.Drawing.Point(744, 316);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.RowHeadersWidth = 62;
            this.DataGridView2.RowTemplate.Height = 28;
            this.DataGridView2.Size = new System.Drawing.Size(261, 206);
            this.DataGridView2.TabIndex = 23;
            // 
            // DataGridView1
            // 
            this.DataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.GridColor = System.Drawing.Color.Silver;
            this.DataGridView1.Location = new System.Drawing.Point(38, 316);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidth = 62;
            this.DataGridView1.RowTemplate.Height = 28;
            this.DataGridView1.Size = new System.Drawing.Size(678, 206);
            this.DataGridView1.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.mskdenngay);
            this.groupBox1.Controls.Add(this.msktungay);
            this.groupBox1.Controls.Add(this.mskNgayban);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdoNgay);
            this.groupBox1.Controls.Add(this.rdoKhoang);
            this.groupBox1.Controls.Add(this.cboTenNV);
            this.groupBox1.Controls.Add(this.cboTenKH);
            this.groupBox1.Controls.Add(this.cboTenhang);
            this.groupBox1.Controls.Add(this.cboSoddh);
            this.groupBox1.Location = new System.Drawing.Point(38, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 187);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(761, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Đến";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(589, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Từ";
            // 
            // mskdenngay
            // 
            this.mskdenngay.Location = new System.Drawing.Point(806, 129);
            this.mskdenngay.Mask = "00/00/0000";
            this.mskdenngay.Name = "mskdenngay";
            this.mskdenngay.Size = new System.Drawing.Size(146, 26);
            this.mskdenngay.TabIndex = 13;
            this.mskdenngay.ValidatingType = typeof(System.DateTime);
            // 
            // msktungay
            // 
            this.msktungay.Location = new System.Drawing.Point(622, 128);
            this.msktungay.Mask = "00/00/0000";
            this.msktungay.Name = "msktungay";
            this.msktungay.Size = new System.Drawing.Size(119, 26);
            this.msktungay.TabIndex = 12;
            this.msktungay.ValidatingType = typeof(System.DateTime);
            // 
            // mskNgayban
            // 
            this.mskNgayban.Location = new System.Drawing.Point(187, 124);
            this.mskNgayban.Mask = "00/00/0000";
            this.mskNgayban.Name = "mskNgayban";
            this.mskNgayban.Size = new System.Drawing.Size(177, 26);
            this.mskNgayban.TabIndex = 11;
            this.mskNgayban.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nhân viên bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tên khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tên hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Số hóa đơn đặt hàng";
            // 
            // rdoNgay
            // 
            this.rdoNgay.AutoSize = true;
            this.rdoNgay.Location = new System.Drawing.Point(10, 127);
            this.rdoNgay.Name = "rdoNgay";
            this.rdoNgay.Size = new System.Drawing.Size(108, 24);
            this.rdoNgay.TabIndex = 6;
            this.rdoNgay.TabStop = true;
            this.rdoNgay.Text = "Theo ngày";
            this.rdoNgay.UseVisualStyleBackColor = true;
            this.rdoNgay.CheckedChanged += new System.EventHandler(this.rdoNgay_CheckedChanged);
            // 
            // rdoKhoang
            // 
            this.rdoKhoang.AutoSize = true;
            this.rdoKhoang.Location = new System.Drawing.Point(452, 129);
            this.rdoKhoang.Name = "rdoKhoang";
            this.rdoKhoang.Size = new System.Drawing.Size(131, 24);
            this.rdoKhoang.TabIndex = 5;
            this.rdoKhoang.TabStop = true;
            this.rdoKhoang.Text = "Theo khoảng:";
            this.rdoKhoang.UseVisualStyleBackColor = true;
            this.rdoKhoang.CheckedChanged += new System.EventHandler(this.rdoKhoang_CheckedChanged);
            // 
            // cboTenNV
            // 
            this.cboTenNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTenNV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTenNV.FormattingEnabled = true;
            this.cboTenNV.Location = new System.Drawing.Point(585, 82);
            this.cboTenNV.Name = "cboTenNV";
            this.cboTenNV.Size = new System.Drawing.Size(121, 28);
            this.cboTenNV.TabIndex = 3;
            // 
            // cboTenKH
            // 
            this.cboTenKH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTenKH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTenKH.FormattingEnabled = true;
            this.cboTenKH.Location = new System.Drawing.Point(585, 35);
            this.cboTenKH.Name = "cboTenKH";
            this.cboTenKH.Size = new System.Drawing.Size(121, 28);
            this.cboTenKH.TabIndex = 2;
            // 
            // cboTenhang
            // 
            this.cboTenhang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTenhang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTenhang.FormattingEnabled = true;
            this.cboTenhang.Location = new System.Drawing.Point(187, 74);
            this.cboTenhang.Name = "cboTenhang";
            this.cboTenhang.Size = new System.Drawing.Size(177, 28);
            this.cboTenhang.TabIndex = 1;
            // 
            // cboSoddh
            // 
            this.cboSoddh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSoddh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSoddh.FormattingEnabled = true;
            this.cboSoddh.Location = new System.Drawing.Point(187, 39);
            this.cboSoddh.Name = "cboSoddh";
            this.cboSoddh.Size = new System.Drawing.Size(177, 28);
            this.cboSoddh.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(360, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 36);
            this.label1.TabIndex = 20;
            this.label1.Text = "BÁO CÁO BÁN HÀNG";
            // 
            // FrmBaoCaoBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 630);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.btnLai);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.DataGridView2);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmBaoCaoBanHang";
            this.Text = "BÁO CÁO BÁN HÀNG";
            this.Load += new System.EventHandler(this.FrmBaoCaoBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnLai;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridView DataGridView2;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mskdenngay;
        private System.Windows.Forms.MaskedTextBox msktungay;
        private System.Windows.Forms.MaskedTextBox mskNgayban;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoNgay;
        private System.Windows.Forms.RadioButton rdoKhoang;
        private System.Windows.Forms.ComboBox cboTenNV;
        private System.Windows.Forms.ComboBox cboTenKH;
        private System.Windows.Forms.ComboBox cboTenhang;
        private System.Windows.Forms.ComboBox cboSoddh;
        private System.Windows.Forms.Label label1;
    }
}

