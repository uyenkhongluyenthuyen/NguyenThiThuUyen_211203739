using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenThiThuUyen_211203739.Models;

namespace NguyenThiThuUyen_211203739.Controllers
{
	public class BaiThiController : Controller
	{
        private QLHangHoaContext db = new QLHangHoaContext();

       
        public IActionResult Index()
		{
			var listHangHoa = db.HangHoas.Where(hh => hh.Gia >= 100).ToList();

			return View(listHangHoa);
		}
		public IActionResult HangHoabyCatID(int catID)
		{
			var listHangHoa = db.HangHoas
							 .Where(hh => hh.MaLoai == catID)
							 .ToList();
			return PartialView("NguyenThiThuUyen_MainContent", listHangHoa);
		}

		//theem 2 action
		[HttpGet]
		
		public IActionResult Create()
		{
			ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
            

            return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(HangHoa hangHoa)
		{
			ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
           
            if (ModelState.IsValid)
			{
                hangHoa.MaHang = db.HangHoas.ToList().Last<HangHoa>().MaHang + 1;
                db.Add(hangHoa);
				db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
		


	}
}
