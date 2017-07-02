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
            //ÿ������Update-Database�����������������
            BloggingDatabaseSeed.Seed(dbContext);
        }
    }
}
