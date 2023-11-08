using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenThiThuUyen_211203739.Models;

namespace NguyenThiThuUyen_211203739.Controllers
{
	public class BaiThiController : Controller
	{
		QLHangHoaContext db = new QLHangHoaContext();
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
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(string ma)
		{
			return View();
		}
		


	}
}
