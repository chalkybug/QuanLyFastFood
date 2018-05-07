using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FoodCategory
    {
        public int id { get; set; }

        public string name { get; set; }

        public FoodCategory()
        {
            this.id = id;
            this.name = name;
        }

        public FoodCategory(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
        }

    }
}
