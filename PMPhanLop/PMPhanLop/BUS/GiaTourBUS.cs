using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.BUS
{
    class GiaTourBUS
    {
        private int idtour;

        public GiaTourBUS(int idtour)
        {
            this.idtour = idtour;
        }

        public IEnumerable load_gia()
        {
            return new DAO.GiaTourDAO(idtour).load_gia();
        }

        public bool cleaned_data(int giatour, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            if (giatour >= 100000 || ngaybatdau <= ngayketthuc)
                return true;
            return false;
        }

        public void delete_gia(int idgia)
        {
            new DAO.GiaTourDAO(idtour).delete_gia(idgia);
        }

        public IEnumerable search(DateTime ngaybatdau, DateTime ngayketthuc)
        {
            return new DAO.GiaTourDAO(idtour).search(ngaybatdau, ngayketthuc);
        }

    }
}
