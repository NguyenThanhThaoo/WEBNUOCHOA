using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBNUOCHOA.Models
{
    public class GioHang
    {
        QLNuocHoaEntities1 data = new QLNuocHoaEntities1();
     

        public int iMaNH { get; set; }
        public string sTenNH { get; set; }
        public string sHinhMinhHoa { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get
            {
                return iSoLuong * dDonGia;
            }
        }

        public GioHang(int ms)
        {
            iMaNH = ms;
            NUOCHOA s = data.NUOCHOAs.Single(n => n.MaNH == iMaNH);
            sTenNH = s.TenNH;
            sHinhMinhHoa = s.HinhMinhHoa;
            dDonGia = double.Parse(s.DonGia.ToString());
            iSoLuong = 1;
           
        }
    }
}