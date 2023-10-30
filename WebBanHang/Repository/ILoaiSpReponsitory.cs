using WebBanHang.Models;

namespace WebBanHang.Repository;

public interface ILoaiSpReponsitory
{
    TLoaiSp Add(TLoaiSp loaiSp);

    TLoaiSp Update(TLoaiSp loaiSp);

    TLoaiSp Delete(TLoaiSp maLoaiSp);

    TLoaiSp GetLoaiSp(TLoaiSp maLoaiSp);

    IEnumerable<TLoaiSp> GetAllLoaiSp();
}