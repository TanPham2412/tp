using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;

                id_txt.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                Name_txt.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                khoa_cmb.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                point_txt.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
            }
        }


        //private void Form2_Load(object sender, EventArgs e)
        //{
        //    Model1 c = new Model1();
        //    List<STUDENT> list = c.STUDENTs.ToList();
        //    dataGridView1.DataSource = list;
        //}


        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {

                Model1 context = new Model1();
                List<FACULTY> listFalcultys = context.FACULTies.ToList(); //lấy các khoa
                List<STUDENT> listStudent = context.STUDENTs.ToList(); //lấy sinh viên
                FillFalcultyCombobox(listFalcultys);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFalcultyCombobox(List<FACULTY> listFalcultys)
        {
            this.khoa_cmb.DataSource = listFalcultys;
            this.khoa_cmb.DisplayMember = "FacultyName";
            this.khoa_cmb.ValueMember = "FacultyID";
        }
        //Hàm binding gridView từ list sinh viên
        private void BindGrid(List<STUDENT> listStudent)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.StudentID;
                dataGridView1.Rows[index].Cells[1].Value = item.FullName;
                dataGridView1.Rows[index].Cells[2].Value = item.FACULTY.FacultyName;
                dataGridView1.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void id_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                List<STUDENT> studentList = db.STUDENTs.ToList();
                if (studentList.Any(s => s.StudentID == id_txt.Text))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại. Vui lòng nhập mã khác. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                var newStudent = new STUDENT

                {
                    StudentID = id_txt.Text,
                    FullName = Name_txt.Text,
                    FacultyID = int.Parse(khoa_cmb.SelectedValue.ToString()),
                    AverageScore = float.Parse(point_txt.Text),
                };

                db.STUDENTs.Add(newStudent);
                db.SaveChanges();

                BindGrid(db.STUDENTs.ToList());
                MessageBox.Show("Thêm sinh viên thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sua_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                List<STUDENT> students = db.STUDENTs.ToList();
                var student = students.FirstOrDefault(s => s.StudentID == id_txt.Text);
                if (student != null)
                {
                    if (students.Any(s => s.StudentID == id_txt.Text && s.StudentID != student.StudentID))
                    {
                        MessageBox.Show("Mã SV đã tồn tại. Vui lòng nhập một mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    student.FullName = Name_txt.Text;
                    student.FacultyID = int.Parse(khoa_cmb.SelectedValue.ToString());
                    student.AverageScore = double.Parse(point_txt.Text);
                    // Cập nhật sinh viên lưu vào CSDL
                    db.SaveChanges();
                    // Hiển thị lại danh sách sinh viên

                    BindGrid(db.STUDENTs.ToList());
                    MessageBox.Show("Chỉnh sửa thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sinh viên không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();   
                List<STUDENT> studentList = db.STUDENTs.ToList();

                // Tìm kiếm sinh viên có tồn tại trong CSDL hay không
                var student = studentList.FirstOrDefault(s => s.StudentID == id_txt.Text);

                if (student != null)
                {
                    // Xóa sinh viên khỏi CSDL
                    db.STUDENTs.Remove(student);
                    db.SaveChanges();

                    BindGrid(db.STUDENTs.ToList());

                    MessageBox.Show("Sinh viên đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sinh viên không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
