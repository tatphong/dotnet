using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.BUS
{
    class PhanCongBUS
    {
        private int iddoan;

        public PhanCongBUS(int iddoan)
        {
            this.iddoan = iddoan;
        }

        public IEnumerable load_data()
        {
            return new DAO.PhanCongDAO(iddoan).load_data();
        }

        public bool cleaned_data(string chucvu)
        {
            if (chucvu == "")
                return false;
            return true;
        }

        public int add_phancong(int idnhanvien, string chucvu, string ghichu)
        {
            if (!cleaned_data(chucvu))
                return 0;
            if (new DAO.PhanCongDAO(iddoan).is_working(idnhanvien))
                return -1;
            return new DAO.PhanCongDAO(iddoan).add_phancong(idnhanvien, chucvu, ghichu);
        }

        public int edit_phancong(int idnhanvien, string chucvu, string ghichu)
        {
            if (!cleaned_data(chucvu))
                return 0;
            if (new DAO.PhanCongDAO(iddoan).is_working(idnhanvien))
                return -1;

            return new DAO.PhanCongDAO(iddoan).edit_phancong(idnhanvien, chucvu, ghichu);
        }

        public void delete_phancong(int idphancong)
        {
            new DAO.PhanCongDAO(iddoan).delete_phancong(idphancong);
        }
    }
}
