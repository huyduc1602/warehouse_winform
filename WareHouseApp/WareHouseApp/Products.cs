using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseApp
{
    public partial class Products : Form
    {
        string[] source;
        string filecop;
        public int Id { get; set; }
        public string Action { get; set; }
        string[] FilenameName;
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            loadCombobox();
            if (!String.IsNullOrEmpty(Action))
            {
                if (Action.Equals("add"))
                {
                    this.ActiveControl = txtSku;
                }
                else if (Action.Equals("see"))
                {
                    btnSave.Visible = false;
                    var product = (from p in db.Products where p.Id == Id select p).First();
                    txtSku.Text = product.Sku;
                    txtName.Text = product.DisplayName;
                    txtPrice.Text = product.Price.ToString();
                    txtPurchasePrice.Text = product.PurchasePrice.ToString();
                    numberAmount.Text = product.Quantity.ToString();
                    txtCreatedDate.Value = (DateTime)product.CreatedDate;
                    getPathImage(product.Image);
                    txtMoreInfo.Text = product.MoreInfo;

                }
                else if (Action.Equals("edit"))
                {
                    var product = (from p in db.Products where p.Id == Id select p).First();
                    txtSku.Text = product.Sku;
                    txtName.Text = product.DisplayName;
                    filecop = product.Image;
                    txtPrice.Text = product.Price.ToString();
                    txtPurchasePrice.Text = product.PurchasePrice.ToString();
                    numberAmount.Text = product.Quantity.ToString();
                    txtCreatedDate.Value = (DateTime)product.CreatedDate;
                    getPathImage(product.Image);
                    txtMoreInfo.Text = product.MoreInfo;
                }
                else
                {
                    MessageBox.Show("Chưa có hành dộng nào được chọn", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void loadCombobox()
        {
            cboUnit.DataSource = db.Units;
            cboUnit.DisplayMember = "Displayname";
            cboUnit.ValueMember = "Id";

            cboBrand.DataSource = db.Brands;
            cboBrand.DisplayMember = "Displayname";
            cboBrand.ValueMember = "Id";

            cboSupplier.DataSource = db.Supliers;
            cboSupplier.DisplayMember = "DisplayName";
            cboSupplier.ValueMember = "Id";

            cboCategory.DataSource = db.Categories;
            cboCategory.DisplayMember = "DisplayName";
            cboCategory.ValueMember = "Id";

        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            Units unit = new Units();
            unit.Show();
            loadCombobox();

        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            Brands brands = new Brands();
            brands.Show();
            loadCombobox();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Suppliers supliers = new Suppliers();
            supliers.Show();
            loadCombobox();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.Show();
            loadCombobox();
        }

        private void pb1_Click(object sender, EventArgs e)
        {
            int count = 0;
            string[] FilenameName;

            openFileImage.Filter = "Files *.jpg|*.jpg|File *.png|*.png|File *.jpeg|*.jpeg";
            foreach (string item in openFileImage.FileNames)
            {
                FilenameName = item.Split('\\');
                File.Copy(item, @"Images\" + FilenameName[FilenameName.Length - 1] + string.Format("{0:HH:mm:ss tt}", DateTime.Now));
                source[count] = FilenameName[FilenameName.Length - 1];
                count++;
            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string[] FilenameName;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files *.jpg|*.jpg|File *.png|*.png|File *.jpeg|*.jpeg";
           
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                txtImage.Text = openImage.FileName;
                pb1.ImageLocation = txtImage.Text;
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (Action.Equals("edit"))
            {
                var product = db.Products.FirstOrDefault(x => x.Id == Id);
                product.DisplayName = txtName.Text;
                product.Sku = txtSku.Text;
                product.Quantity = (int?)numberAmount.Value;
                product.IdUnit = (int)cboUnit.SelectedValue;
                product.IdSupplier = (int)cboSupplier.SelectedValue;
                product.IdBrand = (int)cboBrand.SelectedValue;
                product.IdCategory = (int)cboCategory.SelectedValue;
                product.PurchasePrice = Convert.ToDouble(txtPurchasePrice.Text);
                product.Price = Convert.ToDouble(txtPrice.Text);
                product.CreatedDate = txtCreatedDate.Value;
                product.Image = filecop;
                product.MoreInfo = txtMoreInfo.Text;
                db.SubmitChanges();
                this.Close();

            }
            else
            {
                //Thêm bảng sản phẩm
                Product product = new Product();
                product.DisplayName = txtName.Text;
                product.Sku = txtSku.Text;
                product.Quantity = (int?)numberAmount.Value;
                product.IdUnit = (int)cboUnit.SelectedValue;
                product.IdSupplier = (int)cboSupplier.SelectedValue;
                product.IdBrand = (int)cboBrand.SelectedValue;
                product.IdCategory = (int)cboCategory.SelectedValue;
                product.PurchasePrice = Convert.ToDouble(txtPurchasePrice.Text);
                product.Price = Convert.ToDouble(txtPrice.Text);
                product.CreatedDate = txtCreatedDate.Value;
                product.Image = filecop;
                product.MoreInfo = txtMoreInfo.Text;
                db.Products.InsertOnSubmit(product);
                db.SubmitChanges();

                db.SubmitChanges();
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addImage(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilenameName = openFileDialog.FileName.Split('\\');
                              
                filecop = FilenameName[FilenameName.Length - 1];
                if (!File.Exists(@"Images\" + filecop))
                {
                    txtImage.Text = openFileDialog.FileName;
                   
                    File.Copy(openFileDialog.FileName , @"Images\" + filecop);
                }
                else
                {
                    MessageBox.Show("Tên ảnh đã tồn tại. Vui lòng đặt lại tên ảnh và thao tác lại !","Lỗi tải lên ảnh",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }

            }
           
        }
        private void pb1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            addImage(openFileDialog);
            pb1.ImageLocation = openFileDialog.FileName;
        }
        private void getPathImage(string fileName)
        {
            var soureImg = Application.StartupPath + "\\Images\\";
            txtImage.Text = soureImg + fileName;
            pb1.ImageLocation = soureImg + fileName;
        }

        private void txtImage_TextChanged(object sender, EventArgs e)
        {
            pb1.ImageLocation = txtImage.Text;
        }
    }
}
