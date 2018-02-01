using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model.DataModel;

namespace CarDealership.Model.ViewModel
{
    public class ModelMakeViewModel
    {
        public List<ModelsVM> ModelList { get; set; }
        public IEnumerable<Make> MakeList { get; set; }
        
    }
}
