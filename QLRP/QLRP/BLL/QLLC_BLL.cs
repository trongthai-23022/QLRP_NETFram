using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLRP.DTO;
using QLRP.DAL;
namespace QLRP.BLL
{
    class QLLC_BLL
    {
         private static QLLC_BLL _instance;

        public static QLLC_BLL Instance
        {
            get
            {
                if (_instance == null) _instance = new QLLC_BLL();

                return _instance;
            }
            private set { _instance = value; }
        }
        private QLLC_BLL()
        {


        }
        public List<LC> GetAllRecordLC_BLL()
        {
            return QLLC_DAL.Instance.GetAllRecordLC_DAL();

        }
        public bool AddLC_BLL(LC a)
        {
            if (QLLC_DAL.Instance.AddLC_DAL(a)) return true;
            else return false;
        }
        public bool EditLC_BLL(LC a)
        {
            if(QLLC_DAL.Instance.EditLC_DAL( a)) return true;
            else return false;
        }
        public bool DelLC_BLL(string malc)
        {
            if (QLLC_DAL.Instance.DelLC_DAL(malc)) return true;
            else return false;
        }
        public List<LC> GetLCByNamePhim_BLL(string name)
        {
            return QLLC_DAL.Instance.GetLCByNamePhim_DAL(name);
        }
    }
}
