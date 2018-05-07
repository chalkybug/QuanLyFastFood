using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace FastFoodDemo.UCs
{
    public partial class Statistical : UserControl
    {
        public Statistical()
        {
            InitializeComponent();
          
        }


        private void LoadData()
        {
            string start = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string end = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            dataGridViewX1.DataSource = BillDAO.Instance.ShowBillPaid(start,end);
            dataGridViewX2.DataSource = EmployeeDAO.Instance.BestEmployee(start, end);
            dataGridViewX3.DataSource = FoodDAO.Instance.PopularFood(start, end);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
