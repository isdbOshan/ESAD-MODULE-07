using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R52_M7_Class_05_Work_01.Models.ViewModels
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Display(Name="Pay/Day"), DisplayFormat(DataFormatString ="{0:0.00}")]
        public decimal PayRate { get; set; }
        [Display(Name="Start Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDate { get; set; }
        [Display(Name="Days Worked")]
        public int TotalDaysWorked { get => EndDate.HasValue ? (int)((EndDate.Value - StartDate).TotalDays + 1) : 0; }
        [DisplayFormat(DataFormatString = "{0:0.00}"), Display(Name="Payment")]
        public decimal TotalPay { get => this.TotalDaysWorked * PayRate; }

    }
}