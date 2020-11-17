using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.BUS
{
    class NhanVienBUS
    {

        public IEnumerable load_data()
        {
            return new DAO.NhanVienDAO().load_nhanvien();
        }

        public bool cleaned_data(String hoten, String cmnd)
        {
            if (hoten == "" || cmnd == "" )
                return false;
            return true;
        }

        public IEnumerable load_ds_hoten()
        {
            return new DAO.NhanVienDAO().load_ds_hoten();
        }

        public int add_nhanvien(String hoten, String cmnd)
        {
            if (!cleaned_data(hoten, cmnd))
                return 0;

            if (new DAO.NhanVienDAO().kt_tontai_nhanvien(null, cmnd))
                return -1;

            DAO.NhanVienDAO a = new DAO.NhanVienDAO();
            return a.add_nhanvien(hoten, cmnd);
        }

        public int getID_via_name(string hoten)
        {
            return new DAO.NhanVienDAO().getID_via_name(hoten);
        }

        public int edit_nhanvien(int idnhanvien, String hoten, String cmnd)
        {
            if (!cleaned_data(hoten, cmnd))
                return 0;

            if (new DAO.NhanVienDAO().kt_tontai_nhanvien(idnhanvien, cmnd))
                return -1;

            return new DAO.NhanVienDAO().edit_nhanvien(idnhanvien, hoten, cmnd);
        }
        public void delete_nhanvien(int idnhanvien)
        {
            new DAO.NhanVienDAO().delete_nhanvien(idnhanvien);
        }

        public IEnumerable search(String s)
        {
            return new DAO.NhanVienDAO().search(s);
        }
    }
}
