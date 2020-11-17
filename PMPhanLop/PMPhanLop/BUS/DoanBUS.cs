using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMPhanLop.BUS
{
    class DoanBUS
    {
        public IEnumerable load_data()
        {
            return new DAO.DoanDAO().load_doan();
        }

        public bool cleaned_data(String tentour, String tendoan, DateTime ngaykhoihanh)
        {
            if (tentour == null || tendoan == null)
                return false;
            return true;
        }

        public int add_doan(String tentour, String tendoan, DateTime ngaykhoihanh)
        {
            if (!cleaned_data(tentour, tendoan, ngaykhoihanh))
                return 0;

            DAO.DoanDAO a = new DAO.DoanDAO();
            return a.add_doan(new DAO.TourDAO().getID_via_name(tentour), tendoan, ngaykhoihanh);
        }

        public int edit_doan(int iddoan, String tentour, String tendoan, DateTime ngaykhoihanh)
        {
            if (!cleaned_data(tentour, tendoan, ngaykhoihanh))
                return 0;
            return new DAO.DoanDAO().edit_doan(iddoan, tentour, tendoan, ngaykhoihanh);
        }
        public void delete_doan(int iddoan)
        {
            new DAO.DoanDAO().delete_doan(iddoan);
        }

        public IEnumerable search(String s)
        {
            return new DAO.DoanDAO().search(s);
        }
    }
}
