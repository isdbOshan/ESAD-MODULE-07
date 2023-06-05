namespace R52_M7_Class_06_Work_01.Migrations
{
    using R52_M7_Class_06_Work_01.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<R52_M7_Class_06_Work_01.Models.ArticleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(R52_M7_Class_06_Work_01.Models.ArticleDbContext db)
        {
            db.Articles.Add(new Article { Title = "MVC 5", PublishDate = new DateTime(2022, 9, 11), TotalView = 9023, Rating = 4.2 });
            db.Articles.Add(new Article { Title = "MVC Core", PublishDate = new DateTime(2022, 11, 11), TotalView = 9023, Rating = 4.4 });
            db.SaveChanges();
        }
    }
}
