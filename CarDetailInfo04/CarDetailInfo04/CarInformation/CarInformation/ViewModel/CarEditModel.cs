using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarInformation.ViewModel
{
    public class CarEditModel
    {
        public int CarId { get; set; }
        [Required, StringLength(50)]
        public string Model { get; set; }
        [Required, DataType(DataType.Date)]
        public System.DateTime Make { get; set; }
        public string Color { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public bool Availabel { get; set; }
        public HttpPostedFileBase Picture { get; set; }
    }
}



