using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace FastFoodDemo.UCs
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadViews();

        }

        private void LoadViews()
        {
            dataGridViewX1.DataSource = EmployeeBUS.Instance.ShowTable();
            dataGridViewX2.DataSource = FoodCategoryBUS.Instance.ShowTable();
            dataGridViewX3.DataSource = FoodBUS.Instance.ShowTable();
            dataGridViewX4.DataSource = CouponBUS.Instance.ShowTable();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIDEmp.Text = dataGridViewX1.SelectedCells[0].Value.ToString();
                txtNameEmp.Text = dataGridViewX1.SelectedCells[1].Value.ToString();
                txtPhoneEmp.Text = dataGridViewX1.SelectedCells[2].Value.ToString();
                txtAddressEmp.Text = dataGridViewX1.SelectedCells[3].Value.ToString();


                if (dataGridViewX1.SelectedCells[4].Value.ToString() == "True")
                {
                    ckbNamEmp.Checked = true;
                    ckbNuEmp.Checked = false;
                }
                else
                {
                    ckbNamEmp.Checked = false;
                    ckbNuEmp.Checked = true;
                }
            }
            catch
            {


            }


        }

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIDFoodCa.Text = dataGridViewX2.SelectedCells[0].Value.ToString();
                txtNameFoodCa.Text = dataGridViewX2.SelectedCells[1].Value.ToString();

            }
            catch
            {

            }
        }

        private void dataGridViewX3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIdFood.Text = dataGridViewX3.SelectedCells[0].Value.ToString();
                txtNameFood.Text = dataGridViewX3.SelectedCells[1].Value.ToString();
                txtIDCaFood.Text = dataGridViewX3.SelectedCells[2].Value.ToString();
                txtPriceFood.Text = dataGridViewX3.SelectedCells[3].Value.ToString();
                txtImage.Text = dataGridViewX3.SelectedCells[4].Value.ToString();
            }
            catch
            {

            }
        }

        private void dataGridViewX4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                txtIDCoupon.Text = dataGridViewX4.SelectedCells[0].Value.ToString();
                txtDesCoupon.Text = dataGridViewX4.SelectedCells[1].Value.ToString();
                txtValueCoupon.Text = dataGridViewX4.SelectedCells[2].Value.ToString();

            }
            catch
            {

            }
        }
        #region btn Employee


        private void btnAddEmp_Click(object sender, EventArgs e)
        {

            string id = txtIDEmp.Text;
            string name = txtNameEmp.Text;
            string phone = txtPhoneEmp.Text;
            string address = txtAddressEmp.Text;


            int sex = 0;
            if (ckbNamEmp.Checked == true)
            {
                sex = 1;
            }
            else
            {
                sex = 0;
            }
            EmployeeBUS.Instance.Add(txtNameEmp.Text, txtPhoneEmp.Text, txtAddressEmp.Text, sex);
            LoadViews();
        }

        private void btnEditEmp_Click(object sender, EventArgs e)
        {

            string id = txtIDEmp.Text;
            string name = txtNameEmp.Text;
            string phone = txtPhoneEmp.Text;
            string address = txtAddressEmp.Text;
            int sex = 0;
            if (ckbNamEmp.Checked == true)
            {
                sex = 1;
            }
            else
            {
                sex = 0;
            }
            EmployeeBUS.Instance.Edit(id, name, phone, address, sex);
            LoadViews();
        }

        private void btnDelEmp_Click(object sender, EventArgs e)
        {
            string id = txtIDEmp.Text;
            EmployeeBUS.Instance.Delete(id);
            LoadViews();
        }
        #endregion

        #region btn FoodCategory


        private void btnAddFoodCa_Click(object sender, EventArgs e)
        {
            string id = txtIDFoodCa.Text;
            string name = txtNameFoodCa.Text;
            FoodCategoryBUS.Instance.Add(name);
            LoadViews();
        }

        private void btnEditFoodCa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDFoodCa.Text);
            string name = txtNameFoodCa.Text;
            FoodCategoryBUS.Instance.Edit(id, name);
            LoadViews();
        }

        private void btnDelFoodCa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDFoodCa.Text);
            FoodCategoryBUS.Instance.Delete(id);
            LoadViews();
        }
        #endregion
        #region btn Food



        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string id = txtIdFood.Text;
            string name = txtNameFood.Text;
            int idCategory = int.Parse(txtIDCaFood.Text);
            float price = float.Parse(txtPriceFood.Text);
            string image = txtImage.Text;

            FoodBUS.Instance.Add(name, idCategory, price, image);
            LoadViews();

        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string id = txtIdFood.Text;
            string name = txtNameFood.Text;
            int idCategory = int.Parse(txtIDCaFood.Text);
            float price = float.Parse(txtPriceFood.Text);
            string image = txtImage.Text;

            FoodBUS.Instance.Edit(id, name, idCategory, price, image);
            LoadViews();
        }

        private void btnDelFood_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtIdFood.Text);
            FoodBUS.Instance.Delete(id);
            LoadViews();
        }
        #endregion

        #region btn Coupon


        private void btnAddCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtIDCoupon.Text;
                string des = txtDesCoupon.Text;
                string value = txtValueCoupon.Text;

                CouponBUS.Instance.Add(id, des, value);
                LoadViews();
            }
            catch
            {
                MessageBox.Show("Thêm khuyến mãi thất bại");

            }
           
        }

        private void btnEditCoupon_Click(object sender, EventArgs e)
        {
            string id = txtIDCoupon.Text;
            string des = txtDesCoupon.Text;
            string value = txtValueCoupon.Text;

            CouponBUS.Instance.Edit(id, des, value);
            LoadViews();
        }

        private void btnDelCoupon_Click(object sender, EventArgs e)
        {
            string id = txtIDCoupon.Text;
            CouponBUS.Instance.Delete(id);
            LoadViews();
        }
        #endregion
    }
}
