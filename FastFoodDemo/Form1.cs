using BUS;
using FastFoodDemo.Forrms;
using FastFoodDemo.UCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class Form1 : Form
    {
        public bool isAdmin = true;
        public bool isEmployee = true;
        public string username = null;
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;

            FirstCustomControl uc = new FirstCustomControl();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            FirstCustomControl uc = new FirstCustomControl();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            CheckEmployee();
            if (isEmployee)
            {
                MySecondCustmControl uc = new MySecondCustmControl();
                uc.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(uc);
            }




        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            CheckAdmin();
            if (isAdmin)
            {
                Dashboard uc = new Dashboard();
                uc.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(uc);

            }



        }
        private void CheckAdmin()
        {
            if (!isAdmin)
            {
                frmLogin f = new frmLogin();

                f.ShowDialog();
                if (frmLogin.isSuccess)
                {
                    if (LoginBUS.Instance.CheckAdmin(frmLogin.name, frmLogin.pass))
                    {
                        isAdmin = true;
                    }
                }
            }

        }
        private void CheckEmployee()
        {
            if (!isEmployee)
            {
                frmLogin f = new frmLogin();

                f.ShowDialog();
                if (frmLogin.isSuccess)
                {
                    if (LoginBUS.Instance.CheckEmplpyee(frmLogin.name, frmLogin.pass))
                    {
                        isEmployee = true;
                    }
                }
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckAdmin();
        }
    }
}
