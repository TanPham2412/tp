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
    public partial class Form2 : Form
    {
      
        public Form2()
        {
            InitializeComponent();
        }

        public string MSNV
        {
            get => txt_MSNV.Text;
            set => txt_MSNV.Text = value;
        }

        public string TenNV
        {
            get => txt_TenNV.Text;
            set => txt_TenNV.Text = value;
        }

        public double LuongNV
        {
            get => double.Parse(txt_Luong.Text);
            set => txt_Luong.Text = value.ToString();
        }

        public delegate void TransferDataHandler(string msnv, string tennv, double luongnv);

        public event TransferDataHandler DataTransferred;
        private void btn_Yes_Click(object sender, EventArgs e)
        {
            try
            {
                DataTransferred?.Invoke(MSNV, TenNV, LuongNV);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void txt_MSNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
