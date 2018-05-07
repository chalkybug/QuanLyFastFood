using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Food
    {
        public int id { get; set; }
        public string name { get; set; }
        public int idCategory { get; set; }
        public float price { get; set; }
        public string image { get; set; }

        public Food(int id, string name, int idCategory, float price,string image)
        {
            this.id = id;
            this.name = name;
            this.idCategory = idCategory;
            this.price = price;
            this.image = image;

        }

        public Food(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
            this.idCategory = (int)row["idCategory"];
            this.price = (float)row["count"];
            this.image = row["image"].ToString();

        }



    }
}
