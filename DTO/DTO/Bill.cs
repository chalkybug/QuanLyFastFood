using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Bill
    {
        public int  id { get; set; }
        public string idCoupon { get; set; }
        public int cashier { get; set; }
        public DateTime? paymentTime { get; set; }
    

        public Bill(string idCoupon, int Cashier, DateTime paymentTime, int idFood, int count)
        {
            this.idCoupon = idCoupon;
            this.cashier = Cashier;
            this.paymentTime = paymentTime;
          
        }
        public Bill(DataRow row)
        {
            this.id = (int)row["id"];
            this.idCoupon = row["idCoupon"].ToString();
            this.cashier = (int)row["cashier"];
            this.paymentTime = (DateTime?)row["paymentTime"];

        }


    }
}
