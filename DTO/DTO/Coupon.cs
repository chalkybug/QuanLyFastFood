using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Coupon
    {
        public string id { get; set; }
        public string des { get; set; }
        public string value { get; set; }
        public Coupon(string id, string des, string value)
        {
            this.id = id;
            this.des = des;
            this.value = value;

        }
        public Coupon(DataRow row)
        {
            this.id = row["id"].ToString();
            this.des = row["description"].ToString();
            this.value = row["valueCoupon"].ToString();

        }


    }
}
