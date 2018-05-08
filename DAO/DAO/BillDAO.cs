using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
  public  class BillDAO
    {
        private BillDAO() { }
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDAO();
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
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill");

            return data;
        }
        public int Add(string idCoupon, int cashier, DateTime paymentTime)
        {
            string query = $"EXEC dbo.InsertBill @idCoupon = '{idCoupon}',  @idEmp = {cashier}, @paymentTime = '{paymentTime}'";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

        public int GetMaxBill()
        {
            string query = $"SELECT MAX(id) as id FROM dbo.Bill ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int value = 0;
            foreach (DataRow item in data.Rows)
            {
                value = (int)item["id"];
            }

            return value;
        }

        public DataTable ShowBillPaid(string start, string end)
        {
            string query = $"exec ShowBillPaid '{start}' ,'{end}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            
            return dt;
        }



    }
}
