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
    public partial class QLKH : Form
    {
        public QLKH()
        {
            InitializeComponent();
            SetCBBSort();
            buttonGoiY.Enabled = true;
            dataGridView1.DataSource = QLKH_BLL.Instance.GetAllRecordKH_BLL();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            radioButtonNam.Checked = true;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                txtID.Text = dataGridView1.CurrentRow.Cells["ID_KH"].Value.ToString();
                txtTenKH.Text = dataGridView1.CurrentRow.Cells["TenKH"].Value.ToString();
                txtCMND.Text = dataGridView1.CurrentRow.Cells["CMND"].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells["SoDienThoai"].Value.ToString();
                dateTimePickerKH.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NgaySinh"].Value.ToString());
                txtDiaChi.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
                // txtSdt.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
                // txtCMND.Text = dataGridView1.CurrentRow.Cells["SoCC"].Value.ToString();
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["GioiTinh"].Value.ToString()) == true) radioButtonNam.Checked = true;
                else radioButtonNu.Checked = true;
                buttonGoiY.Enabled = true;
            }
        }
        public void refreshData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = QLKH_BLL.Instance.GetAllRecordKH_BLL();
        }

        private void button_GoiY_Click(object sender, EventArgs e)
        {

        }
        public double[,] dudoan(double[,] matrix0, int m, int n)
        {
            double[,] matrix = new double[m + 2, n + 2];
            double Tong = 0;
            //Buoc 1 tinh TB
            //sao chep maxtrix0 => matrix hang cuoi cung tinh gia tri TB
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    matrix[i, j] = matrix0[i, j];
                    // hang cuoi m + 1 
                    if (i == m)
                    {
                        double count = m; //bang so phan tu trong cot j
                        //Tong cac cot
                        for (int k = 0; k <= m - 1; k++)
                        { //k = phan tu trong cot hang thu j
                            Tong += matrix0[k, j];
                            // neu co phan tu = 0 thi khong lay
                            if (matrix0[k, j] == 0)
                            {
                                count--;
                            }
                        }
                        //Trung binh cac cot
                        matrix[i, j] = Tong / count;
                    }
                }
            }


            //Buoc 2 Chuan hoa du lieu
            for (int i = 0; i <= m - 1; i++)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    if (matrix[i, j] != 0)  // neu phan tu != 0 thi chuan hoa.....
                        matrix[i, j] -= matrix[m, j];
                }
            }

            //Buoc 3 Lap ma tran tuong quan
            double[,] similar = new double[n + 1, n + 1];
            double[] dodaivector = new double[n + 1]; // ma tran chua do dai vector cot n
            for (int i = 0; i <= n - 1; i++)
            {// chay tu phan tu 1 den n
                double tongbinhphuong = 0;
                for (int j = 0; j <= m - 1; j++)
                { // chay tu phan tu 1 den m cua cac cot i
                    tongbinhphuong += matrix[j, i] * matrix[j, i];
                }
                dodaivector[i] = Math.Sqrt(tongbinhphuong); // Do dai cua cac vector cot i
            }
            //tao ma tran tuong quan n x n
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    double tichvector = 0;
                    double tichmodule = dodaivector[i] * dodaivector[j]; // tich do dai cua vector
                    for (int k = 0; k <= m - 1; k++)
                    {
                        tichvector += (matrix[k, i] * matrix[k, j]); // tich cac phan tu cua cac vector
                    }
                    similar[i, j] = tichvector / tichmodule;// ma tran tuong quan ra doi
                }
            }
            //Buoc 4 Tim cac cuc dai tuong quan
            // chu y o day chon user0 la khach hang can goi y 
            // chi tinh user0 thoi
            double max1 = 0;
            double max2 = 0;
            for (int i = 1; i <= n - 1; i++)
            {// vtri user0 luon bang 1
                max1 = Math.Max(similar[0, i], max1); // tim gia tri tuong quan nhat
            }
            int vitrimax1 = 0;
            int vitrimax2 = 0;
            for (int i = 1; i <= n - 1; i++)
            {
                if (similar[0, i] == max1)
                {
                    vitrimax1 = i;          // tim user thu i tuong quan nhat
                }
                else
                {
                    max2 = Math.Max(similar[0, i], max2);//tim gia tri tuong quan nhi tru max1
                }

            }
            for (int i = 1; i <= n - 1; i++)
            {
                if (similar[0, i] == max2)
                {
                    vitrimax2 = i;      // tim user thu i tuong quan nhi
                }
            }
            //Buoc 5 Du doan danh gia user0 doi voi san pham
            for (int i = 0; i <= m - 1; i++)
            {
                if (matrix[i, 0] == 0)
                {
                    matrix[i, 0] = (max1 * matrix[i, vitrimax1] + max2 * matrix[i, vitrimax2]) / (Math.Abs(max1) + Math.Abs(max2));
                }
            }
            //Buoc 6 Dao nguoc chuan hoa
            for (int i = 0; i <= m - 1; i++)
            {
                matrix[i, 0] += matrix[m, 0];
            }
            return matrix;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void butThem_Click(object sender, EventArgs e)
        {
            KH1 nv = new KH1();
            nv.ShowDialog();
            refreshData();
        }
        private KH GetKHOnForm()
        {
            KH a = new KH();
            a.ID_KH = txtID.Text;
            a.DiaChi = txtDiaChi.Text;
            if (radioButtonNam.Checked == true) a.GioiTinh = true;
            else a.GioiTinh = false;
            a.TenKH = txtTenKH.Text;
            a.SoDienThoai = txtSDT.Text;
            a.NgaySinh = Convert.ToDateTime(dateTimePickerKH.Value.ToString());
            a.CMND = txtCMND.Text;
            return a;
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            if (GetKHOnForm().CMND == "" || GetKHOnForm().TenKH == "" || GetKHOnForm().SoDienThoai == "") MessageBox.Show("Thông tin chưa đầy đủ!!!");
            else if (QLKH_BLL.Instance.EditKH_BLL(GetKHOnForm())) MessageBox.Show("Edit thành công!!!");
            else MessageBox.Show("Gặp lỗi khi Edit!!!");
            refreshData();
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                string MaNV = dataGridView1.CurrentRow.Cells["ID_KH"].Value.ToString();
                if (QLKH_BLL.Instance.DelKH_BLL(MaNV))
                {
                    MessageBox.Show("Đã xóa thành công!!!");
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = QLKH_BLL.Instance.GetAllRecordKH_BLL();
                }
                else MessageBox.Show("Gặp lỗi khi xóa!!!");

            }
        }

        private void butThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void SetCBBSort()
        {
            cbbSort.Items.AddRange(new object[]{
                "ID_KH","TenKH","CMND","NgaySinh"
            });
            cbbSort.SelectedIndex = 0;
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            string t = cbbSort.SelectedItem.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = QLKH_BLL.Instance.SortKH_BLL(t);
        }

        private void buttonGoiY_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

                string ID_KH = dataGridView1.CurrentRow.Cells["ID_KH"].Value.ToString();
                GoiY gy = new GoiY(ID_KH);
                gy.ShowDialog();
                refreshData();
                //if (QLKH_BLL.Instance.DelKH_BLL(MaNV))
                //{
                //    MessageBox.Show("Đã xóa thành công!!!");
                //    dataGridView1.DataSource = null;
                //    dataGridView1.DataSource = QLKH_BLL.Instance.GetAllRecordKH_BLL();
                //}
                //else MessageBox.Show("Gặp lỗi khi xóa!!!");

            }

        }

        private void buttonDGia_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

                string ID_KH = dataGridView1.CurrentRow.Cells["ID_KH"].Value.ToString();
                DanhGia nv = new DanhGia(ID_KH);
                nv.ShowDialog();
                refreshData();
                //if (QLKH_BLL.Instance.DelKH_BLL(MaNV))
                //{
                //    MessageBox.Show("Đã xóa thành công!!!");
                //    dataGridView1.DataSource = null;
                //    dataGridView1.DataSource = QLKH_BLL.Instance.GetAllRecordKH_BLL();
                //}
                //else MessageBox.Show("Gặp lỗi khi xóa!!!");

            }

        }

        private void QLKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) butThoat.PerformClick();
        }
    }
}
