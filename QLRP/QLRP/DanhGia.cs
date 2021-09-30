using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLRP.DTO;
using QLRP.BLL;
namespace QLRP
{
    public partial class DanhGia : Form
    {
        public DanhGia(string ID)
        {
            InitializeComponent();
            dataGridView1.DataSource = DGia_BLL.Instance.GetPHNOW_BLL();
            txtID.Text = ID;

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string ma = dataGridView1.CurrentRow.Cells["MaPhim"].Value.ToString();
                textMaPhim.Text = ma;

                //   pictureBox1.Image = ByteArrayToImage(phim.HinhAnh);
                //Loi nhung co le la do chua co anh trong csdl
            }
        }

        private void buttonXong_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || textMaPhim.Text == "")
            {
                MessageBox.Show("Không thành công");
            }
            else if (radioButton1.Checked == true)
            {
                DGia_BLL.Instance.GuiDanhGia_BLL(txtID.Text, textMaPhim.Text, "1");
                MessageBox.Show("Thành công");
            }
            else if (radioButton2.Checked == true)
            {
                DGia_BLL.Instance.GuiDanhGia_BLL(txtID.Text, textMaPhim.Text, "2");
                MessageBox.Show("Thành công");
            }
            else if (radioButton3.Checked == true)
            {
                DGia_BLL.Instance.GuiDanhGia_BLL(txtID.Text, textMaPhim.Text, "3");
                MessageBox.Show("Thành công");
            }
            else if (radioButton4.Checked == true)
            {
                DGia_BLL.Instance.GuiDanhGia_BLL(txtID.Text, textMaPhim.Text, "4");
                MessageBox.Show("Thành công");
            }
            else if (radioButton5.Checked == true)
            {
                DGia_BLL.Instance.GuiDanhGia_BLL(txtID.Text, textMaPhim.Text, "5");
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void textMaPhim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
