using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BillBUS
    {
        private BillBUS() { }
        private static BillBUS instance;

        public static BillBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillBUS();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public int Add(string idCoupon, int cashier, DateTime paymentTime)
        {

            return BillDAO.Instance.Add(idCoupon, cashier, paymentTime);

        }

        public int GetMaxBill()
        {

            return BillDAO.Instance.GetMaxBill();
        }

        public DataTable ShowBillPaid(string start, string end)
        {

            DataTable dt = BillDAO.Instance.ShowBillPaid(start, end);

            foreach (DataRow item in dt.Rows)
            {
                string idCoupon = item["idCoupon"].ToString();
                int coupon = int.Parse( CouponDAO.Instance.GetValueByID(idCoupon));
                int valueTongTien =int.Parse( item["TongTien"].ToString());
                item["TongTien"] = valueTongTien - (valueTongTien * coupon / 100);


            }


            return dt;
        }



    }
}
