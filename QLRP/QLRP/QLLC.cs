using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLRP.BLL;
using QLRP.DTO;
namespace QLRP
{
    public partial class QLLC : Form
    {
        public QLLC()
        {
            InitializeComponent();
            dataGridView1.DataSource = QLLC_BLL.Instance.GetAllRecordLC_BLL();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                txtMaLC.Text = dataGridView1.CurrentRow.Cells["MaLC"].Value.ToString();
                txtMaPhim.Text = dataGridView1.CurrentRow.Cells["MaPhim"].Value.ToString();
                txtMaRap.Text = dataGridView1.CurrentRow.Cells["MaRapPhim"].Value.ToString();


                txtTenPhim.Text = dataGridView1.CurrentRow.Cells["TenPhim"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["TimeChieu"].Value);
                
            }
        }
        public void refreshData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = QLLC_BLL.Instance.GetAllRecordLC_BLL();
        }
        private void butAdd_Click(object sender, EventArgs e)
        {
            AddLC lc = new AddLC();
            lc.ShowDialog();
            refreshData();
        }
        private LC GetLCOnForm()
        {
            LC a = new LC();
            a.MaLC = txtMaLC.Text;
            a.MaPhim = txtMaPhim.Text;
            a.MaRapPhim = txtMaRap.Text;
            a.TenPhim = txtTenPhim.Text;
            a.TimeChieu = Convert.ToDateTime(dateTimePicker1.Value);
            return a;
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            
           if (QLLC_BLL.Instance.EditLC_BLL(GetLCOnForm())) MessageBox.Show("Edit thành công!!!");
           else MessageBox.Show("Gặp lỗi khi Edit!!!");
            refreshData();
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                string MaLC = dataGridView1.CurrentRow.Cells["MaLC"].Value.ToString();
                if (QLLC_BLL.Instance.DelLC_BLL(MaLC))
                {
                    MessageBox.Show("Đã xóa thành công!!!");
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = QLLC_BLL.Instance.GetAllRecordLC_BLL();
                }
                else MessageBox.Show("Gặp lỗi khi xóa!!!");

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLLC_BLL.Instance.GetLCByNamePhim_BLL(txtSearch.Text);
        }

        private void QLLC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) butClose.PerformClick();
        }

       
    }
}
