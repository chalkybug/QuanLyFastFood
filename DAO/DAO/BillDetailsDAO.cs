using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
   public class BillDetailsDAO
    {
        private BillDetailsDAO() { }
        private static BillDetailsDAO instance;

        public static BillDetailsDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDetailsDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public DataTable ShowTable()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillDetails");

            return data;
        }
        public int Add(int idBill, int idFood, int count)
        {
            string query = $"INSERT dbo.BillDetails( idBill, idFood, count ) VALUES  ( {idBill}, {idFood}, {count}  )";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Edit(int id,int idBill, int idFood, int count)
        {
            string query = $"UPDATE dbo.BillDetails SET	idBill={idBill},idFood={idFood},count={count} WHERE id={id}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }


        public int Delete(int id)
        {
            string query = $"DELETE dbo.BillDetails WHERE id={id}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }



    }
}
