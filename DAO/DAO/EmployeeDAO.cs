using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EmployeeDAO
    {
        private EmployeeDAO() { }
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeDAO();
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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Employee");
            foreach (DataRow item in data.Rows)
            {
                Employee emp = new Employee(item);
                list.Add(emp);
            }

            return list;
        }
        public DataTable ShowTable()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Employee");

            return data;
        }

        public int Add(string name, string phone, string address,int sex)
        {
            string query = $"INSERT dbo.Employee VALUES  ( N'{name}', '{phone}',N'{address}', {sex})";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Edit(string id,string name, string phone, string address, int sex)
        {
            string query = $"UPDATE dbo.Employee	SET	name= N'{name}', phone='{phone}', address=N'{address}',sex={sex} WHERE id={id}";

            DataProvider.Instance.ExecuteNonQuery(query);
            
            return 1;
        }
        public int Delete(string id)
        {
            string query = $"EXEC dbo.proc_Del_Employee @id = {id}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
