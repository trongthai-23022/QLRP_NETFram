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
    public partial class Flogin : Form
    {
        public Flogin()
        {
            InitializeComponent();
    
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string TaiKhoan = textBox1.Text;
            string MatKhau = textBox2.Text;
            string s = "Select * from NHANVIEN where TaiKhoan = N'" + TaiKhoan + "' and MatKhau = N'" + MatKhau + "'";
            if (Login_BLL.Instance.Check_BLL(s)&&(TaiKhoan!=" ")&&(MatKhau!=""))
            {
                QL f = new QL();
                f.ShowDialog();
            }
           
            else MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!!!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
