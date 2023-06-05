using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ev_07.Models.Annotations
{
    [MetadataType(typeof(CandidateMetadata))]
    public partial class Candidate { }
    public partial class CandidateMetadata
    {
        public int CandidateId { get; set; }
        [Required, StringLength(50)]
        public string CandidateName { get; set; }
        [Required, DataType(DataType.Date)]
        public System.DateTime BirthDate { get; set; }
        [Required, StringLength(30)]
        public string AppliedFor { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal ExpectedSalary { get; set; }
        public Nullable<bool> WorkFromHome { get; set; }
        [Required, StringLength(30)]
        public string Picture { get; set; }
    }
}