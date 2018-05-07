using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodDemo.Forrms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public static bool isSuccess= false;
        public static string name;
        public static string pass;

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxX1.Text;
            string password = textBoxX2.Text;
            if (LoginBUS.Instance.Login(username,password))
            {
                isSuccess = true;
                this.Close();
                name = username;
                pass = password;

            }
            else
            {
                isSuccess = false;
                lblError.Text = "Login False ! Please try again ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
