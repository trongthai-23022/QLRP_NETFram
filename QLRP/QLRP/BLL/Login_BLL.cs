using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLRP.DTO;
using QLRP.DAL;
namespace QLRP.BLL
{
    class Login_BLL
    {
        private static Login_BLL _instance;

        public static Login_BLL Instance
        {
            get
            {
                if (_instance == null) _instance = new Login_BLL();

                return _instance;
            }
            private set { _instance = value; }
        }
        private Login_BLL()
        {

        }
        public List<Login> GetAllTaiKhoan_BLL()
        {
            return Login_DAL.Instance.GetAllTaiKhoan_DAL();
        }
        public bool Check_BLL(string a)
        {
            if (Login_DAL.Instance.Check_DAL(a)) return true;
            else return false;
        }
       
    }
}