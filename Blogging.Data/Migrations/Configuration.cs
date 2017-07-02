using Blogging.Data.Entities;

namespace Blogging.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blogging.Data.BloggingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BloggingDbContext dbContext)
        {
            //每次运行Update-Database，都会运行这个函数
            BloggingDatabaseSeed.Seed(dbContext);
        }
    }
}
