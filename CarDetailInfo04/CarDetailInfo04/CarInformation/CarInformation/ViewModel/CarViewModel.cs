using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarInformation.ViewModel
{
    public class CarViewModel
    {
        public int CarId { get; set; }
        [Required, StringLength(50)]
        public string Model { get; set; }
        [Required, DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public System.DateTime Make { get; set; }
        public string Color { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public bool Availabel { get; set; }
        [Required]
        public HttpPostedFileBase Picture { get; set; }
    }
}

