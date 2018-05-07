using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class LoginDAO
    {
        private LoginDAO() { }
        private static LoginDAO instance;

        public static LoginDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public bool Login(string userName, string passWord)
        {
            //test sqp in
            string query = string.Format("EXEC dbo.CheckLogin @name , @passs");
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return data.Rows.Count > 0;
        }
        public bool checkAdmin(string userName, string passWord)
        {
            string query = $"SELECT * FROM dbo.Login WHERE Name='{userName}' AND Pass='{passWord}' AND authority='admin' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }
        public bool checkEmployee(string userName, string passWord)
        {
            string query = $"SELECT * FROM dbo.Login WHERE Name='{userName}' AND Pass='{passWord}' AND authority='emp' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }
    }
}
