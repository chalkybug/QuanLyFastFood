using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CouponDAO
    {
        private static CouponDAO instance; // khởi tạo một đối tượng
        private CouponDAO() { } // khởi tạo hàm mặc định

        public static CouponDAO Instance // đóng gói dữ liệu vẫn chưa thêm xử lý chồng chéo dữ liệu
        {
            get
            {
                if (instance == null)
                {
                    instance = new CouponDAO();
                }
                return instance;
            }

        }

        public List<Coupon> GetListCoupon()
        {
            List<Coupon> list = new List<Coupon>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Coupon");
            foreach (DataRow item in data.Rows)
            {
                Coupon emp = new Coupon(item);
                list.Add(emp);
            }

            return list;
        }

        public DataTable ShowTable()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Coupon");

            return data;
        }

        public int Add(string id, string des, string value)
        {
            string query = $"INSERT dbo.Coupon VALUES  ( '{id}',  N'{des}', '{value}' )";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Edit(string id, string des, string value)
        {
            string query = $"UPDATE dbo.Coupon	SET	description=N'{des}',valueCoupon='{value}' WHERE id='{id}'";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Delete(string id)
        {
            string query = $"EXEC dbo.proc_Del_Coupon @id = '{id}' ";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

        public string GetValueByID(string id)
        {
            string query = $"SELECT * FROM dbo.Coupon WHERE id='{id}'";
            Coupon coupon = null;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
               
                coupon = new Coupon(item);

            }
         
            return coupon.value;
        }


    }
}
