using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseApp.Reports
{
    class ProductModel
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public string DisplayName { get; set; }
        public double PurcharePrice { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public string Status { get; set; }
        public ProductModel()
        {

        }

        public ProductModel(string sku, int quantity, string displayName, double purcharePrice, double price, string unit, string brand, string category, string supplier, string status)
        {
            Sku = sku;
            Quantity = quantity;
            DisplayName = displayName;
            PurcharePrice = purcharePrice;
            Price = price;
            Unit = unit;
            Brand = brand;
            Category = category;
            Supplier = supplier;
            Status = status;
        }
    }
}
