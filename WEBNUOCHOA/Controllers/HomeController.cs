using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBNUOCHOA.Models;
using PagedList.Mvc;
using System.Web.UI;

namespace WEBNUOCHOA.Controllers
{
    public class HomeController : Controller
    {
        QLNuocHoaEntities1 data = new QLNuocHoaEntities1();
        private dynamic iMaCD;

        public ActionResult Index()
        {
            var n = from nh in data.NUOCHOAs select nh;
            return View(n);
        }
        public ActionResult SanPhamMoiPartial()
        {
            int id = 2;

            var nuochoanu = from n in data.NUOCHOAs where n.MaCD == id select n;
            return PartialView(nuochoanu);
        }

        public ActionResult SanPhamBanNhieuPartial()
        {
            int id = 4;

            var nuochoanu = from n in data.NUOCHOAs where n.MaCD == id select n;
            return PartialView(nuochoanu);
        }

        public ActionResult HeaderPartial()
        {
            return PartialView();
        }
        public ActionResult Products(int iMaCD, int? page)
        {
            ViewBag.MaTH = iMaCD;
            //Tạo biến quy định số sản phẩm trên mỗi trang
            int iSize = 6;
            //Tạo biến số trang
            int iPageNum = (page ?? 1);
            var n = from nh in data.NUOCHOAs select nh;
            return View(n.OrderBy(m => m.MaNH).ToPagedList(iPageNum, iSize));
        }
        public ActionResult ChiTietNuocHoa(int id)
        {
            var nuochoa = from s in data.NUOCHOAs  where s.MaNH == id  select s;
            return View(nuochoa.Single());
        }
        public ActionResult NuocHoaNu()
        {
            int id = 2;

            var nuochoanu = from n in data.NUOCHOAs where n.MaCD == id select n;
            return PartialView(nuochoanu);

        }
        
    }
}