using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    class NhanVienDAO
    {
        PMPhanLopEntities db = new PMPhanLopEntities();
        public IEnumerable load_nhanvien()
        {
            //var res = db.doans.ToList();
            var res = from c in db.nhanviens
                      where c.blocked == false
                      select new
                      {
                          MaNhanVien = c.idnhanvien,
                          HoTen = c.hotennv,
                          CMND = c.cmnd
                      };
            return res.ToList();
        }

        public IEnumerable load_ds_hoten()
        {
            var res = from c in db.nhanviens
                      where c.blocked == false
                      select c.hotennv;
            return res.ToList();
        }

        public bool kt_tontai_nhanvien(int? idnhanvien, string cmnd)
        {
            nhanvien nv;
            if (idnhanvien == null) 
                nv = db.nhanviens.Where(p => p.cmnd == cmnd).SingleOrDefault();
            else
                nv = db.nhanviens.Where(p => p.idnhanvien != idnhanvien && p.cmnd == cmnd).SingleOrDefault();

            if (nv == null)
                return false;
            return true;
        }

        public int getID_via_name(string hoten)
        {
            var res = from c in db.nhanviens where c.hotennv == hoten select c.idnhanvien;
            return res.ToArray()[0];
        }

        public int add_nhanvien(String hoten, String cmnd)
        {
            nhanvien a = new nhanvien()
            {
                hotennv = hoten,
                cmnd = cmnd
            };
            db.nhanviens.Add(a);
            db.SaveChanges();
            return a.idnhanvien;
        }

        public int edit_nhanvien(int idnhanvien, String hoten, string cmnd)
        {
            nhanvien nv = db.nhanviens.Find(idnhanvien);
            nv.hotennv = hoten;
            nv.cmnd = cmnd;
            db.SaveChanges();
            return 1;
        }
        public void delete_nhanvien(int idnhanvien)
        {
            List<phancong> rel = db.phancongs.Where(p => p.idnhanvien == idnhanvien).ToList();
            foreach (phancong i in rel)
            {
                db.phancongs.Remove(i);
            }
            db.SaveChanges();

            nhanvien nv = db.nhanviens.Find(idnhanvien);
            nv.blocked = true;
            db.SaveChanges();
        }

        public IEnumerable search(String s)
        {
            var res = db.nhanviens.Where(p => p.hotennv.Contains(s) || p.cmnd.Contains(s)).ToList();
            return res;
        }
    }
}
