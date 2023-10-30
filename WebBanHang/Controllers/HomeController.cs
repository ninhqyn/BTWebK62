using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Models;
using X.PagedList;
using WebBanHang.Models.Authenticaiton;
namespace WebBanHang.Controllers;

public class HomeController : Controller
{
        QlbanVaLiContext db = new QlbanVaLiContext();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [Authentication]
    public IActionResult Index(int? page)
    {
        //phân trang
        //orderby sắp xếp theo tên sp
        int pageSize = 8;
        int pageNumber = page == null || page < 0 ? 1 : page.Value;
        var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
        PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
        
        return View(lst);
        
    }

    public IActionResult SanPhamTheoLoai(String maloai,int? page)
    {
        int pageSize = 8;
        int pageNumber ;
        if(page == null || page < 0) pageNumber = 1;
            else pageNumber = page.Value;
        var lstsan = db.TDanhMucSps.AsNoTracking().Where(x=>x.MaLoai==maloai) .OrderBy(x => x.TenSp);
        PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsan, pageNumber, pageSize);

        ViewBag.maloai = maloai;
        return View(lst);
    }

    public IActionResult ChiTietSanPham(string maSp)
    {
        var sanpham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
        var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
        

        ViewBag.anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();

        return View(sanpham);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}