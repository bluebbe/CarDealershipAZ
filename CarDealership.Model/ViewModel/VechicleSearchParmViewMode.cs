using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model.ViewModel
{
    public class VechicleSearchParmViewMode
    {
        public string KeyWords { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public string Type { get; set; }
        public bool? StillAvailable { get; set; }
    }
}
