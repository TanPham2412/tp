namespace winform
{
    partial class Form1
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
            this.btn_Dong = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.dataGridView_Employee = new System.Windows.Forms.DataGridView();
            this.col_MSNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_BasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employee)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Dong
            // 
            this.btn_Dong.Location = new System.Drawing.Point(627, 297);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(75, 30);
            this.btn_Dong.TabIndex = 9;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.UseVisualStyleBackColor = true;
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(627, 231);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(75, 31);
            this.btn_Sua.TabIndex = 8;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(627, 159);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 31);
            this.btn_Xoa.TabIndex = 7;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(627, 98);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 32);
            this.btn_Them.TabIndex = 6;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // dataGridView_Employee
            // 
            this.dataGridView_Employee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Employee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Employee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MSNV,
            this.col_Name,
            this.col_BasicSalary});
            this.dataGridView_Employee.Location = new System.Drawing.Point(24, 98);
            this.dataGridView_Employee.Name = "dataGridView_Employee";
            this.dataGridView_Employee.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_Employee.RowTemplate.Height = 24;
            this.dataGridView_Employee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Employee.Size = new System.Drawing.Size(547, 229);
            this.dataGridView_Employee.TabIndex = 10;
            this.dataGridView_Employee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Employee_CellContentClick);
            // 
            // col_MSNV
            // 
            this.col_MSNV.HeaderText = "MSNV";
            this.col_MSNV.MinimumWidth = 6;
            this.col_MSNV.Name = "col_MSNV";
            this.col_MSNV.Width = 125;
            // 
            // col_Name
            // 
            this.col_Name.HeaderText = "Tên NV";
            this.col_Name.MinimumWidth = 6;
            this.col_Name.Name = "col_Name";
            this.col_Name.Width = 125;
            // 
            // col_BasicSalary
            // 
            this.col_BasicSalary.HeaderText = "Lương CB";
            this.col_BasicSalary.MinimumWidth = 6;
            this.col_BasicSalary.Name = "col_BasicSalary";
            this.col_BasicSalary.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_Employee);
            this.Controls.Add(this.btn_Dong);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Dong;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.DataGridView dataGridView_Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_BasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MSNV;
    }
}

