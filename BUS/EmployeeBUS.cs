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
    public class EmployeeBUS
    {
        private EmployeeBUS() { }
        private static EmployeeBUS instance;

        public static EmployeeBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeBUS();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public List<Employee> GetListEmployee()
        {
            List<Employee> list = new List<Employee>();
            list = EmployeeDAO.Instance.GetListEmployee();

            return list;
        }

        public DataTable ShowTable()
        {
            DataTable data = EmployeeDAO.Instance.ShowTable();

            return data;
        }
        public int Add(string name, string phone, string address, int sex)
        {

            return EmployeeDAO.Instance.Add(name, phone, address, sex);
        }
        public int Edit(string id, string name, string phone, string address, int sex)
        {
            return EmployeeDAO.Instance.Edit(id, name, phone, address, sex);
        }
        public int Delete(string id)
        {
            return EmployeeDAO.Instance.Delete(id);
        }


    }
}
