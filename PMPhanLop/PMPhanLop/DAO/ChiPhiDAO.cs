using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    class ChiPhiDAO
    {
        private int idtour;
        PMPhanLopEntities db = new PMPhanLopEntities();

        public ChiPhiDAO(int idtour)
        {
            this.idtour = idtour;
        }

        public IEnumerable load_chiphi()
        {
            var res = from c in db.chiphis
                      where c.idtour == idtour
                      select new
                      {
                          MaChiPhi = c.idchiphi,
                          LoaiChiPhi = c.loaichiphi.tenloaicp,
                          TongTien = c.tongtien,
                          GhiChu = c.ghichu
                      };
            return res.ToList();
        }

        public IEnumerable load_ds_loaicp()
        {
            var res = db.loaichiphis.Select(p => p.tenloaicp).ToList();
            return res;
        }

        public int getID_via_name(string tenloaicp)
        {
            var res = db.loaichiphis.Where(p => p.tenloaicp == tenloaicp).Select(p => p.idloaicp);
            return res.ToArray()[0];
        }

        public int add_chiphi(int idloaichiphi, int tongtien, string ghichu)
        {
            chiphi cp = new chiphi() { idloaicp = idloaichiphi, idtour = idtour, tongtien = tongtien, ghichu = ghichu };
            db.chiphis.Add(cp);
            db.SaveChanges();
            return 1;
        }

        public int edit_chiphi(int idchiphi, int idloaicp, int tongtien, string ghichu)
        {
            chiphi cp = db.chiphis.Find(idchiphi);
            cp.idloaicp = idloaicp;
            cp.tongtien = tongtien;
            cp.ghichu = ghichu;
            db.SaveChanges();
            return 1;
        }

        public void delete_chiphi(int idchiphi)
        {
            chiphi cp = db.chiphis.Find(idchiphi);
            db.chiphis.Remove(cp);
            db.SaveChanges();
        }
    }
}
