using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadFont()
        {
            foreach (FontFamily fontFamily in new InstalledFontCollection().Families)
            {
                cmbFont.Items.Add(fontFamily.Name);
            }
            cmbFont.SelectedItem = "Tahoma";
        }

        private void loadSize()
        {
            int[] sizeValues = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbSize.ComboBox.DataSource = sizeValues;
            cmbSize.SelectedItem = 14;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadFont();
            loadSize();
            rtbVanBan.Font = new Font("Tahoma", 14, FontStyle.Regular);
            cmbFont.SelectedIndexChanged += new EventHandler(toolStripComboBox1_Click);
            cmbSize.SelectedIndexChanged += new EventHandler(cmbSize_Click);
        }

        private void hệToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            rtbVanBan.Font = new Font("Tahoma", 14, FontStyle.Regular);
        }

        private void lưuNộiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    rtbVanBan.SaveFile(filePath);
                    MessageBox.Show("Văn bản đã được lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                rtbVanBan.ForeColor = fontDlg.Color;
                rtbVanBan.Font = fontDlg.Font;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                FontStyle style = rtbVanBan.SelectionFont.Style;
                if (rtbVanBan.SelectionFont.Italic)
                {
                    style &= ~FontStyle.Italic;
                }
                else
                {
                    style |= FontStyle.Italic;
                }
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont, style);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {   
            FontDialog fontDialog = new FontDialog();
            if (cmbFont.SelectedItem != null)
            {
                string selectedFont = cmbFont.SelectedItem.ToString();
                float currentSize = rtbVanBan.Font.Size;
                rtbVanBan.Font = new Font(selectedFont, currentSize);
                fontDialog.Font = rtbVanBan.Font;
            }
        }

        private void cmbSize_Click(object sender, EventArgs e)
        {
            if (cmbSize.SelectedItem != null)
            {
                int selectedSize;
                if (int.TryParse(cmbSize.SelectedItem.ToString(), out selectedSize))
                {
                    string currentFont = rtbVanBan.Font.FontFamily.Name;
                    rtbVanBan.Font = new Font(currentFont, selectedSize);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            rtbVanBan.Font = new Font("Tahoma", 14, FontStyle.Regular);
        }

        private void rtbVanBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                FontStyle style = rtbVanBan.SelectionFont.Style;
                if (rtbVanBan.SelectionFont.Underline)
                {
                    style &= ~FontStyle.Underline;
                }
                else
                {
                    style |= FontStyle.Underline;
                }
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont, style);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                FontStyle style = rtbVanBan.SelectionFont.Style;
                if (rtbVanBan.SelectionFont.Bold)
                {
                    style &= ~FontStyle.Bold;
                }
                else
                {
                    style |= FontStyle.Bold;
                }
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont, style);
            }
        }
        String filePath;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    rtbVanBan.SaveFile(filePath);
                    MessageBox.Show("Văn bản đã được lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|RichText files (*.rtf)|*.rtf";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String selectedFileName = openFileDialog.FileName;
                try
                {
                    if (Path.GetExtension(selectedFileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.RichText);
                    }
                    MessageBox.Show("Tập tin đã được mở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình mở tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (a == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
