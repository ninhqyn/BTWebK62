using WebBanHang.Models;

namespace WebBanHang.Repository;

public class LoaiSpRepository : ILoaiSpReponsitory
{

    private readonly QlbanVaLiContext _context;

    public LoaiSpRepository(QlbanVaLiContext context)
    {
        _context = context;
    }

    public TLoaiSp Add(TLoaiSp loaiSp)
    {
        _context.TLoaiSps.Add(loaiSp);
        _context.SaveChanges();
        return loaiSp;
    }

    public TLoaiSp Update(TLoaiSp loaiSp)
    {
        _context.Update(loaiSp);
        _context.SaveChanges();
        return loaiSp;
    }

    public TLoaiSp Delete(TLoaiSp maLoaiSp)
    {
        throw new NotImplementedException();
    }

    public TLoaiSp GetLoaiSp(TLoaiSp maLoaiSp)
    {
        return _context.TLoaiSps.Find(maLoaiSp);
    }

    public IEnumerable<TLoaiSp> GetAllLoaiSp()
    {
        return _context.TLoaiSps;
    }
    
   
}