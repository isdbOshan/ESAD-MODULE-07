using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarInformation.Models.CarAnnotation
{
    [MetadataType(typeof(CarPartsMetaData))]
    public partial class CarPartsInformationMetaData { }
    public class CarPartsMetaData
    {
        public int PartId { get; set; }
        [Required, StringLength(50)]
        public string Engine_type { get; set; }
        [Required, StringLength(50)]
        public string Fuel_type { get; set; }
        [Required, StringLength(50)]
        public string Transmission { get; set; }
        public Nullable<int> Number_of_doors { get; set; }
        [Required, StringLength(50)]
        public string Exhaust_System { get; set; }
        [Required]
        public int CarId { get; set; }
    }
}


