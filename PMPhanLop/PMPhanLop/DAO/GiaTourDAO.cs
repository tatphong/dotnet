using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    class GiaTourDAO
    {
        private int idtour;
        PMPhanLopEntities db = new PMPhanLopEntities();

        public GiaTourDAO(int idtour)
        {
            this.idtour = idtour;
        }

        public IEnumerable load_gia()
        {
            var res = from c in db.gias where c.idtour == this.idtour
                      select new
                      {
                          idgia = c.idgia,
                          GiaTour = c.giatour,
                          NgayBatDau = c.ngaybatdau,
                          NgayKetThuc = c.ngayketthuc
                      };
            return res.ToList();
        }

        public int add_gia(int giatour, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            db.gias.Add(new gia() { idtour = idtour, giatour = giatour, ngaybatdau = ngaybatdau, ngayketthuc = ngayketthuc });
            db.SaveChanges();
            return 1;
        }

        public int edit_gia(int giatour, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            gia g = db.gias.Find(idtour);
            g.giatour = giatour;
            g.ngaybatdau = ngaybatdau;
            g.ngayketthuc = ngayketthuc;
            db.SaveChanges();
            return 1;
        }

        public void delete_gia(int idgia)
        {
            gia g = db.gias.Where(p => p.idgia == idgia).SingleOrDefault();
            db.gias.Remove(g);
            db.SaveChanges();
        }

        public IEnumerable search(DateTime ngaybatdau, DateTime ngayketthuc)
        {
            var res = db.gias.Where(p => p.idtour == this.idtour && p.ngaybatdau <= ngaybatdau && p.ngayketthuc >= ngayketthuc).ToList();
            return res;
        }
    }
}
