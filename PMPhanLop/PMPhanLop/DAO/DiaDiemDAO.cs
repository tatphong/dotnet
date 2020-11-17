using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    class DiaDiemDAO
    {
        private int idtour;
        PMPhanLopEntities db = new PMPhanLopEntities();

        public DiaDiemDAO(int idtour)
        {
            this.idtour = idtour;
        }

        public IEnumerable load_diadiem()
        {
            var res = from c in db.tour_diadiem
                      where c.idtour == this.idtour
                      select new
                      {
                          IDDiaDiem = c.iddiadiem,
                          TenDiaDiem = c.diadiem.tendiadiem
                      };
            return res.ToList();
        }

        public int getID_via_name(string tendiadiem)
        {
            var res = db.diadiems.Where(p => p.tendiadiem == tendiadiem).Select(p=>p.iddiadiem);
            return res.ToList().Count == 0 ? -1 : res.ToArray()[0];
        }

        internal IEnumerable load_ds_tendiadiem()
        {
            var res = db.diadiems.Select(p => p.tendiadiem).ToList();
            return res;
        }

        public int add_diadiem(int iddiadiem)
        {
            //kiểm tra tour này có tồn tại địa điểm này chưa
            tour_diadiem td = db.tour_diadiem.Where(p => p.idtour == idtour && p.iddiadiem == iddiadiem).SingleOrDefault();
            if (td != null)
                return -1;

            db.tour_diadiem.Add(new tour_diadiem() { idtour = idtour, iddiadiem = iddiadiem });
            db.SaveChanges();
            return 1;
        }

        internal int add_diadiem(string tendiadiem)
        {
            diadiem dd = new diadiem() {tendiadiem = tendiadiem };
            db.diadiems.Add(dd);
            db.SaveChanges();
            return add_diadiem(dd.iddiadiem);
        }

        public void delete_diadiem(int iddiadiem)
        {
            tour_diadiem td = db.tour_diadiem.Where(p => p.idtour == idtour && p.iddiadiem == iddiadiem).SingleOrDefault();
            db.tour_diadiem.Remove(td);
            db.SaveChanges();
        }
    }
}
