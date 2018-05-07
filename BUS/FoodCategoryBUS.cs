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
    public class FoodCategoryBUS
    {
        private FoodCategoryBUS() { }
        private static FoodCategoryBUS instance;

        public static FoodCategoryBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodCategoryBUS();
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

            list = FoodCategoryDAO.Instance.GetListFoodCategory();
            return list;

        }
        public DataTable ShowTable()
        {
            DataTable data = FoodCategoryDAO.Instance.ShowTable();

            return data;
        }

        public int Add(string name)
        {
            return FoodCategoryDAO.Instance.Add(name);
        }
        public int Edit(int id, string name)
        {
            return FoodCategoryDAO.Instance.Edit(id, name);
        }
        public int Delete(int id)
        {
            return FoodCategoryDAO.Instance.Delete(id);
        }

    }
}
