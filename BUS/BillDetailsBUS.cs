using DAO.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
   public class BillDetailsBUS
    {
        private BillDetailsBUS() { }
        private static BillDetailsBUS instance;

        public static BillDetailsBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDetailsBUS();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public int Add(int idBill, int idFood, int count)
        {

            return BillDetailsDAO.Instance.Add(idBill, idFood, count);
        }
        public int Edit(int id, int idBill, int idFood, int count)
        {
          
            return BillDetailsDAO.Instance.Edit(id,idBill,idFood,count);
        }


        public int Delete(int id)
        {

            return BillDetailsDAO.Instance.Delete(id);
        }




    }
}
