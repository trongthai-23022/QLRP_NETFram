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
    public partial class KH1 : Form
    {
        public KH1()
        {
            InitializeComponent();
        }

        private KH GetKHOnForm()
        {
            KH a = new KH();
            a.ID_KH = txtID.Text;
            a.DiaChi = txtDiaChi.Text;
            if (radioButtonNam.Checked == true) a.GioiTinh = true;
            else a.GioiTinh = false;
            a.TenKH = txtTenKh.Text;
            a.SoDienThoai = txtSDT.Text;
            a.NgaySinh = Convert.ToDateTime(dateTimePickerKH.Value.ToString());
            a.CMND = txtCMND.Text;
            return a;
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            if (GetKHOnForm().CMND == "" || GetKHOnForm().TenKH == "" || GetKHOnForm().SoDienThoai == "") MessageBox.Show("Thông tin chưa điền đầy đủ!!!");
            else if (QLKH_BLL.Instance.AddKH_BLL(GetKHOnForm())) MessageBox.Show("Thêm thành công!!!");
            else MessageBox.Show("Gặp lỗi khi thêm!!!");
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
