namespace R52_M7_Class_07_Work_01.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<R52_M7_Class_07_Work_01.Models.BooksDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(R52_M7_Class_07_Work_01.Models.BooksDbContext context)
        {
            
        }
    }
}
