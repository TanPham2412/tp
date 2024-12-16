using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De02
{
    public partial class frmSanpham : Form
    {

        public frmSanpham()
        {
            InitializeComponent();
        }

        private void frmSanpham_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<LoaiSP> listLoaiSP = context.LoaiSPs.ToList();
                List<Sanpham> listSP = context.Sanphams.ToList();
                FillLoaiSPCombobox(listLoaiSP);
                BindGrid(listSP);

                btKLuu.Enabled = false;
                btLuu.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillLoaiSPCombobox(List<LoaiSP> listLoaiSP)
        {
            this.cboLoaiSP.DataSource = listLoaiSP;
            this.cboLoaiSP.DisplayMember = "TenLoai";
            this.cboLoaiSP.ValueMember = "MaLoai";
        }

        private void BindGrid(List<Sanpham> listSP)
        {
            lvSanpham.Rows.Clear();
            foreach (var item in listSP)
            {
                int index = lvSanpham.Rows.Add();
                lvSanpham.Rows[index].Cells[0].Value = item.MaSP;
                lvSanpham.Rows[index].Cells[1].Value = item.TenSP;
                lvSanpham.Rows[index].Cells[2].Value = item.Ngaynhap;
                lvSanpham.Rows[index].Cells[3].Value = item.LoaiSP.TenLoai;
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                List<Sanpham> spList = db.Sanphams.ToList();
                var sanpham = spList.FirstOrDefault(s => s.MaSP == txtMaSP.Text);

                if (sanpham != null) 
                {
                    if (spList.Any(s => s.MaSP == txtMaSP.Text && s.MaSP != sanpham.MaSP))
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng nhập một mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    sanpham.TenSP = txtTenSP.Text;
                    sanpham.Ngaynhap = dtNgaynhap.Value;
                    sanpham.Maloai = cboLoaiSP.SelectedValue.ToString();
                    db.SaveChanges();
                    BindGrid(db.Sanphams.ToList());
                    MessageBox.Show("Chỉnh sửa thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { 
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btTim_Click(object sender, EventArgs e)
        {

            try
            {
                Model1 db = new Model1();
                string maSP = txtTimSP.Text.Trim();

                if (!string.IsNullOrEmpty(maSP))
                {
                    List<Sanpham> listSP = db.Sanphams.Where(s => s.TenSP.Contains(maSP)) .ToList();
                    if (listSP.Count > 0)
                    {
                        BindGrid(listSP);
                        MessageBox.Show($"Tìm thấy {listSP.Count} sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGrid(db.Sanphams.ToList());
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                List<Sanpham> spList = db.Sanphams.ToList();
                if (spList.Any(s => s.MaSP == txtMaSP.Text))
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var newSanpham = new Sanpham
                {
                    MaSP = txtMaSP.Text,
                    TenSP = txtTenSP.Text,
                    Ngaynhap = dtNgaynhap.Value,
                    Maloai = cboLoaiSP.SelectedValue.ToString()
                };
                db.Sanphams.Add(newSanpham);
                db.SaveChanges();
                BindGrid(db.Sanphams.ToList());
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                List<Sanpham> spList = db.Sanphams.ToList();

                var sanpham = spList.FirstOrDefault(s => s.MaSP == txtMaSP.Text);

                if (sanpham != null) 
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?","Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        db.Sanphams.Remove(sanpham);
                        db.SaveChanges();
                        BindGrid(db.Sanphams.ToList());
                        MessageBox.Show("Sản phẩm đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                List<Sanpham> spList = db.Sanphams.ToList();

                var sanpham = spList.FirstOrDefault(s => s.MaSP == txtMaSP.Text);

                if (sanpham != null)
                {
                    sanpham.TenSP = txtTenSP.Text;
                    sanpham.Ngaynhap = dtNgaynhap.Value;
                    sanpham.Maloai = cboLoaiSP.SelectedValue.ToString();

                    db.SaveChanges();
                    BindGrid(db.Sanphams.ToList());
                    MessageBox.Show("Lưu thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btLuu.Enabled = false;
                    btKLuu.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btKLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = lvSanpham.CurrentRow;

                txtMaSP.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                txtTenSP.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                dtNgaynhap.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                cboLoaiSP.Text = selectedRow.Cells[3].Value?.ToString() ?? "";


                btLuu.Enabled = false;
                btKLuu.Enabled = false;

                MessageBox.Show("Hủy thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy thay đổi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void txtTimSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtNgaynhap_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvSanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                DataGridViewRow selectedRow = lvSanpham.CurrentRow;

                txtMaSP.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                txtTenSP.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                dtNgaynhap.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                cboLoaiSP.Text = selectedRow.Cells[3].Value?.ToString() ?? "";

                btLuu.Enabled = true;
                btKLuu.Enabled = true;
            }
        }
    }
}
