using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace R52_M8_Class_03_Work_01.Models
{
    public enum Group { Friends=1, Family, Colleagues, Relatives, Others}
    public class Contact
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        [EnumDataType(typeof(Group))]
        public Group Group { get; set; }
        [Required, StringLength(50)]
        public string Phone { get; set; } = default!; 
        [Required, StringLength(50), DataType(DataType.EmailAddress)]
        public string Email { get; set; }=default!;
        [Required, StringLength(30)]
        public string Picture { get; set; } = default!;
    }
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; } = default!;
    }
}
