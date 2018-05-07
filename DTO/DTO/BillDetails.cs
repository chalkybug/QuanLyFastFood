using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    class BillDetails
    {
        public int id { get; set; }
        public int idBill { get; set; }
        public int idFood { get; set; }
        public int count { get; set; }

        public BillDetails(int id, int idBill, int idFood, int count)
        {
            this.id = id;
            this.idBill = idBill;
            this.idFood = idFood;
            this.count = count;
        }

        public BillDetails(DataRow row)
        {
            
            this.id = (int)row["id"];
            this.idBill = (int)row["idBill"];
            this.idFood = (int)row["idFood"];
            this.count = (int)row["count"];

        }


    }
}
