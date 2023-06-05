using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDetails_07_03.Models
{
    [MetadataType(typeof(QualificationMetadata))]
    public partial class Qualification
    {
    }
    public partial class QualificationMetadata
    {
        public int QualificationId { get; set; }
        [Required, StringLength(50)]
        public string Degree { get; set; }
        [Required]
        public int PassingYear { get; set; }
        [Required, StringLength(50)]
        public string Institute { get; set; }
        [Required, StringLength(20)]
        public string Result { get; set; }
        [Required]
        public int CandidateId { get; set; }


    }
}