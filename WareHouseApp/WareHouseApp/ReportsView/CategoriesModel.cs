using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseApp.Reports
{
    class CategoriesModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Status { get; set; }
        public CategoriesModel()
        {

        }

        public CategoriesModel(int id, string displayName, string status)
        {
            Id = id;
            DisplayName = displayName;
            Status = status;
        }
    }
}
