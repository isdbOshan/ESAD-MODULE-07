using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R54_M7_Class_04_Work_02.ViewModels
{
    public class EmployeeInputModel
    {
        
            public int EmployeeId { get; set; }
            [Required, StringLength(50)]
            public string EmployeeName { get; set; }
            [Required, Column(TypeName = "date")]
            public DateTime JoinDate { get; set; }
            [Required]
            public HttpPostedFileBase Picture { get; set; }
            //FK
            [Required]
            public int DepartmentId { get; set; }
            
       
    }
}