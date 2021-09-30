using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLRP.DTO;
namespace QLRP.DAL
{
    class QLP_DAL
    {
        private static QLP_DAL _instance;

        public static QLP_DAL Instance
        {
            get
            {
                if (_instance == null) _instance = new QLP_DAL();

                return _instance;
            }
            private set { _instance = value; }
        }
        private QLP_DAL()
        {

        }
        public DataTable GetAllRecordPhim_DAL()
        {
            string query = "Select * from PHIM";
            return DBHelper.Instance.GetRecord(query);
        }
        public List<string> GetAllRecordTenPhim_DAL()
        {
            List<string> st = new List<string>();
            string query = "Select TenPhim from PHIM";
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                st.Add(GetOneTenPhim_DAL(i));
            }
            return st;
        }
        public string GetOneTenPhim_DAL(DataRow i)
        {
            string name = "";
            name = i["TenPhim"].ToString();
            return name;
        }
        public List<PH1> GetAllRecordTTPhim_DAL()
        {
            List<PH1> p = new List<PH1>();
            string query = "Select MaPhim,TenPhim from PHIM";
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                p.Add(GetOneTTPhim_DAL(i));
            }
            return p;
        }
        public PH1 GetOneTTPhim_DAL(DataRow i)
        {
            PH1 p1 = new PH1();
            p1.MaPhim = i["MaPhim"].ToString();
            p1.TenPhim = i["TenPhim"].ToString();
            return p1;
        }
        public List<TheLoai> GetAllRecordTheLoai()
        {
            string query = "Select * from THELOAI";
            List<TheLoai> tl = new List<TheLoai>();
            foreach(DataRow i in DBHelper.Instance.GetRecord(query).Rows){
            tl.Add(GetOneTL_DAL(i));
            }
            return tl;
        }

        public TheLoai GetOneTL_DAL(DataRow i)
        {
            TheLoai a = new TheLoai();
            a.id = Convert.ToInt32(i["ID"].ToString());
            a.Theloai = i["TheLoai"].ToString();
            return a;
        }
        public bool AddPhim_DAL1(PH a)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO PHIM VALUES(@ma,@ten,@daodien,@quocgia,@namsx,@thoiluong,@theloai,@hinhanh)");
            cmd.Parameters.Add("@ma", a.MaPhim);
            cmd.Parameters.Add("@ten", a.TenPhim);
            cmd.Parameters.Add("@daodien", a.DaoDien);
            cmd.Parameters.Add("@quocgia", a.QuocGia);
            cmd.Parameters.Add("@namsx", a.NamSX);
            cmd.Parameters.Add("@thoiluong", a.ThoiLuong);
            cmd.Parameters.Add("@theloai", a.TheLoai);
            cmd.Parameters.Add("@hinhanh", a.HinhAnh);
            DBHelper.Instance.ExcuteDB1(cmd);
            return true;
        }
        public bool EditPhim_DAL1(PH a)
        {

            SqlCommand cmd = new SqlCommand("UPDATE dbo.PHIM Set TenPhim = @ten,DaoDien=@daodien,QuocGia = @quocgia,NamSX=@namsx,ThoiLuong = @thoiluong,TheLoai = @theloai,HinhAnh= @hinhanh where MaPhim = @ma");
         
            cmd.Parameters.Add("@ten", a.TenPhim);
            cmd.Parameters.Add("@daodien", a.DaoDien);
            cmd.Parameters.Add("@quocgia", a.QuocGia);
            cmd.Parameters.Add("@namsx", a.NamSX);
            cmd.Parameters.Add("@thoiluong", a.ThoiLuong);
            cmd.Parameters.Add("@theloai", a.TheLoai);
            cmd.Parameters.Add(new SqlParameter("@hinhanh", SqlDbType.Image)).Value = a.HinhAnh;
            cmd.Parameters.Add("@ma", a.MaPhim);
            DBHelper.Instance.ExcuteDB1(cmd);
            return true;
        }
        public bool DelPH_DAL(string ma)
        {
            try
            {
                //SqlCommand cmd = new SqlCommand("DELETE dbo.PHIM where MaPhim = @ma");
                //cmd.Parameters.Add("@ma", ma);
                string query = "DELETE dbo.PHIM where MaPhim = N'" + ma + "'";
                DBHelper.Instance.ExcuteDB(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }  
}
