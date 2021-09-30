using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLRP.DTO;
using QLRP.DAL;
namespace QLRP.BLL
{
    class DGia_BLL
    {
        private static DGia_BLL _instance;

        public static DGia_BLL Instance
        {
            get
            {
                if (_instance == null) _instance = new DGia_BLL();

                return _instance;
            }
            private set { _instance = value; }
        }
        private DGia_BLL()
        {

        }
        public double[,] GetMatrix_BLL()
        {
            return DGia_DAL.Instance.GetMaTrix_DAL();
        }
        public void RefreshDATA_BLL()
        {
            DGia_DAL.Instance.UpdateKHtoDANHGIA_DAL();
        }
        public int SoPhim_m_BLL()
        {
            return DGia_DAL.Instance.SoPhim_m_DAL();
        }
        public int SoKH_n_BLL()
        {
            return DGia_DAL.Instance.SoKH_n_DAL();
        }
        public List<DGia> GetALLDgia_BLL()
        {
            return DGia_DAL.Instance.GetAllRecordDG_DAL();
        }
        public double[,] dudoan(double[,] matrix0, int m, int n)
        {
            double[,] matrix = new double[m + 2, n + 2];

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
                        double Tong = 0;
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
                        matrix[m, j] = Tong / count;
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
                    tongbinhphuong += (matrix[j, i] * matrix[j, i]);
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

            for (int i = 0; i <= n - 1; i++)
            {
                double max1 = 0;
                double max2 = 0;
                int vitrimax1 = 0;
                int vitrimax2 = 0;
                for (int k = 0; k <= n - 1; k++)
                {
                    if (similar[i, k] != 1)
                    {
                        max1 = Math.Max(similar[i, k], max1);
                    }
                }
                for (int k = 0; k <= n - 1; k++)
                {
                    if (similar[i, k] == max1)
                    {
                        vitrimax1 = k;          // tim user thu i tuong quan nhat
                    }
                    else if (similar[i, k] != 1)
                    {
                        max2 = Math.Max(similar[i, k], max2);//tim gia tri tuong quan nhi tru max1
                    }

                }
                for (int k = 0; k <= n - 1; k++)
                {
                    if (similar[i, k] == max2)
                    {
                        vitrimax2 = k;      // tim user thu i tuong quan nhi
                    }
                }
                for (int j = 0; j <= m - 1; j++)
                {
                    if (matrix[j, i] == 0)
                    {
                        matrix[j, i] = (max1 * matrix[j, vitrimax1] + max2 * matrix[j, vitrimax2]) / (Math.Abs(max1) + Math.Abs(max2));
                    }

                }
            }

            //Buoc 5 Du doan danh gia user0 doi voi san pham
            //Buoc 6 Dao nguoc chuan hoa
            for (int i = 0; i <= m - 1; i++)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    matrix[i, j] += matrix[m, j];
                }
            }

            return matrix;
        }
        public double[,] Matrandudoan()
        {
            int m = DGia_BLL.Instance.SoPhim_m_BLL();
            int n = DGia_BLL.Instance.SoKH_n_BLL();
            double[,] matrix = DGia_BLL.Instance.GetMatrix_BLL();
            return dudoan(matrix, m, n);

        }
        public List<DGia> GetDSGOIYByID_KH_BLL(string ID)
        {
            List<DGia> dg = DGia_BLL.Instance.GetALLDgia_BLL();
            DGia[] DG = dg.ToArray();
            int m = DGia_BLL.Instance.SoPhim_m_BLL();
            int n = DGia_BLL.Instance.SoKH_n_BLL();
            double[,] matrix = Matrandudoan();
            int k = 0;
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j <= m - 1; j++)
                {

                    DG[k].DanhGiaDUDOAN = matrix[j, i];

                    k++;
                }
            }
            List<DGia> DGm = new List<DGia>();
            foreach (DGia i in DG.ToList<DGia>())
            {
                DateTime a = DateTime.Now;
                DateTime b = Convert.ToDateTime(DGia_BLL.Instance.GetLCByMAPHIM_BLL(i.MaPhim));
                if (i.ID_KH == ID && b >= a)
                {
                    DGm.Add(i);
                }

            }
            return DGm;
        }

        public string GetLCByMAPHIM_BLL(string ma)
        {
            return DGia_DAL.Instance.GetLCbyMAPHIM(ma);
        }
        public PH GetPHByMAPHM_BLL(string ma)
        {
            return DGia_DAL.Instance.GetPHByMaPhim_DAL(ma);
        }
        public List<PH> GetPHNOW_BLL()
        {
            List<PH> phim = new List<PH>();
            PH ph = new PH();
            foreach (DataRow i in QLP_BLL.Instance.GetAllRecordPhim_BLL().Rows)
            {
                ph = DGia_DAL.Instance.GetONEPH_DAL(i);
                DateTime a = DateTime.Today;
                DateTime b = Convert.ToDateTime(GetLCByMAPHIM_BLL(ph.MaPhim));
                if (b >= a)
                {
                    phim.Add(ph);
                }

            }



            return phim;
        }
        public void GuiDanhGia_BLL(string KH, string MaPhim, string sao)
        {
            DGia_DAL.Instance.GuiDanhGia_DAL(KH, MaPhim, sao);
        }
    }
}
