using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model.ViewModel
{
    public class InventoryReportsVM
    {
        public List<ReportViewModel> New { get; set; }
        public List<ReportViewModel> Used { get; set; }
    }
}
