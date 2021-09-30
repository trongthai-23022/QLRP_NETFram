using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLRP.DTO;
using System.Data;

namespace QLRP.DAL
{
    class DGia_DAL
    {
        private static DGia_DAL _instance;

        public static DGia_DAL Instance
        {
            get
            {
                if (_instance == null) _instance = new DGia_DAL();

                return _instance;
            }
            private set { _instance = value; }
        }
        private DGia_DAL()
        {

        }
        public DGia GetOneDGia_DAL(DataRow i)
        {
            DGia a = new DGia();
            a.ID_KH = i["ID_KH"].ToString();
            a.MaPhim = i["MaPhim"].ToString();
            a.DanhGiaDUDOAN = Convert.ToDouble(i["DanhGia"].ToString());
            return a;
        }
        public List<DGia> GetAllRecordDG_DAL()
        {
            string query = "Select * from DANHGIA";
            List<DGia> dg = new List<DGia>();
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                dg.Add(GetOneDGia_DAL(i));
            }
            return dg;

        }
        public List<DGia> GetByID_KH_DAL(string Id)
        {
            string query = "SELECT * FROM DANHGIA WHERE ID_KH = '" + Id + "'";
            List<DGia> dg = new List<DGia>();
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                dg.Add(GetOneDGia_DAL(i));
            }
            return dg;
        }
        public List<DGia> GetByID_Phim_DAL(string Id)
        {
            string query = "SELECT * FROM DANHGIA WHERE MaPhim = '" + Id + "'";
            List<DGia> dg = new List<DGia>();
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                dg.Add(GetOneDGia_DAL(i));
            }
            return dg;
        }
        public void UpdateKHtoDANHGIA_DAL()
        {
            string query = "insert into DANHGIA  SELECT ID_KH, MaPhim, DanhGia = '0' FROM KH, PHIM  EXCEPT  SELECT ID_KH,MaPhim,DanhGia = '0' FROM DANHGIA ORDER BY ID_KH,MaPhim";
            DBHelper.Instance.GetRecord(query);
        }
        public int SoPhim_m_DAL()
        {
            string query = "select * from PHIM";
            return DBHelper.Instance.GetRecord(query).Rows.Count;
        }
        public int SoKH_n_DAL()
        {
            string query = "select * from KH";
            return DBHelper.Instance.GetRecord(query).Rows.Count;
        }
        public double[,] GetMaTrix_DAL()
        {
            int m = SoPhim_m_DAL();
            int n = SoKH_n_DAL();

            double[,] matrix = new double[m + 1, n + 1];
            List<DGia> dg = GetAllRecordDG_DAL();
            DGia[] matran = new DGia[m * n + 1];
            matran = dg.ToArray();
            int k = 0;
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j <= m - 1; j++)
                {
                    matrix[j, i] = matran[k].DanhGiaDUDOAN;
                    k++;
                }
            }
            return matrix;

        }
        public string GetLCbyMAPHIM(string ma)
        {
            string query = "select TimeChieu from LICHCHIEU where MaPhim ='" + ma + "' ";
            string l = null;
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                l = i["TimeChieu"].ToString();
            }
            return l;
        }
        public PH GetPHByMaPhim_DAL(string ma)
        {
            string query = "select * from PHIM where MaPhim ='" + ma + "'";
            PH ph = new PH();
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                ph = GetONEPH_DAL(i);
            }
            return ph;
        }
        public PH GetONEPH_DAL(DataRow i)
        {
            PH a = new PH();
            a.TenPhim = i["TenPhim"].ToString();
            a.MaPhim = i["MaPhim"].ToString();
            a.TheLoai = i["TheLoai"].ToString();
            a.QuocGia = i["QuocGia"].ToString();
            a.NamSX = i["NamSX"].ToString();
            a.ThoiLuong = i["ThoiLuong"].ToString();
            a.HinhAnh = (byte[])i["HinhAnh"];// loi co le do chua co anh trong csdl
            a.DaoDien = i["DaoDien"].ToString();
            return a;
        }
        public void GuiDanhGia_DAL(string KH, string MaPhim, string sao)
        {
            string query = "UPDATE DANHGIA set DanhGia ='" + sao + "' where ID_KH ='" + KH + "' and MaPhim = '" + MaPhim + "'";
            DBHelper.Instance.ExcuteDB(query);
        }
    }
}
