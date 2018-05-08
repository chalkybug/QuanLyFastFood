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
using BUS;

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
            dataGridViewX1.DataSource = BillBUS.Instance.ShowBillPaid(start,end);
            dataGridViewX2.DataSource = EmployeeDAO.Instance.BestEmployee(start, end);
            dataGridViewX3.DataSource = FoodDAO.Instance.PopularFood(start, end);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbDate_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string start = "";
            string end = "";
            if (cmbDate.SelectedIndex==0)
            {
                 start = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");
                 end = DateTime.Today.ToString("yyyy-MM-dd");
                dataGridViewX1.DataSource = BillBUS.Instance.ShowBillPaid(start, end);
                dataGridViewX2.DataSource = EmployeeDAO.Instance.BestEmployee(start, end);
                dataGridViewX3.DataSource = FoodDAO.Instance.PopularFood(start, end);
            }
            if (cmbDate.SelectedIndex == 1)// tháng này
            {
                start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
                end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("yyyy-MM-dd");
            }
            if (cmbDate.SelectedIndex == 2) // tháng trước
            {
                start = new DateTime(DateTime.Now.Year, DateTime.Now.Month -1, 1).ToString("yyyy-MM-dd");
                end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
            }
            dataGridViewX1.DataSource = BillBUS.Instance.ShowBillPaid(start, end);
            dataGridViewX2.DataSource = EmployeeDAO.Instance.BestEmployee(start, end);
            dataGridViewX3.DataSource = FoodDAO.Instance.PopularFood(start, end);

        }
    }
}
