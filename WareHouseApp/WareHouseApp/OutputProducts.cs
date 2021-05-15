using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseApp
{
    public partial class OutputProducts : Form
    {
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        List<OutputDetail> outputDetails = new List<OutputDetail>();
        int maxIdOutput;
        public OutputProducts()
        {
            InitializeComponent();
            txtTitle.Text = "Xuất hàng ngày " + DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            Output output = new Output();
            output.DisplayName = txtTitle.Text;
            output.CustomerId = db.Customers.First().Id;
            output.OutputDate = txtDate.Value;
            output.TotalQuantity = 0;
            output.TotalPrice = 0;
            db.Outputs.InsertOnSubmit(output);
            db.SubmitChanges();
            maxIdOutput = db.Outputs.OrderByDescending(x => x.Id).First().Id;
        }


        private void OutputProducts_Load(object sender, EventArgs e)
        {
            loadTable();
        }
        private void loadTable()
        {
            this.dgvOutputDetail.DataSource = null;
            this.dgvOutputDetail.Rows.Clear();
            this.dgvOutputDetail.Columns.Clear();
            dgvOutputDetail.ColumnCount = 6;

            dgvOutputDetail.Columns[0].HeaderText = "SKU";
            dgvOutputDetail.Columns[0].DataPropertyName = "Sku";

            dgvOutputDetail.Columns[1].HeaderText = "Tên sản phẩm";
            dgvOutputDetail.Columns[1].DataPropertyName = "DisplayName";

            dgvOutputDetail.Columns[2].HeaderText = "Số lượng";
            dgvOutputDetail.Columns[2].DataPropertyName = "Count";

            dgvOutputDetail.Columns[3].HeaderText = "Giá nhập";
            dgvOutputDetail.Columns[3].DataPropertyName = "PurchasePrice";

            dgvOutputDetail.Columns[4].HeaderText = "Giá bán";
            dgvOutputDetail.Columns[4].DataPropertyName = "Price";

            dgvOutputDetail.Columns[5].HeaderText = "Đơn vị";
            dgvOutputDetail.Columns[5].DataPropertyName = "Cái";

            foreach (var i in outputDetails)
            {
                var p = db.Products.SingleOrDefault(x => x.Id == i.ProductId);
                string[] row = new string[] {i.ProductId.ToString(),p.DisplayName,i.Quantity.ToString(),p.PurchasePrice.ToString(),i.Price.ToString(),p.Unit.DisplayName
                    };
                dgvOutputDetail.Rows.Add(row);
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Nhập bảng output
            if (outputDetails.Count > 0)
            {
                var op = db.Outputs.SingleOrDefault(x => x.Id == maxIdOutput);
                op.DisplayName = txtTitle.Text;
                op.OutputDate = txtDate.Value;
                foreach (var o in outputDetails)
                {
                    op.TotalQuantity += o.Quantity;
                    op.TotalPrice += o.Price * o.Quantity;
                }
                db.OutputDetails.InsertAllOnSubmit(outputDetails);
                db.SubmitChanges();
                db.Connection.Close();
                this.Close();
            }
        }

        private void btnCustomerChoose_Click(object sender, EventArgs e)
        {
            CustomerChoose customerChoose = new CustomerChoose();
            if (customerChoose.ShowDialog() == DialogResult.OK)
            {
                txtCustomerId.Text = customerChoose.Id.ToString();
            }
        }


        private void btnProductChoose_Click(object sender, EventArgs e)
        {
            ProductChoose productChoose = new ProductChoose();
            productChoose.Action = "Export";
            if (productChoose.ShowDialog() == DialogResult.OK)
            {
                txtProductId.Text = productChoose.Id.ToString();
                txtQuantity.Maximum = (decimal)db.Products.SingleOrDefault(x => x.Id == productChoose.Id).Quantity;
                txtPrice.Text = productChoose.Price.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tạo mới detail
            if (!String.IsNullOrEmpty(txtProductId.Text))
            {
                OutputDetail outputDetail = new OutputDetail();
                outputDetail.ProductId = Convert.ToInt32(txtProductId.Text);
                outputDetail.Price = Convert.ToDouble(txtPrice.Text);
                outputDetail.Quantity = Convert.ToInt32(txtQuantity.Value);
                outputDetail.OutputId = maxIdOutput;

                //thêm vào list detail
                outputDetails.Add(outputDetail);
                //dgvInputDetail.Rows.Add(inputDetail);
                loadTable();


            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 mã sản phẩm");
            }
        }
    }
}
