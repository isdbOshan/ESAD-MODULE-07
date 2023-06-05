using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R54_M7_Class_04_Work_01.Models
{
    [MetadataType(typeof(DepartmentEntity))]
    public partial class Department
    {
    }
    [MetadataType(typeof(EmployeeEntity))]
    public partial class Employee { }
    public partial class EmployeeEntity
    {
        public int EmployeeId { get; set; }
        [Required, StringLength(50)]
        public string EmployeeName { get; set; }
        [Required, DataType(DataType.Date)]
        public System.DateTime JoinDate { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Picture { get; set; }

       
    }
    public partial class DepartmentEntity
    {
      
        public int DepartmentId { get; set; }
        [Required, StringLength(30)]
        public string DepartmentCode { get; set; }
      
        public int WorkArea { get; set; }

        
    }
}