using Microsoft.AspNetCore.Mvc;
using NguyenThiThuUyen_211203739.Models;


namespace NguyenThiThuUyen_211203739.ViewComponents
{
	
	public class RenderViewComponent: ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			QLHangHoaContext db = new QLHangHoaContext();
			List<LoaiHang> listLoai = db.LoaiHangs.ToList();
			return View("RenderHeaderNav", listLoai);
		}

	}
}
