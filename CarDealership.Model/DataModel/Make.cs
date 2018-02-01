using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Model.DataModel
{
    public class Make
    {
        
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public DateTime Created { get; set; }
        public int AdminId { get; set; }
    }
}
