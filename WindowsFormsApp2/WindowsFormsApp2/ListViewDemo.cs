using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ListViewDemo : Form
    {
        public ListViewDemo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            foreach (ListViewItem item in lvNhanVien.SelectedItems)
            {
                lvNhanVien.Items.Remove(item);
                MessageBox.Show("Xóa thành công");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string phone = txtPhone.Text;

            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            ListViewItem item = new ListViewItem(lastName);
            item.SubItems.Add(firstName);
            item.SubItems.Add(phone);
            lvNhanVien.Items.Add(item);

            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhone.Clear();

            MessageBox.Show("Thêm thành công");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            ListViewItem selectedItem = lvNhanVien.SelectedItems[0];

            selectedItem.SubItems[0].Text = txtLastName.Text;
            selectedItem.SubItems[1].Text = txtFirstName.Text;
            selectedItem.SubItems[2].Text = txtPhone.Text;

            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhone.Clear();

            MessageBox.Show("Sửa thành công");
        }
    }
}
