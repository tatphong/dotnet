using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    class KhachDAO
    {
        PMPhanLopEntities db = new PMPhanLopEntities();
        public IEnumerable load_data()
        {
            var res = from c in db.khaches
                      select new
                      {
                          idkhach = c.idkhach,
                          tenkhach = c.hoten,
                          cmnd = c.cmnd,
                          gioitinh = c.gioitinh,
                          sodt = c.sodt,
                          diachi = c.diachi
                      };
            return res.ToList();
        }

        public IEnumerable load_khach_for_addctdoan(int iddoan)
        {
            var ctdoan = from c in db.chitietdoans where c.iddoan == iddoan select c.idkhach;
            var res = from c in db.khaches where !ctdoan.Contains(c.idkhach) select c.hoten;
            return res.ToList();
        }

        public int getID_via_name(String hoten)
        {
            var res = from c in db.khaches where c.hoten == hoten select c.idkhach;
            return res.ToArray()[0];
        }

        public bool kt_tontai_khach(int? idkhach, string cmnd)
        {
            khach k;
            if (idkhach == null)
                k = db.khaches.Where(p => p.cmnd == cmnd).SingleOrDefault();
            else 
                k = db.khaches.Where(p => p.idkhach != idkhach && p.cmnd == cmnd).SingleOrDefault();

            if (k == null) return false;
            return true;
        }

        public int add_khach(String hoten, String cmnd, bool gioitinh, String sodt, String diachi)
        {
            khach a = new khach() { hoten = hoten, cmnd = cmnd, gioitinh = gioitinh, sodt = sodt, diachi = diachi };
            db.khaches.Add(a);
            db.SaveChanges();
            return 1;
        }

        public int edit_khach(int idkhach, string hoten, string cmnd, bool gioitinh, string sodt, string diachi)
        {
            khach k = db.khaches.Find(idkhach);
            k.hoten = hoten;
            k.cmnd = cmnd;
            k.gioitinh = gioitinh;
            k.sodt = sodt;
            k.diachi = diachi;
            db.SaveChanges();
            return 1;
        }

        public int delete_khach(int idkhach)
        {
            List<chitietdoan> list = db.chitietdoans.Where(p => p.idkhach == idkhach).ToList();
            foreach (chitietdoan c in list)
            {
                db.chitietdoans.Remove(c);
            }
            db.SaveChanges();
            khach a = db.khaches.Where(p => p.idkhach == idkhach).SingleOrDefault();
            db.khaches.Remove(a);
            db.SaveChanges();
            return 1;
        }

        public IEnumerable search(String s)
        {
            var res = db.khaches.Where(p =>p.cmnd.Contains(s) || p.hoten.Contains(s) || p.sodt.Contains(s)).ToList();
            return res;
        }
    }
}
