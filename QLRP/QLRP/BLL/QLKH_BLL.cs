using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLRP.DAL;
using QLRP.DTO;
namespace QLRP.BLL
{
    class QLKH_BLL
    {

        private static QLKH_BLL _instance;

        public static QLKH_BLL Instance
        {
            get
            {
                if (_instance == null) _instance = new QLKH_BLL();

                return _instance;
            }
            private set { _instance = value; }
        }
        private QLKH_BLL()
        {

        }
        public List<KH> GetAllRecordKH_BLL()
        {
            return QLKH_DAL.Instance.GetAllRecordKH_DAL();
        }
        public string GetCMNDKH(string name)
        {
            string ma = "";
            foreach (KH i in QLKH_DAL.Instance.GetAllRecordKH_DAL())
            {
                if (i.CMND == name) ma = i.CMND.ToString();
            }
            return ma;
        }
        public bool AddKH_BLL(KH a)
        {
            if (QLKH_DAL.Instance.AddKH_DAL(a)) return true;
            else return false;
        }
        public bool EditKH_BLL(KH a)
        {
            if (QLKH_DAL.Instance.EditKH_DAL(a)) return true;
            else return false;
        }
        public bool DelKH_BLL(string ma)
        {
            if (QLKH_DAL.Instance.DelKH_DAL(ma)) return true;
            else return false;
        }
        public delegate bool Compare(KH a, KH b);
        public List<KH> SortKH_BLL(string t)
        {
            if (t == "ID_KH")
            {
                return SortKH1_BLL(KH.CompareIDKH);
            }
            else if (t == "TenKH") return SortKH1_BLL(KH.CompareTen);
            else if (t == "NgaySinh") return SortKH1_BLL(KH.CompareNS);
            else return SortKH1_BLL(KH.CompareCMND);
        }
        public List<KH> SortKH1_BLL(Compare k)
        {

            List<KH> list = new List<KH>();
            list = QLKH_BLL.Instance.GetAllRecordKH_BLL();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (k(list[i], list[j]))
                    {
                        KH b = new KH();
                        b = list[i];
                        list[i] = list[j];
                        list[j] = b;
                    }


                }
            }

            return list;
        }
    }
}
