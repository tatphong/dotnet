using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    class DoanDAO
    {
        PMPhanLopEntities db = new PMPhanLopEntities();
        public IEnumerable load_doan()
        {
            //var res = db.doans.ToList();
            var res = from c in db.doans
                      select new
                      {
                          MaDoan = c.iddoan,
                          TenDoan = c.tendoan,
                          TenTour = c.tour.tentour,
                          NgayKhoiHanh = c.ngaykhoihanh,
                          NgayKetThuc = c.ngayketthuc,
                          TongChiPhi = c.tongchiphi
                      };
            return res.ToList();
        }

        public int add_doan(int idtour, String tendoan, DateTime ngaykhoihanh, DateTime ngayketthuc, int tongchiphi)
        {
            doan a = new doan()
            {
                idtour = idtour,
                tendoan = tendoan,
                ngaykhoihanh = ngaykhoihanh,
                ngayketthuc = ngayketthuc,
                tongchiphi = tongchiphi
            };
            db.doans.Add(a);
            db.SaveChanges();
            return a.iddoan;
        }

        public int edit_doan(int iddoan, String tentour, String tendoan, DateTime ngaykhoihanh, DateTime ngayketthuc, int tongchiphi)
        {
            doan d = db.doans.Find(iddoan);
            d.idtour = new TourDAO().getID_via_name(tentour);
            d.tendoan = tendoan;
            d.ngaykhoihanh = ngaykhoihanh;
            d.ngayketthuc = ngayketthuc;
            d.tongchiphi = tongchiphi;
            db.SaveChanges();
            return 1;
        }
        public void delete_doan(int iddoan)
        {
            doan d = db.doans.Where(p => p.iddoan == iddoan).SingleOrDefault();
            db.doans.Remove(d);
            db.SaveChanges();
        }

        public IEnumerable search(String s)
        {
            var res = db.doans.Where(p => p.tour.tentour.Contains(s) || p.tendoan.Contains(s)).ToList();
            return res;
        }
    }
}
