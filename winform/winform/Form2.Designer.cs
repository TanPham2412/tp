namespace winform
{
    partial class Form2
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
            this.txt_MSNV = new System.Windows.Forms.TextBox();
            this.txt_TenNV = new System.Windows.Forms.TextBox();
            this.txt_Luong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_No = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_MSNV
            // 
            this.txt_MSNV.Location = new System.Drawing.Point(199, 113);
            this.txt_MSNV.Name = "txt_MSNV";
            this.txt_MSNV.Size = new System.Drawing.Size(182, 22);
            this.txt_MSNV.TabIndex = 0;
            this.txt_MSNV.TextChanged += new System.EventHandler(this.txt_MSNV_TextChanged);
            // 
            // txt_TenNV
            // 
            this.txt_TenNV.Location = new System.Drawing.Point(199, 169);
            this.txt_TenNV.Name = "txt_TenNV";
            this.txt_TenNV.Size = new System.Drawing.Size(284, 22);
            this.txt_TenNV.TabIndex = 1;
            // 
            // txt_Luong
            // 
            this.txt_Luong.Location = new System.Drawing.Point(199, 229);
            this.txt_Luong.Name = "txt_Luong";
            this.txt_Luong.Size = new System.Drawing.Size(163, 22);
            this.txt_Luong.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "MSNV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lương căn bản:";
            // 
            // btn_Yes
            // 
            this.btn_Yes.Location = new System.Drawing.Point(118, 281);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(75, 32);
            this.btn_Yes.TabIndex = 6;
            this.btn_Yes.Text = "Đồng ý";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_No
            // 
            this.btn_No.Location = new System.Drawing.Point(306, 281);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(75, 32);
            this.btn_No.TabIndex = 7;
            this.btn_No.Text = "Bỏ qua";
            this.btn_No.UseVisualStyleBackColor = true;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 450);
            this.Controls.Add(this.btn_No);
            this.Controls.Add(this.btn_Yes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Luong);
            this.Controls.Add(this.txt_TenNV);
            this.Controls.Add(this.txt_MSNV);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_MSNV;
        private System.Windows.Forms.TextBox txt_TenNV;
        private System.Windows.Forms.TextBox txt_Luong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Button btn_No;
    }
}