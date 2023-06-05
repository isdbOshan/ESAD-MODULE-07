using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarPartsInfoDetails0701.Models
{
    [MetadataType(typeof(PartsDetailMetaData))]
    public partial class PartsModelInfoModel { }
    public class PartsDetailMetaData
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