namespace PMQuanLySinhVien
{
    partial class QuanLyTaiKhoan
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
            this.mk = new System.Windows.Forms.TextBox();
            this.tdn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tb2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.ltk = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ttk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLíToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCosVấnHọcTậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điểmSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mk
            // 
            this.mk.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mk.Location = new System.Drawing.Point(168, 131);
            this.mk.Name = "mk";
            this.mk.Size = new System.Drawing.Size(250, 34);
            this.mk.TabIndex = 17;
            this.mk.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tdn
            // 
            this.tdn.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdn.Location = new System.Drawing.Point(168, 91);
            this.tdn.Name = "tdn";
            this.tdn.Size = new System.Drawing.Size(250, 34);
            this.tdn.TabIndex = 16;
            this.tdn.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "Mật Khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên đăng nhập";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(284, 242);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 34);
            this.button3.TabIndex = 27;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 34);
            this.button2.TabIndex = 26;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 34);
            this.button1.TabIndex = 25;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb2
            // 
            this.tb2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb2.Location = new System.Drawing.Point(22, 167);
            this.tb2.Name = "tb2";
            this.tb2.RowHeadersWidth = 51;
            this.tb2.RowTemplate.Height = 24;
            this.tb2.Size = new System.Drawing.Size(517, 302);
            this.tb2.TabIndex = 29;
            this.tb2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb2_CellClick);
            this.tb2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb2_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 28);
            this.label4.TabIndex = 30;
            this.label4.Text = "Loại TK";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ltk
            // 
            this.ltk.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltk.FormattingEnabled = true;
            this.ltk.Items.AddRange(new object[] {
            "Cố vấn học tập",
            "Quản Trị"});
            this.ltk.Location = new System.Drawing.Point(168, 177);
            this.ltk.Name = "ltk";
            this.ltk.Size = new System.Drawing.Size(250, 36);
            this.ltk.TabIndex = 31;
            this.ltk.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.ttk);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tdn);
            this.groupBox1.Controls.Add(this.ltk);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.mk);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(567, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 302);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // ttk
            // 
            this.ttk.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttk.Location = new System.Drawing.Point(168, 49);
            this.ttk.Name = "ttk";
            this.ttk.Size = new System.Drawing.Size(250, 34);
            this.ttk.TabIndex = 33;
            this.ttk.TextChanged += new System.EventHandler(this.ttk_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 28);
            this.label1.TabIndex = 32;
            this.label1.Text = "Tên tài khoản";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLíToolStripMenuItem,
            this.quảnLíĐiểmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1045, 30);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLíToolStripMenuItem
            // 
            this.quảnLíToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýSVToolStripMenuItem,
            this.quảnLýLớpToolStripMenuItem,
            this.quảnLýKhoaToolStripMenuItem,
            this.quảnLýCosVấnHọcTậpToolStripMenuItem,
            this.quảnLýMônHọcToolStripMenuItem,
            this.quảnLýTàiKhoảnToolStripMenuItem});
            this.quảnLíToolStripMenuItem.Name = "quảnLíToolStripMenuItem";
            this.quảnLíToolStripMenuItem.Size = new System.Drawing.Size(73, 26);
            this.quảnLíToolStripMenuItem.Text = "Quản Lí";
            // 
            // quảnLýSVToolStripMenuItem
            // 
            this.quảnLýSVToolStripMenuItem.Name = "quảnLýSVToolStripMenuItem";
            this.quảnLýSVToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.quảnLýSVToolStripMenuItem.Text = "Quản Lý SV";
            this.quảnLýSVToolStripMenuItem.Click += new System.EventHandler(this.quảnLýSVToolStripMenuItem_Click);
            // 
            // quảnLýLớpToolStripMenuItem
            // 
            this.quảnLýLớpToolStripMenuItem.Name = "quảnLýLớpToolStripMenuItem";
            this.quảnLýLớpToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.quảnLýLớpToolStripMenuItem.Text = "Quản Lý Lớp";
            this.quảnLýLớpToolStripMenuItem.Click += new System.EventHandler(this.quảnLýLớpToolStripMenuItem_Click);
            // 
            // quảnLýKhoaToolStripMenuItem
            // 
            this.quảnLýKhoaToolStripMenuItem.Name = "quảnLýKhoaToolStripMenuItem";
            this.quảnLýKhoaToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.quảnLýKhoaToolStripMenuItem.Text = "Quản Lý khoa";
            this.quảnLýKhoaToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKhoaToolStripMenuItem_Click);
            // 
            // quảnLýCosVấnHọcTậpToolStripMenuItem
            // 
            this.quảnLýCosVấnHọcTậpToolStripMenuItem.Name = "quảnLýCosVấnHọcTậpToolStripMenuItem";
            this.quảnLýCosVấnHọcTậpToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.quảnLýCosVấnHọcTậpToolStripMenuItem.Text = "Quản Lý Cố Vấn Học Tập";
            this.quảnLýCosVấnHọcTậpToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCosVấnHọcTậpToolStripMenuItem_Click);
            // 
            // quảnLýMônHọcToolStripMenuItem
            // 
            this.quảnLýMônHọcToolStripMenuItem.Name = "quảnLýMônHọcToolStripMenuItem";
            this.quảnLýMônHọcToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.quảnLýMônHọcToolStripMenuItem.Text = "Quản Lý Môn Học";
            this.quảnLýMônHọcToolStripMenuItem.Click += new System.EventHandler(this.quảnLýMônHọcToolStripMenuItem_Click);
            // 
            // quảnLýTàiKhoảnToolStripMenuItem
            // 
            this.quảnLýTàiKhoảnToolStripMenuItem.Name = "quảnLýTàiKhoảnToolStripMenuItem";
            this.quảnLýTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.quảnLýTàiKhoảnToolStripMenuItem.Text = "Quản Lý Tài Khoản";
            this.quảnLýTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.quảnLýTàiKhoảnToolStripMenuItem_Click);
            // 
            // quảnLíĐiểmToolStripMenuItem
            // 
            this.quảnLíĐiểmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.điểmSVToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.quảnLíĐiểmToolStripMenuItem.Name = "quảnLíĐiểmToolStripMenuItem";
            this.quảnLíĐiểmToolStripMenuItem.Size = new System.Drawing.Size(113, 26);
            this.quảnLíĐiểmToolStripMenuItem.Text = "Quản Lí Điểm";
            // 
            // điểmSVToolStripMenuItem
            // 
            this.điểmSVToolStripMenuItem.Name = "điểmSVToolStripMenuItem";
            this.điểmSVToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.điểmSVToolStripMenuItem.Text = "Điểm SV";
            this.điểmSVToolStripMenuItem.Click += new System.EventHandler(this.điểmSVToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(138)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(22, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 104);
            this.panel1.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(352, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(343, 50);
            this.label5.TabIndex = 1;
            this.label5.Text = "Quản Lý Tài Khoản";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // QuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1045, 513);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "QuanLyTaiKhoan";
            this.Text = "Quản Lí Tài Khoản";
            ((System.ComponentModel.ISupportInitialize)(this.tb2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mk;
        private System.Windows.Forms.TextBox tdn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tb2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ltk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLíToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýMônHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýCosVấnHọcTậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKhoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLớpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíĐiểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem điểmSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ttk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
    }
}