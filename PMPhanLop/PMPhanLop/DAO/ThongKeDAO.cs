using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    class ThongKeDAO
    {
        PMPhanLopEntities db = new PMPhanLopEntities();

        //public IEnumerable thongkechiphi()
        //{
        //    var res = from c in db.chiphis where ;
        //    return res;
        //}

        public IEnumerable TongLuotTourNV()
        {
            var nv = db.nhanviens.Select(p => p.idnhanvien).ToList();
            var dem = from c in db.phancongs
                      group db.phancongs.Count() by c.idnhanvien into temp
                      select new
                      {
                          MaNhanVien = temp.Key,
                          SoLuotTour = temp.Count()
                      };
            var res = from c in db.nhanviens
                      join d in dem on c.idnhanvien equals d.MaNhanVien into temp
                      from t in temp
                      select new {
                          MaNhanVien = t.MaNhanVien,
                          TenNhanVien = c.hotennv,
                          SoLuotTour = t.SoLuotTour
                      };
            return res.ToList();
        }

        public IEnumerable doanhso_doan()
        {
            var danhsachdoan = db.doans.Select(p => new { MaDoan = p.iddoan, TenDoan = p.tendoan });
            List<Object> res = new List<object>();
            foreach (var dn in danhsachdoan)
            {
                int iddoan = dn.MaDoan;
                var gia_chiphi = db.doans.Where(p => p.iddoan == iddoan).Select(p => new { chiphi = p.tongchiphi, gia = p.gia }).SingleOrDefault();
                var sokhachdoan = (from c in db.chitietdoans
                                   where c.iddoan == iddoan
                                   group db.chitietdoans.Count() by c.iddoan into temp
                                   select temp.Count()
                                   ).SingleOrDefault();
                int sokhach = Convert.ToInt32(sokhachdoan);
                int doanhthu = sokhach * Convert.ToInt32(gia_chiphi.gia) - Convert.ToInt32(gia_chiphi.chiphi);
                res.Add(new
                {
                    MaDoan = iddoan,
                    TenDoan = dn.TenDoan,
                    DoanhThu = doanhthu
                });
            }
            return res;
        }

        public IEnumerable doanhso_tour()
        {
            var danhsachtour = from c in db.doans
                         group db.doans.Count() by c.idtour into temp
                         select new
                         {
                             MaTour = temp.Key,
                             SoDoan = temp.Count()
                         };

            List<Object> res = new List<Object>();

            foreach (var d in danhsachtour)
            {
                int idtour = Convert.ToInt32(d.MaTour);
                string tentour = db.tours.Where(p=>p.idtour == idtour).Select(p=>p.tentour).SingleOrDefault();
                var danhsachdoan = db.doans.Where(p => p.idtour == idtour).Select(p => new { MaDoan = p.iddoan });
                int doanhthu = 0;
                foreach (var dn in danhsachdoan)
                {
                    int iddoan = dn.MaDoan;
                    var gia_chiphi = db.doans.Where(p => p.iddoan == iddoan).Select(p => new { chiphi = p.tongchiphi, gia = p.gia }).SingleOrDefault();
                    var sokhachdoan = (from c in db.chitietdoans
                                       where c.iddoan == iddoan
                                       group db.chitietdoans.Count() by c.iddoan into temp
                                       select temp.Count()
                                       ).SingleOrDefault();
                    int sokhach = Convert.ToInt32(sokhachdoan);
                    doanhthu += sokhach * Convert.ToInt32(gia_chiphi.gia) - Convert.ToInt32(gia_chiphi.chiphi);
                }
                res.Add(new {
                    MaTour = idtour,
                    TenTour = tentour,
                    DoanhThu = doanhthu,
                    SoDoan = d.SoDoan
                });
            }
            return res;
        }

        public IEnumerable chiphitour()
        {
            var danhsachtour = db.tours.Select(p => new { MaTour = p.idtour, TenTour = p.tentour });
            List<Object> res = new List<object>();

            foreach (var t in danhsachtour)
            {
                int idtour = t.MaTour;
                string tentour = db.tours.Where(p => p.idtour == idtour).Select(p => p.tentour).SingleOrDefault();
                var danhsachchiphi = db.chiphis.Where(p=>p.idtour == idtour).Select(p => 
                    new { LoaiCP = p.idloaicp, TongTien = p.tongtien });
                int cp1 = 0;
                int cp2 = 0;
                int cp3 = 0;
                int cp4 = 0;
                foreach (var cp in danhsachchiphi)
                {
                    if (cp.LoaiCP == 1) cp1 = Convert.ToInt32(cp.TongTien);
                    if (cp.LoaiCP == 2) cp2 = Convert.ToInt32(cp.TongTien);
                    if (cp.LoaiCP == 3) cp3 = Convert.ToInt32(cp.TongTien);
                    if (cp.LoaiCP == 4) cp4 = Convert.ToInt32(cp.TongTien);
                }
                res.Add(new
                {
                    MaTour = idtour,
                    TenTour = tentour,
                    PhiAnUong = cp1,
                    PhiKhachSan = cp2,
                    PhiVaoCong = cp3,
                    PhiDiChuyen = cp4
                });
            }
            return res;
        }
    }
}
