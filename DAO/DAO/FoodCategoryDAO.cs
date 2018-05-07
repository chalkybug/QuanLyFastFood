using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FoodCategoryDAO
    {
        private FoodCategoryDAO() { }
        private static FoodCategoryDAO instance;

        public static FoodCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodCategoryDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public List<FoodCategory> GetListFoodCategory()
        {
            List<FoodCategory> list = new List<FoodCategory>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.FoodCategory");
            foreach (DataRow item in data.Rows)
            {
                FoodCategory foodCategory = new FoodCategory(item);
                list.Add(foodCategory);
            }


            return list;
        }
        public DataTable ShowTable()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.FoodCategory");

            return data;
        }

        public int Add(string name)
        {
            string query = $"INSERT dbo.FoodCategory VALUES  ( N'{name}')";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

        public int Edit(int id,string name)
        {
            string query = $"UPDATE dbo.FoodCategory SET name=N'{name}' WHERE id={id}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Delete(int id)
        {
            string query = $"EXEC dbo.proc_del_FoodCategory @id = {id}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
