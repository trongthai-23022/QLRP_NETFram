using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLRP.DTO;
using System.Data;
namespace QLRP.DAL
{
    class QLLC_DAL
    {
          private static QLLC_DAL _instance;

        public static QLLC_DAL Instance
        {
            get
            {
                if (_instance == null) _instance = new QLLC_DAL();

                return _instance;
            }
            private set { _instance = value; }
        }
        private QLLC_DAL()
        {


        }
        public List<LC> GetAllRecordLC_DAL()
        {
            string query = "Select * from LICHCHIEU";
            List<LC> a = new List<LC>();
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                a.Add(GetOneLC_DAL(i));
            }
            return a;

        }
        public LC GetOneLC_DAL(DataRow i)
        {
            LC a = new LC();
            a.MaLC = i["MaLC"].ToString();
            a.MaPhim = i["MaPhim"].ToString();
            a.MaRapPhim = i["MaRapPhim"].ToString();
            a.TenPhim = i["TenPhim"].ToString();
            a.TimeChieu = Convert.ToDateTime(i["TimeChieu"].ToString());
            return a;
            
        }
        public bool AddLC_DAL(LC a)
        {
            try
            {
                string t = "INSERT INTO LICHCHIEU VALUES('";
                t += a.MaLC + "', '" + a.MaPhim + "', '" + a.TenPhim + "', '" + a.MaRapPhim + "', '" + a.TimeChieu + "')" ;
                DBHelper.Instance.ExcuteDB(t);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }       
        public bool EditLC_DAL(LC a)
        {
            try
            {
                string t = "UPDATE dbo.LICHCHIEU set  MaPhim = N'"
                + a.MaPhim + "', TenPhim = N'" + a.TenPhim + "', MaRapPhim = N'" + a.MaRapPhim
                + "', TimeChieu ='" + a.TimeChieu + "' where MaLC = N'" + a.MaLC + "'";
                DBHelper.Instance.ExcuteDB(t);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DelLC_DAL(string malc)
        {
            try
            {


                string query = " DELETE dbo.LICHCHIEU where MaLC= N'" + malc + "'";
                DBHelper.Instance.ExcuteDB(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<LC> GetLCByNamePhim_DAL(string name)
        {
            List<LC>  a = new List<LC>();
            foreach (LC i in GetAllRecordLC_DAL())
            {
                if (i.TenPhim.ToUpper().Contains(name.ToUpper()))
                {
                    a.Add(i);
                }
            }
            return a;
        }
    }
}
