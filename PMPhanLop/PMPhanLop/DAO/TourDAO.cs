using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    public class TourDAO
    {
        PMPhanLopEntities db = new PMPhanLopEntities();
        public IEnumerable load_tour()
        {
            var res = from c in db.tours
                      select new
                      {
                          idtour = c.idtour,
                          tenloaidulich = c.loaidulich.tenloaidl,
                          tentour = c.tentour,
                          thoigiantour = c.thoigiantour
                      };
            return res.ToList();
        }

        public Array load_danh_sach_loai_tour()
        {
            var res = from c in db.loaiduliches
                      select c.tenloaidl;
            return res.ToArray();
        }

        public Array load_danh_sach_ten_tour()
        {
            var res = from c in db.tours
                      select c.tentour;
            return res.ToArray();
        }

        public int getID_via_name(String tentour)
        {
            //var res = db.tours.Find(tentour).idtour;
            var res = from c in db.tours where c.tentour == tentour select c.idtour;
            return res.ToArray()[0];
        }

        public int getIDLoaiDL_via_name(String tenloaidl)
        {
            var res = from c in db.loaiduliches where c.tenloaidl == tenloaidl select c.idloaidl;
            return res.ToArray()[0];
        }

        public int add_tour(String tenloaidl, String tentour, int thoigiantour)
        {
            int idloaidl = getIDLoaiDL_via_name(tenloaidl);
            db.tours.Add(new tour() { idloaidl = idloaidl, tentour = tentour, thoigiantour = thoigiantour });
            db.SaveChanges();
            return 1;
        }

        public int edit_tour(int idtour, int idloaidl, String tentour, int thoigiantour)
        {
            tour d = db.tours.Find(idtour);
            d.idloaidl = idloaidl;
            d.tentour = tentour;
            d.thoigiantour = thoigiantour;
            db.SaveChanges();
            return 1;
        }
        public void delete_tour(int idtour)
        {
            tour t = db.tours.Where(p => p.idtour == idtour).SingleOrDefault();
            db.tours.Remove(t);
            db.SaveChanges();
        }

        public IEnumerable search(String s)
        {
            var res = db.tours.Where(p => p.tentour.Contains(s) || p.loaidulich.tenloaidl.Contains(s)).ToList();
            return res;
        }
    }
}
