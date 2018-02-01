using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarDealership.Model.DataModel
{
    public class Inventory
    {
        public int Id { get; set; }
        //public int MakeId { get; set; }
        public int MdleId { get; set; }
        public int TypId { get; set; }
        public int BodyStyleId { get; set; }
        public int Year { get; set; }
        public int TransmissionId { get; set; }
        public int ColorId { get; set; }
        public int InteriorId { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int MSRP { get; set; }
        public int SalesPrice { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool FeatureVehicle { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? PurchaseTypeId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? SalesPersonId { get; set; }
        public byte[] PictureData { get; set; }
        public string PictureURL { get; set; }

        //[ForeignKey("MakeId")]
        //public virtual Make Makes { get; set; }
        [ForeignKey("MdleId")]
        public virtual Mdle Mdles { get; set; }
        [ForeignKey("TypId")]
        public virtual Typ Typs { get; set; }
        [ForeignKey("BodyStyleId")]
        public virtual BodyStyle BodyStyles { get; set; }
        [ForeignKey("TransmissionId")]
        public virtual Transmission Transmissions { get; set; }
        [ForeignKey("ColorId")]
        public virtual Color Colors { get; set; }
        [ForeignKey("InteriorId")]
        public virtual Interior Interiors { get; set; }
        [ForeignKey("PurchaseTypeId")]
        public virtual PurchaseType PurchaseTypes { get; set; }
        //[ForeignKey("SalesPersonId")]
        //public virtual SalesPerson SalesPersons { get; set; } 
        
       
    }
}
