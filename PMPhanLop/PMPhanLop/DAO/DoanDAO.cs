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
                          TongChiPhi = c.tongchiphi,
                          Gia = c.gia
                      };
            return res.ToList();
        }

        public int add_doan(int idtour, String tendoan, DateTime ngaykhoihanh)
        {
            string tongcp = db.chiphis.Where(p => p.idtour == idtour).Sum(p => p.tongtien).ToString();
            int songaytour = Convert.ToInt32(db.tours.Where(p => p.idtour == idtour).Select(p => p.thoigiantour).SingleOrDefault());
            int gia = Convert.ToInt32(db.gias.Where(p=>p.idtour == idtour && p.ngaybatdau <= ngaykhoihanh && ngaykhoihanh <= p.ngayketthuc).Select(p=>p.giatour).SingleOrDefault());
            doan a = new doan()
            {
                idtour = idtour,
                tendoan = tendoan,
                ngaykhoihanh = ngaykhoihanh,
                ngayketthuc = ngaykhoihanh.AddDays(songaytour),
                tongchiphi = Convert.ToInt32(tongcp),
                gia = gia
            };
            db.doans.Add(a);
            db.SaveChanges();
            return a.iddoan;
        }

        public int edit_doan(int iddoan, String tentour, String tendoan, DateTime ngaykhoihanh)
        {
            doan d = db.doans.Find(iddoan);
            int idtour = new TourDAO().getID_via_name(tentour);
            int songaytour = Convert.ToInt32(db.tours.Where(p => p.idtour == idtour).Select(p => p.thoigiantour).SingleOrDefault());
            d.idtour = idtour;
            d.tendoan = tendoan;
            d.ngaykhoihanh = ngaykhoihanh;
            d.ngayketthuc = ngaykhoihanh.AddDays(songaytour);
            db.SaveChanges();
            return 1;
        }
        public void delete_doan(int iddoan)
        {
            List<chitietdoan> list = db.chitietdoans.Where(p => p.iddoan == iddoan).ToList();
            foreach (var item in list)
                db.chitietdoans.Remove(item);

            List<phancong> l2 = db.phancongs.Where(p => p.iddoan == iddoan).ToList();
            foreach (var item2 in l2)
                db.phancongs.Remove(item2);

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
