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
    public partial class ProductChoose : Form
    {
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        public int Id { get; set; }
        public double Price { get; set; }
        public double PurchasePrice { get; set; }
        public string Action { get; set; }

        public ProductChoose()
        {
            InitializeComponent();
        }

        private void ProductChoose_Load(object sender, EventArgs e)
        {
            dgvProduct.ColumnCount = 13;
            dgvProduct.Columns[0].HeaderText = "Mã";
            dgvProduct.Columns[0].DataPropertyName = "Id";

            dgvProduct.Columns[1].HeaderText = "SKU";
            dgvProduct.Columns[1].DataPropertyName = "Sku";

            dgvProduct.Columns[2].HeaderText = "Tên";
            dgvProduct.Columns[2].DataPropertyName = "DisplayName";

            dgvProduct.Columns[3].HeaderText = "Số lượng";
            dgvProduct.Columns[3].DataPropertyName = "Quantity";

            dgvProduct.Columns[4].HeaderText = "Giá nhập";
            dgvProduct.Columns[4].DataPropertyName = "PurchasePrice";

            dgvProduct.Columns[5].HeaderText = "Giá bán";
            dgvProduct.Columns[5].DataPropertyName = "Price";

            dgvProduct.Columns[6].HeaderText = "Đơn vị";
            dgvProduct.Columns[6].DataPropertyName = "Unit";

            dgvProduct.Columns[7].HeaderText = "Danh mục";
            dgvProduct.Columns[7].DataPropertyName = "Category";

            dgvProduct.Columns[8].HeaderText = "Hãng";
            dgvProduct.Columns[8].DataPropertyName = "Brand";

            dgvProduct.Columns[9].HeaderText = "Nhà cung cấp";
            dgvProduct.Columns[9].DataPropertyName = "Supplier";

            dgvProduct.Columns[10].HeaderText = "Ảnh sản phẩm";
            dgvProduct.Columns[10].DataPropertyName = "Image";

            dgvProduct.Columns[11].HeaderText = "Ghi chú";
            dgvProduct.Columns[11].DataPropertyName = "MoreInfo";

            dgvProduct.Columns[12].HeaderText = "Trạng thái";
            dgvProduct.Columns[12].DataPropertyName = "Status";

            dgvProduct.DataSource = from p in db.Products
                                  select new
                                  {
                                      Id = p.Id,
                                      Sku = p.Sku,
                                      DisplayName = p.DisplayName,
                                      Quantity = p.Quantity,
                                      PurchasePrice = string.Format("{0:N0}", p.PurchasePrice),
                                      Price = string.Format("{0:N0}", p.Price),
                                      Unit = p.Unit.DisplayName,
                                      Category = p.Category.DisplayName,
                                      Brand = p.Brand.DisplayName,
                                      Supplier = p.Suplier.DisplayName,
                                      Image = p.Image,
                                      MoreInfo = p.MoreInfo,
                                      Status = p.Quantity == 0 ? "Hết hàng" : "Còn hàng"
                                  };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow != null)
            {
                if (Action == "Export")
                {
                    if ((int)dgvProduct.CurrentRow.Cells[3].Value == 0)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        MessageBox.Show("Sản phẩm này đã hết hàng không thể xuất", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ActionChoose();
                    }
                }
                else
                {
                    ActionChoose();
                }
                
            }
            else
            {
                MessageBox.Show("Lỗi thao tác", "Vui lòng chọn 1 sản phẩm ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActionChoose()
        {
            int id = (int)dgvProduct.CurrentRow.Cells[0].Value;
            double purchasePrice = Convert.ToDouble(dgvProduct.CurrentRow.Cells[4].Value);
            double price = Convert.ToDouble(dgvProduct.CurrentRow.Cells[5].Value);

            Id = id;
            PurchasePrice = purchasePrice;
            Price = price;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
