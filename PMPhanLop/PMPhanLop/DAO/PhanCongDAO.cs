using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPhanLop.DAO
{
    class PhanCongDAO
    {
        private int iddoan;
        PMPhanLopEntities db = new PMPhanLopEntities();

        public PhanCongDAO(int iddoan)
        {
            this.iddoan = iddoan;
        }

        public IEnumerable load_data()
        {
            var res = from c in db.phancongs
                      where c.iddoan == this.iddoan
                      select new
                      {
                          MaPhanCong = c.idphancong,
                          HoTenNhanVien = c.nhanvien.hotennv,
                          ChucVu = c.chucvu,
                          GhiChu = c.ghichu
                      };
            return res.ToList();
        }

        public bool is_working(int idnhanvien)
        {
            //lấy danh sách các đoàn mà nhân viên có mặt nhưng 0 phải đoàn hiện tại
            var ds_doan = from pc in db.phancongs.Where(p => p.iddoan != iddoan && p.idnhanvien == idnhanvien)
                      join dn in db.doans on pc.iddoan equals dn.iddoan
                      into temp_doan
                      from c in temp_doan
                      select new
                      {
                          c.iddoan,
                          c.ngaykhoihanh,
                          c.ngayketthuc
                      };

            var ngay_di_ve = db.doans.Where(p => p.iddoan == iddoan).SingleOrDefault();

            var res = from d in ds_doan where !((d.ngayketthuc < ngay_di_ve.ngaykhoihanh && d.ngayketthuc < ngay_di_ve.ngayketthuc)
                      || (ngay_di_ve.ngaykhoihanh < d.ngaykhoihanh && ngay_di_ve.ngayketthuc < d.ngaykhoihanh))
                      select iddoan;

            if (res == null)
                return false;
            return true;
        }

        public int add_phancong(int idnhanvien, string chucvu, string ghichu)
        {
            db.phancongs.Add(new phancong() { iddoan = iddoan, idnhanvien = idnhanvien , chucvu = chucvu, ghichu = ghichu});
            db.SaveChanges();
            return 1;
        }

        public int edit_phancong(int idnhanvien, string chucvu, string ghichu)
        {
            phancong pc = db.phancongs.Where(p => p.iddoan == iddoan && p.idnhanvien == idnhanvien).SingleOrDefault();
            pc.chucvu = chucvu;
            pc.ghichu = ghichu;
            db.SaveChanges();
            return 1;
        }

        public void delete_phancong(int idphancong)
        {
            phancong d = db.phancongs.Find(idphancong);
            db.phancongs.Remove(d);
            db.SaveChanges();
        }
    }
}
