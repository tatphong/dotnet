using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    class ChitietDoanDAO
    {
        private int v;
        PMPhanLopEntities db = new PMPhanLopEntities();

        public ChitietDoanDAO(int v)
        {
            this.v = v;
        }

        public IEnumerable load_data()
        {
            var res = from c in db.chitietdoans where c.iddoan == this.v select new {
                idkhach = c.idkhach,
                tenkhach = c.khach.hoten,
                CMND = c.khach.cmnd,
                gioitinh = c.khach.gioitinh,
                sodt = c.khach.sodt
            };
            return res.ToList();
        }

        public int add_chitietdoan(int idkhach)
        {
            db.chitietdoans.Add(new chitietdoan() { iddoan = v, idkhach = idkhach });
            db.SaveChanges();
            return 1;
        }

        public void delete_ctdoan(int idkhach)
        {
            chitietdoan d = db.chitietdoans.Where(p => p.iddoan == v && p.idkhach == idkhach).SingleOrDefault();
            //chitietdoan khach = (from c in db.chitietdoans where c.iddoan == v && c.idkhach == idkhach select c).SingleOrDefault();
            db.chitietdoans.Remove(d);
            db.SaveChanges();
        }

        public static implicit operator int(ChitietDoanDAO v)
        {
            throw new NotImplementedException();
        }
    }
}
