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
    public partial class AddLC : Form
    {
        public AddLC()
        {
            InitializeComponent();
            SetCBBTenPhim();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (QLLC_BLL.Instance.AddLC_BLL(GetLCOnForm())) MessageBox.Show("Thêm lịch chiếu thành công!!!");
            else MessageBox.Show("Gặp lỗi khi thêm lịch chiếu!!!");
        }
        private LC GetLCOnForm()
        {
           LC a = new LC();
           a.MaLC = txtMaLC.Text;
           a.MaRapPhim = txtMaRap.Text;
           a.TenPhim = cbbTenPhim.SelectedItem.ToString();
           a.MaPhim = txtMaPhim.Text;
           a.TimeChieu = Convert.ToDateTime(dateTimePicker1.Value);
           return a;
        }
        public void SetCBBTenPhim()
        {
            cbbTenPhim.Items.AddRange(QLP_BLL.Instance.GetAllRecordTenPhim_BLL().ToArray());
            cbbTenPhim.SelectedIndex = 0;
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbTenPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t= cbbTenPhim.SelectedItem.ToString();
            List<PH1> k = new List<PH1>();
            k = QLP_BLL.Instance.GetAllRecordTTPhim_BLL();
            for(int i = 0 ; i < k.Count ; i++){
                if (k[i].TenPhim == t)
                {
                    txtMaPhim.Text = k[i].MaPhim;
                }
            }
        }
    }
}
