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
    public partial class RP1 : Form
    {
        public RP1()
        {
            InitializeComponent();
            SetCBBName();
        }
        public delegate void refreshData();
        public refreshData refresh;
        private RP GetRPOnForm()
        {
           RP a = new RP();
           a.MaRapPhim = txtMaRap.Text;
           a.TenRapPhim = txtTenRap.Text;
           a.DiaChi = txtDiaChi.Text;
           a.MaNhanVien = txtMa.Text;
           a.TenNhanVienQuanLy = cbbName1.SelectedItem.ToString();
           
            return a;
        }
        private void butOk_Click(object sender, EventArgs e)
        {
            if (GetRPOnForm().TenRapPhim == "" || GetRPOnForm().DiaChi == "" || GetRPOnForm().MaRapPhim=="")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin");
            }
            else{
            string query = "Select * from RAPPHIM where TenRapPhim =N'"+GetRPOnForm().TenRapPhim+"'";
            string query1 = "Select * from RAPPHIM where DiaChiCuaRapPhim =N'"+GetRPOnForm().DiaChi+"'";
            string query2 = "Select * from RAPPHIM where MaRapPhim =N'" + GetRPOnForm().MaRapPhim + "'";
            if(Login_BLL.Instance.Check_BLL(query) == true) MessageBox.Show("Đã tồn tại tên rạp phim này!!!");
            else if(Login_BLL.Instance.Check_BLL(query1) == true) MessageBox.Show("Đã tồn tại địa chỉ rạp phim này!!!");
            else if (Login_BLL.Instance.Check_BLL(query2) == true) MessageBox.Show("Đã tồn tại mã rạp phim này!!!");
            else if (QLRP_BLL.Instance.AddRP_BLL(GetRPOnForm())) MessageBox.Show("Thêm thành công!!!");
            else MessageBox.Show("Gặp lỗi khi thêm!!!");
           
        }
        }

        public void SetCBBName()
        {
            foreach (NV i in QLNV_BLL.Instance.GetAllRecordNV_BLL())
            {
                cbbName1.Items.Add(new CBBItem()
                {
                    Text = i.TenNhanVien,
                    Value = Convert.ToInt32(i.MaNhanVien)
                });
            }
            cbbName1.SelectedIndex = 0;
       

        }

        private void cbbName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbbName1.SelectedItem.ToString();
            txtMa.Text = QLNV_BLL.Instance.GetMaNV(name);
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RP1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) butOk.PerformClick();
            else if (e.KeyCode == Keys.Escape) butExit.PerformClick();
        }

        
    }
}
