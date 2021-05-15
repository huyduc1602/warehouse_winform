using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseApp.ReportsView
{
    class BrandModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Status { get; set; }
        public BrandModel()
        {

        }
        public BrandModel(int id, string displayName, string status)
        {
            Id = id;
            DisplayName = displayName;
            Status = status;
        }
    }
}
