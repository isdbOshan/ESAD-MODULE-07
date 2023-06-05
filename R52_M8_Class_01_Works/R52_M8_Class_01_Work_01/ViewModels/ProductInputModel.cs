using Microsoft.EntityFrameworkCore.Metadata.Internal;
using R52_M8_Class_01_Work_01.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R52_M8_Class_01_Work_01.ViewModels
{
    public class ProductInputModel : EntityBase
    {
        [Required, StringLength(50)]
        public string ProductName { get; set; } = default!;
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int CategoryId { get; set; }
      
    }
}
