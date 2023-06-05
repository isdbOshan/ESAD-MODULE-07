using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarPartsInfoDetails0701.Models
{
    [MetadataType(typeof(CarDetailMetaData))]
    public partial class CarDetailInfoModel { }
    public class CarDetailMetaData
    {
        public int CarId { get; set; }
        [Required, StringLength(50)]
        public string Model { get; set; }
        [Required, DataType(DataType.Date)]
        public System.DateTime Make { get; set; }
        public string Color { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public Nullable<bool> Availabel { get; set; }
        [Required, StringLength(30)]
        public string Picture { get; set; }
    }
}