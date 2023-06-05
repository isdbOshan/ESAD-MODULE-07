using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace R54_M7_Class_04_Work_02.Models
{
    public enum SpecificArea { CarbonEmission = 1, OzoneLayer, GolobalTemperature, UltraRay }
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required, StringLength(20)]
        public string DepartmentCode { get; set; }
        [EnumDataType(typeof(SpecificArea))]
        public SpecificArea WorkArea { get; set; }
        //Navigation
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required, StringLength(50)]
        public string EmployeeName { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime JoinDate { get; set; }
        public string Picture { get; set; }
        //FK
        [Required, ForeignKey("Department")]
        public int DepartmentId { get; set; }
        //Navigation
        public virtual Department Department { get; set; }
    }
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext db)
        {
            Department d = new Department { DepartmentCode = "OZ503", WorkArea = SpecificArea.OzoneLayer };
            d.Employees.Add(new Employee { EmployeeName = "Dr. OZ O", JoinDate = new DateTime(2017, 8, 9), Picture="1.jpg" });
            d.Employees.Add(new Employee { EmployeeName = "Dr. OT S", JoinDate = new DateTime(2019, 8, 11), Picture="2.jpg" });
            db.Departments.Add(d);
            db.SaveChanges();
        }
    }
}