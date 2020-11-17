using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.BUS
{
    class ChiPhiBUS
    {
        private int idtour;
        PMPhanLopEntities db = new PMPhanLopEntities();

        public ChiPhiBUS(int idtour)
        {
            this.idtour = idtour;
        }

        public IEnumerable load_chiphi()
        {
            return new DAO.ChiPhiDAO(idtour).load_chiphi();
        }

        public IEnumerable load_ds_loaicp()
        {
            return new DAO.ChiPhiDAO(idtour).load_ds_loaicp();
        }

        public bool cleaned_data(int tongtien)
        {
            if (tongtien >= 10000)
                return true;
            return false;
        }

        public int add_chiphi(string tenloaicp, int tongtien, string ghichu)
        {
            if (!cleaned_data(tongtien))
                return 0;

            int idloaicp = new DAO.ChiPhiDAO(idtour).getID_via_name(tenloaicp);
            return new DAO.ChiPhiDAO(idtour).add_chiphi(idloaicp, tongtien, ghichu);
        }

        public int edit_chiphi(int idchiphi, string tenloaicp, int tongtien, string ghichu)
        {
            if (!cleaned_data(tongtien))
                return 0;

            int idloaicp = new DAO.ChiPhiDAO(idtour).getID_via_name(tenloaicp);
            return new DAO.ChiPhiDAO(idtour).edit_chiphi(idchiphi, idloaicp, tongtien, ghichu);
        }

        public void delete_chiphi(int idchiphi)
        {
            new DAO.ChiPhiDAO(idtour).delete_chiphi(idchiphi);
        }
    }
}
