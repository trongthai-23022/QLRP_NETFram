using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRP.DTO
{
    class KH
    {
        public string ID_KH { get; set; }
        public string TenKH { get; set; }
        public string CMND { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh {get; set;}
        public static bool CompareIDKH(KH a, KH b)
        {
            if (String.Compare(a.ID_KH, b.ID_KH) < 0) return true;
            else return false;
        }
        public static bool CompareTen(KH a, KH b)
        {
            if (String.Compare(a.TenKH, b.TenKH) < 0) return true;
            else return false;
        }
        public static bool CompareCMND(KH a, KH b)
        {
            if (String.Compare(a.CMND, b.CMND) < 0) return true;
            else return false;
        }
        public static bool CompareNS(KH a, KH b)
        {
            if (a.NgaySinh.Year > b.NgaySinh.Year)
            {
                return true;
            }
            else return false;
        }
    }
    }

