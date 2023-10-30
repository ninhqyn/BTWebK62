using WebBanHang.Repository;
namespace WebBanHang.ViewComponents;

using Microsoft.AspNetCore.Mvc;
public class LoaiSpMenuViewComponent : ViewComponent
{
    private readonly ILoaiSpReponsitory _loaiSp ;

    public LoaiSpMenuViewComponent(ILoaiSpReponsitory loaiSpReponsitory)
    {
        
        _loaiSp = loaiSpReponsitory;
    }


    public IViewComponentResult Invoke()
    {
        var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);

        return View(loaisp);
    }
    
}