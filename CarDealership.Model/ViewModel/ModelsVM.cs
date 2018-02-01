using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model.ViewModel
{
    public class ModelsVM
    {
        public int MdleId { get; set; }
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public DateTime Created { get; set; }
        public int MakeId { get; set; }
        public int AdminId { get; set; }
        public string User { get; set; }
    }
}
