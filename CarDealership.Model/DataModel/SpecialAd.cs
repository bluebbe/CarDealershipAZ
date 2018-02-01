
using System.ComponentModel.DataAnnotations;


namespace CarDealership.Model.DataModel
{
    public class SpecialAd

    {
        [Key]
        public int SpecialAdId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
