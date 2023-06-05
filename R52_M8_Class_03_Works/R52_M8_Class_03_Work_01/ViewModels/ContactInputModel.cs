using R52_M8_Class_03_Work_01.Models;
using System.ComponentModel.DataAnnotations;


namespace R52_M8_Class_03_Work_01.ViewModels
{
    public class ContactInputModel
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        [EnumDataType(typeof(Group))]
        public Group Group { get; set; }
        [Required, StringLength(50)]
        public string Phone { get; set; } = default!;
        [Required, StringLength(50), DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [Required]
        public IFormFile Picture { get; set; } = default!;
    }
}
