using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoginBUS
    {
        private LoginBUS() { }
        private static LoginBUS instance;

        public static LoginBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginBUS();
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
            return LoginDAO.Instance.Login(userName, passWord);
        }
        public bool CheckAdmin(string userName, string passWord)
        {
            return LoginDAO.Instance.checkAdmin(userName, passWord);
        }
        public bool CheckEmplpyee(string userName, string passWord)
        {
            return LoginDAO.Instance.checkEmployee(userName, passWord);
        }
    }
}
