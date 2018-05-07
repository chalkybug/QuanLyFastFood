using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CouponBUS
    {
        private CouponBUS() { }
        private static CouponBUS instance;

        public static CouponBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CouponBUS();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public List<Coupon> GetListCoupon()
        {
            List<Coupon> list = new List<Coupon>();
            list = CouponDAO.Instance.GetListCoupon();

            return list;
        }
        public DataTable ShowTable()
        {
            DataTable data = CouponDAO.Instance.ShowTable();

            return data;
        }

        public int Add(string id, string des, string value)
        {
            return CouponDAO.Instance.Add(id, des, value);
        }
        public int Edit(string id, string des, string value)
        {
            return CouponDAO.Instance.Edit(id, des, value);
        }
        public int Delete(string id)
        {
            return CouponDAO.Instance.Delete(id);
        }
        public bool Check(string id)
        {
            List<Coupon> list = new List<Coupon>();
            list = CouponDAO.Instance.GetListCoupon();
            foreach (var item in list)
            {
                if (item.id.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        public string GetValueByID(string id)
        {
            List<Coupon> list = new List<Coupon>();
            list = CouponDAO.Instance.GetListCoupon();
            foreach (var item in list)
            {
                if (item.id.Equals(id))
                {
                    return item.value;
                }
            }
            return "";
        }
    }
}
