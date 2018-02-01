using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Model.DataModel
{
    public class Mdle

    {
    
        public int MdleId { get; set; }
        public string ModelName { get; set; }
        public DateTime Created { get; set; }
        public int MakeId { get; set; }
        public int AdminId { get; set; }

        [ForeignKey("MakeId")]
        public virtual Make Makes { get; set; }
    }
}
