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


namespace FastFoodDemo
{
    public partial class MySecondCustmControl : UserControl
    {
        public DataTable dt1;
        public MySecondCustmControl()
        {
            InitializeComponent();
            dataGridViewX1.DataSource = FoodBUS.Instance.ShowTable();
            dt1 = ((DataTable)dataGridViewX1.DataSource).Clone();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string id = dataGridViewX1.SelectedCells[0].Value.ToString();
            string name = dataGridViewX1.SelectedCells[1].Value.ToString();

            float price = float.Parse(dataGridViewX1.SelectedCells[3].Value.ToString());
            string image = dataGridViewX1.SelectedCells[4].Value.ToString();


            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                dt1.ImportRow(((DataTable)dataGridViewX1.DataSource).Rows[row.Index]);
            }
            dt1.AcceptChanges();

            dataGridViewX2.DataSource = dt1;
            // txt Payment
            float totalPrice = 0;
            for (int i = 0; i < dataGridViewX2.Rows.Count - 1; i++)
            {
                float item = float.Parse(dataGridViewX2.Rows[i].Cells["price"].Value.ToString());
                totalPrice += item;
            }
            txtPayment.Text = totalPrice.ToString();
            // combine row


        }

        private void btnDelFood_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridViewX2.SelectedRows)
            {
                dataGridViewX2.Rows.RemoveAt(item.Index);
            }
            float totalPrice = 0;
            for (int i = 0; i < dataGridViewX2.Rows.Count - 1; i++)
            {
                float item = float.Parse(dataGridViewX2.Rows[i].Cells["price"].Value.ToString());
                totalPrice += item;
            }
            txtPayment.Text = totalPrice.ToString();

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            DateTime dt = (DateTime.Parse(DateTime.Now.ToShortDateString()));
            // thêm bill rồi thêm billdetails theo id
            int idEmployee = 3;
            BillBUS.Instance.Add(txtCoupon.Text, idEmployee, dt);
            int idBill = BillBUS.Instance.GetMaxBill();
            for (int i = 0; i < dataGridViewX2.Rows.Count - 1; i++)
            {
                int idFood = int.Parse(dataGridViewX2.Rows[i].Cells["id"].Value.ToString());

                BillDetailsBUS.Instance.Add(idBill, idFood, 1);

            }
            string res = $"Số tiền phải trả là: {txtPayment.Text} vnđ ";
            MessageBox.Show(res);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (CouponBUS.Instance.Check(txtCoupon.Text))
            {
                float price = float.Parse(txtPayment.Text);
                string coupon = CouponBUS.Instance.GetValueByID(txtCoupon.Text);
                float value = float.Parse(coupon);
                float totalPrice = price - (price * (value / 100));
                txtPayment.Text = totalPrice.ToString();
                btnCoupon.Enabled = false;
                MessageBox.Show($"Đã áp dụng thành công khuyến mãi {coupon}%");
            }
            else
            {
                MessageBox.Show("Áp Dụng không thành công");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = FoodBUS.Instance.Search(txtSearch.Text);
        }
    }
}
