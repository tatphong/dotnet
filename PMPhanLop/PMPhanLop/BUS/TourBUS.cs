using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMPhanLop.BUS
{
    public class TourBUS
    {
        public IEnumerable load_data()
        {
            return new DAO.TourDAO().load_tour();
        }

        public Array load_danh_sach_loai_tour()
        {
            return new DAO.TourDAO().load_danh_sach_loai_tour();
        }

        public Array load_danh_sach_ten_tour()
        {
            return new DAO.TourDAO().load_danh_sach_ten_tour();
        }

        public bool cleaned_data(String tenloaidl, String tentour, int thoigiantour, int gia)
        {
            if (thoigiantour < 1 || gia < 100000 || tenloaidl == null || tentour == null)
                return false;
            return true;
        }

        public int add_tour(String tenloaidl, String tentour, int thoigiantour, int gia)
        {
            if (!cleaned_data(tenloaidl, tentour, thoigiantour, gia))
                return 0;
            return new DAO.TourDAO().add_tour(tenloaidl, tentour, thoigiantour);
        }

        public int edit_tour(int idtour, String tenloaidl, String tentour, int thoigiantour)
        {
            if (!cleaned_data(tenloaidl, tentour, thoigiantour, 1000000))
                return 0;
            DAO.TourDAO a = new DAO.TourDAO();
            int idloaidl = a.getIDLoaiDL_via_name(tenloaidl);
            return a.edit_tour(idtour, idloaidl, tentour, thoigiantour);
        }

        public void delete_tour(int iddoan)
        {
            new DAO.TourDAO().delete_tour(iddoan);
        }

        public IEnumerable search(String s)
        {
            return new DAO.TourDAO().search(s);
        }
    }
}
