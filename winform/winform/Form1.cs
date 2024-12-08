using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            addForm.DataTransferred += (msnv, tennv, luongnv) =>
            {
                dataGridView_Employee.Rows.Add(msnv, tennv, luongnv);
            };
            addForm.ShowDialog();
        }

             
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn xóa?", " Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (dataGridView_Employee.SelectedCells.Count > 0)
                {
                    dataGridView_Employee.Rows.RemoveAt(dataGridView_Employee.SelectedCells[0].RowIndex);
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dataGridView_Employee.SelectedCells.Count > 0)
            {
                
                int rowIndex = dataGridView_Employee.SelectedCells[0].RowIndex;

                string msnv = dataGridView_Employee.Rows[rowIndex].Cells[0].Value.ToString();
                string tennv = dataGridView_Employee.Rows[rowIndex].Cells[1].Value.ToString();
                double luongnv = Convert.ToDouble(dataGridView_Employee.Rows[rowIndex].Cells[2].Value);

                Form2 form2 = new Form2();
                {
                    form2.MSNV = msnv;
                    form2.TenNV = tennv;
                    form2.LuongNV = luongnv;
                    
                }
                
                form2.DataTransferred += (newMSNV, newTenNV, newLuongNV) =>
                {                
                    dataGridView_Employee.Rows[rowIndex].Cells[0].Value = newMSNV;
                    dataGridView_Employee.Rows[rowIndex].Cells[1].Value = newTenNV;
                    dataGridView_Employee.Rows[rowIndex].Cells[2].Value = newLuongNV;
                };

                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy chọn một ô để sửa!");
            }
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát?", " Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_Employee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
