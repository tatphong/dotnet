using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PMPhanLop.BUS
{
    class ChitietDoanBUS
    {
        private int v;

        public ChitietDoanBUS(int v)
        {
            this.v = v;
        }

        public IEnumerable load_data()
        {
            return new DAO.ChitietDoanDAO(this.v).load_data();
        }

        public void add_ctdoan(int idkhach)
        {
            new DAO.ChitietDoanDAO(v).add_chitietdoan(idkhach);
        }

        public void delete_ctdoan(int idkhach)
        {
            new DAO.ChitietDoanDAO(v).delete_ctdoan(idkhach);
        }
    }
}
