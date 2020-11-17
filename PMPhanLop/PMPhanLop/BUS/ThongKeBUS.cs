using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.BUS
{
    class ThongKeBUS
    {
        public IEnumerable TongLuotTourNV()
        {
            return new DAO.ThongKeDAO().TongLuotTourNV();
        }

        public IEnumerable doanhso_tour()
        {
            return new DAO.ThongKeDAO().doanhso_tour();
        }

        public IEnumerable doanhso_doan()
        {
            return new DAO.ThongKeDAO().doanhso_doan();
        }

        public IEnumerable chiphitour()
        {
            return new DAO.ThongKeDAO().chiphitour();
        }
    }
}
