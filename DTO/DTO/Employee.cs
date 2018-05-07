using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public bool sex { get; set; }

        public Employee(int id, string name, string phone, string address, bool sex)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.address = address;
            this.sex = sex;
        }

        public Employee(DataRow row)
        {

            this.id = (int)row["id"];
            this.name = row["name"].ToString();
            this.phone = row["phone"].ToString();
            this.address = row["address"].ToString();
            this.sex = (bool)row["sex"];

        }


    }
}
