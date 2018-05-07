
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FoodDAO
    {
        private FoodDAO() { }
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Food");
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }


            return list;
        }


        public DataTable ShowTable()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Food");

            return data;
        }

        public int Add(string name,int idCategory,float price, string image )
        {
            string query = $"INSERT dbo.Food VALUES  ( N'{name}', {idCategory}, {price},'{image}')";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Edit(string id, string name, int idCategory, float price, string image)
        {
            string query = $"UPDATE dbo.Food SET name=N'{name}',idCategory={idCategory},price={price},image='{image}'  WHERE id ={id}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Delete(int id)
        {
            string query = $"DELETE dbo.Food WHERE id ={id}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }


        public DataTable Search(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"SELECT * FROM dbo.Food WHERE name LIKE '%{name}%'");

            return data;
        }

        public DataTable PopularFood(string start, string end)
        {
            string query = $"EXEC dbo.PopularFood @start = '{start}', @end = '{end}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
    }
}
