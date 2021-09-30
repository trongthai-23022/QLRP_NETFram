using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLRP.DTO;
using System.Data;
using System.Data.SqlClient;
namespace QLRP.DAL
{
    class QLKH_DAL
    {
        private static QLKH_DAL _instance;

        public static QLKH_DAL Instance
        {
            get
            {
                if (_instance == null) _instance = new QLKH_DAL();

                return _instance;
            }
            private set { _instance = value; }
        }
        private QLKH_DAL()
        {

        }
        public List<KH> GetAllRecordKH_DAL()
        {
            string query = "Select * from KH";
            List<KH> kh = new List<KH>();
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                kh.Add(GetOneKH_DAL(i));
            }
            return kh;

        }
        public KH GetOneKH_DAL(DataRow i)
        {
            KH a = new KH();
            a.ID_KH = i["ID_KH"].ToString();
            a.TenKH = i["TenKH"].ToString();
            a.CMND = i["CMND"].ToString();
            a.SoDienThoai = i["SoDienThoai"].ToString();
            a.NgaySinh = Convert.ToDateTime(i["NgaySinh"].ToString());
            a.DiaChi = i["DiaChi"].ToString();
            a.GioiTinh = Convert.ToBoolean(i["GioiTinh"].ToString());
            return a;
        }
        public bool AddKH_DAL(KH a)
        {
            try
            {
                string t = "EXEC USP_InserKH N'";
                t += a.ID_KH + "', N'" + a.TenKH + "', '" + a.CMND + "', '" + a.SoDienThoai + "', '" + a.NgaySinh + "', N'" + a.DiaChi + "', " + a.GioiTinh;
                DBHelper.Instance.ExcuteDB(t);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditKH_DAL(KH a)
        {
            //try
            //{
            //SqlCommand cmd = new SqlCommand("UPDATE dbo.KH set TenKH = @name,CMND =@cmnd,SoDienThoai =@sdt,NgaySinh= @ngaysinh,DiaChi =@dc,GioiTinh = @gt where ID_KH =@id");

            //cmd.Parameters.AddWithValue("@name", a.TenKH);
            //cmd.Parameters.AddWithValue("@cmnd", a.CMND);
            //cmd.Parameters.AddWithValue("@sdt", a.SoDienThoai);
            //cmd.Parameters.AddWithValue("@ngaysinh", a.NgaySinh);
            //cmd.Parameters.AddWithValue("@dc", a.DiaChi);
            //cmd.Parameters.AddWithValue("@gt", a.GioiTinh);
            //cmd.Parameters.AddWithValue("@id", a.ID_KH);


                string t = "UPDATE dbo.KH set TenKH =  N'" + a.TenKH + "', CMND = '" +
                    a.CMND + "', SoDienThoai = '" + a.SoDienThoai + "',NgaySinh = '" + a.NgaySinh + "',DiaChi = N'" +
                    a.DiaChi + "',GioiTinh = " + Convert.ToInt32(a.GioiTinh) + "where ID_KH = N'" + a.ID_KH + "'"; 
                //string t = "EXEC USP_UPDATEKH N'";
                //t += a.ID_KH + "', N'" + a.TenKH + "', '" + a.CMND + "', '" + a.SoDienThoai + "', '" + a.NgaySinh + "', N'" + a.DiaChi + "', " + Convert.ToInt32(a.GioiTinh);
                DBHelper.Instance.ExcuteDB(t);
                return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }
        public bool DelKH_DAL(string ma)
        {
            try
            {
                string query = " DELETE dbo.KH where ID_KH = N'" + ma + "'";
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
