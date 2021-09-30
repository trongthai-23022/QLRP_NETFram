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
using System.IO;
namespace QLRP
{
    public partial class GoiY : Form
    {
        //public double[,] dudoan(double[,] matrix0, int m, int n)
        //{
        //    double[,] matrix = new double[m + 2, n + 2];
        //    double Tong = 0;
        //    //Buoc 1 tinh TB
        //    //sao chep maxtrix0 => matrix hang cuoi cung tinh gia tri TB
        //    for (int i = 0; i <= m; i++)
        //    {
        //        for (int j = 0; j <= n - 1; j++)
        //        {
        //            matrix[i, j] = matrix0[i, j];
        //            // hang cuoi m + 1 
        //            if (i == m)
        //            {
        //                double count = m; //bang so phan tu trong cot j
        //                //Tong cac cot
        //                for (int k = 0; k <= m - 1; k++)
        //                { //k = phan tu trong cot hang thu j
        //                    Tong += matrix0[k, j];
        //                    // neu co phan tu = 0 thi khong lay
        //                    if (matrix0[k, j] == 0)
        //                    {
        //                        count--;
        //                    }
        //                }
        //                //Trung binh cac cot
        //                matrix[i, j] = Tong / count;
        //            }
        //        }
        //    }


        //    //Buoc 2 Chuan hoa du lieu
        //    for (int i = 0; i <= m - 1; i++)
        //    {
        //        for (int j = 0; j <= n - 1; j++)
        //        {
        //            if (matrix[i, j] != 0)  // neu phan tu != 0 thi chuan hoa.....
        //                matrix[i, j] -= matrix[m, j];
        //        }
        //    }

        //    //Buoc 3 Lap ma tran tuong quan
        //    double[,] similar = new double[n + 1, n + 1];
        //    double[] dodaivector = new double[n + 1]; // ma tran chua do dai vector cot n
        //    for (int i = 0; i <= n - 1; i++)
        //    {// chay tu phan tu 1 den n
        //        double tongbinhphuong = 0;
        //        for (int j = 0; j <= m - 1; j++)
        //        { // chay tu phan tu 1 den m cua cac cot i
        //            tongbinhphuong += matrix[j, i] * matrix[j, i];
        //        }
        //        dodaivector[i] = Math.Sqrt(tongbinhphuong); // Do dai cua cac vector cot i
        //    }
        //    //tao ma tran tuong quan n x n
        //    for (int i = 0; i <= n - 1; i++)
        //    {
        //        for (int j = 0; j <= n - 1; j++)
        //        {
        //            double tichvector = 0;
        //            double tichmodule = dodaivector[i] * dodaivector[j]; // tich do dai cua vector
        //            for (int k = 0; k <= m - 1; k++)
        //            {
        //                tichvector += (matrix[k, i] * matrix[k, j]); // tich cac phan tu cua cac vector
        //            }
        //            similar[i, j] = tichvector / tichmodule;// ma tran tuong quan ra doi
        //        }
        //    }
        //    //Buoc 4 Tim cac cuc dai tuong quan
        //    // chu y o day chon user0 la khach hang can goi y 
        //    // chi tinh user0 thoi

        //    for(int i = 0; i <= n - 1; i++)
        //    {
        //        double max1 = 0;
        //        double max2 = 0;
        //        int vitrimax1 = 0;
        //        int vitrimax2 = 0;
        //        for (int k = 0; k <= n - 1; k++)
        //        {
        //            if(similar[i,k] != 1)
        //            {
        //                max1 = Math.Max(similar[i, k], max1);
        //            }
        //        }
        //        for (int k = 0; k <= n - 1; k++)
        //        {
        //            if (similar[i, k] == max1)
        //            {
        //                vitrimax1 = k;          // tim user thu i tuong quan nhat
        //            }
        //            else if(similar[i,k] != 1)
        //            {
        //                max2 = Math.Max(similar[i, k], max2);//tim gia tri tuong quan nhi tru max1
        //            }

        //        }
        //        for (int k = 0; k <= n - 1; k++)
        //        {
        //            if (similar[i, k] == max2)
        //            {
        //                vitrimax2 = k;      // tim user thu i tuong quan nhi
        //            }
        //        }
        //        for (int j = 0; j <= m -1; j++)
        //        {
        //            if(matrix[j,i] == 0)
        //            {
        //                matrix[j, i] = (max1 * matrix[j, vitrimax1] + max2 * matrix[j, vitrimax2]) / (Math.Abs(max1) + Math.Abs(max2));
        //            }

        //        }
        //    }

        //    //Buoc 5 Du doan danh gia user0 doi voi san pham
        //    //Buoc 6 Dao nguoc chuan hoa
        //    for (int i = 0; i <= m - 1; i++)
        //    {
        //        matrix[i, 0] += matrix[m, 0];
        //    }
        //    return matrix;
        //}

        public GoiY(string ID_KH)
        {
            InitializeComponent();
            DGia_BLL.Instance.RefreshDATA_BLL();
            dataGridView1.DataSource = DGia_BLL.Instance.GetDSGOIYByID_KH_BLL(ID_KH);
        }
        public void Show(string ID_KH)
        {
            double[,] matrix = DGia_BLL.Instance.GetMatrix_BLL();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string ma = dataGridView1.CurrentRow.Cells["MaPhim"].Value.ToString();
                PH phim = DGia_BLL.Instance.GetPHByMAPHM_BLL(ma);
                txtMaPhim.Text = phim.MaPhim;
                txtTenPhim.Text = phim.TenPhim;
                txtNamSX.Text = phim.NamSX;
                txtDaoDien.Text = phim.DaoDien;
                txtQuocgia.Text = phim.QuocGia;
                txtThoiGian.Text = phim.ThoiLuong;
                txtTheLoai.Text = phim.TheLoai;
                txtLichChieu.Text = DGia_BLL.Instance.GetLCByMAPHIM_BLL(ma);
                pictureBox1.Image = ByteArrayToImage(phim.HinhAnh);
                //Loi nhung co le la do chua co anh trong csdl
            }
        }

        //public double[,] Matrandudoan()
        //{
        //    int m = DGia_BLL.Instance.SoPhim_m_BLL();
        //    int n = DGia_BLL.Instance.SoKH_n_BLL();
        //    double[,] matrix = DGia_BLL.Instance.GetMatrix_BLL();
        //    return dudoan(matrix,m,n);

        //}
        //public List<DGia>GetDSGOIYByID_KH(string ID)
        //{
        //    List<DGia> dg = DGia_BLL.Instance.GetALLDgia_BLL();
        //    DGia[] DG = dg.ToArray();
        //    int m = DGia_BLL.Instance.SoPhim_m_BLL();
        //    int n = DGia_BLL.Instance.SoKH_n_BLL();
        //    double[,] matrix = Matrandudoan();
        //    int k = 0;
        //    for(int i = 0; i <= m -1; i++)
        //    {
        //        for(int j = 0; j <= n -1; j++)
        //        {
        //            if (DG[k].DanhGia == 0)
        //            {
        //                DG[k].DanhGia = matrix[i,j];
        //            }
        //             k++;
        //        }
        //    }
        //    List<DGia> DGm = new List<DGia>();
        //    foreach(DGia i in DG.ToList<DGia>())
        //    {
        //        if(i.ID_KH == ID)
        //        {
        //            DGm.Add(i);
        //        }

        //    }     
        //    return dg;
        //}
    }
}
