using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.BUS
{
    class DiaDiemBUS
    {
        private int idtour;

        public DiaDiemBUS(int idtour)
        {
            this.idtour = idtour;
        }

        public IEnumerable load_diadiem()
        {
            return new DAO.DiaDiemDAO(idtour).load_diadiem();
        }

        public int add_diadiem(string tendiadiem)
        {
            int iddiadiem = new DAO.DiaDiemDAO(idtour).getID_via_name(tendiadiem);
            if (iddiadiem != -1)
                return new DAO.DiaDiemDAO(idtour).add_diadiem(iddiadiem);
            else
                return new DAO.DiaDiemDAO(idtour).add_diadiem(tendiadiem);
        }

        internal IEnumerable load_ds_tendiadiem()
        {
            return new DAO.DiaDiemDAO(idtour).load_ds_tendiadiem();
        }

        public void delete_diadiem(int iddiadiem)
        {
            new DAO.DiaDiemDAO(idtour).delete_diadiem(iddiadiem);
        }
    }
}
