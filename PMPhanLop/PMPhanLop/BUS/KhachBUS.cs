using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.BUS
{
    class KhachBUS
    {
        public IEnumerable load_data()
        {
            return new DAO.KhachDAO().load_data();
        }

        public IEnumerable load_khach_for_addctdoan(int iddoan)
        {
            return new DAO.KhachDAO().load_khach_for_addctdoan(iddoan);
        }

        public bool cleaned_data(String hoten, String cmnd, String sodt, String diachi)
        {
            if (hoten == "" || cmnd == "" || sodt == "" || diachi == "")
                return false;
            return true;
        }

        public int getID_via_name(String hoten)
        {
            return new DAO.KhachDAO().getID_via_name(hoten);
        }

        public int add_khach(String hoten, String cmnd, bool gioitinh, String sodt, String diachi)
        {
            if (!cleaned_data(hoten, cmnd, sodt, diachi))
                return 0;
            return new DAO.KhachDAO().add_khach(hoten, cmnd, gioitinh, sodt, diachi);
        }

        public int edit_khach(int idkhach, string hoten, string cmnd, bool gioitinh, string sodt, string diachi)
        {
            if (!cleaned_data(hoten, cmnd, sodt, diachi))
                return 0;
            return new DAO.KhachDAO().edit_khach(idkhach, hoten, cmnd, gioitinh, sodt, diachi);
        }

        public void delete_khach(int idkhach)
        {
            new DAO.KhachDAO().delete_khach(idkhach);
        }

        public IEnumerable search(String s)
        {
            return new DAO.KhachDAO().search(s);
        }

       
    }
}
