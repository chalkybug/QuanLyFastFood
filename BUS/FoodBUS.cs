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
    public class FoodBUS
    {
        private FoodBUS() { }
        private static FoodBUS instance;

        public static FoodBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodBUS();
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

            list = FoodDAO.Instance.GetListFood();
            return list;

        }
        public DataTable ShowTable()
        {
            DataTable data = FoodDAO.Instance.ShowTable();

            return data;
        }
        public int Add(string name, int idCategory, float price, string image)
        {
            return FoodDAO.Instance.Add(name, idCategory, price, image);
        }
        public int Edit(string id, string name, int idCategory, float price, string image)
        {
            return FoodDAO.Instance.Edit(id, name, idCategory, price, image);
        }

        public int Delete(int id)
        {
            return FoodDAO.Instance.Delete(id);
        }

        public DataTable Search(string name)
        {
            return FoodDAO.Instance.Search(name);
        }

    }
}
