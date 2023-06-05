using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace R52_M7_Class_05_Work_01.Models
{
    public class Worker
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, Column(TypeName ="money")]
        public decimal PayRate { get; set; }
        [Required, Column(TypeName ="date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
    }
    public class WorkerDbContext:DbContext
    {
        public WorkerDbContext() {
            Database.SetInitializer(new DbSeeder());
        }
        public DbSet<Worker> Workers { get; set;}
    }
    public class DbSeeder : DropCreateDatabaseIfModelChanges<WorkerDbContext>
    {
        protected override void Seed(WorkerDbContext db)
        {
            for(var i=1; i<=12; i++)
            {
                db.Workers.Add(
                    new Worker { 
                        Name = $"W{i}", 
                        PayRate = i * 150.00M, 
                        StartDate = DateTime.Today.AddDays((-1) * i * 7), 
                        EndDate = DateTime.Today.AddDays((-1) * i) 
                    }
                ); 
            }
            db.SaveChanges();
        }
    }
}