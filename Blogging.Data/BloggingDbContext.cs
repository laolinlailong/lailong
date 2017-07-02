using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Blogging.Data.Entities;

namespace Blogging.Data
{
    public class BloggingDbContext:DbContext
    {
        public DbSet<BlogEntity> Blogs { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //反射添加所有的数据库表配置
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(BloggingDbContext)));

            Database.SetInitializer(new BloggingCreateDbIfNotExistsInitializer());
        }
    }

    /// <summary>
    /// 这个只有在当前对应的数据库不存在的时候，才会运行。其中Seed方法正好可以初始化数据,
    /// 但是假如数据库已经存在，需要再次Seed就不行了。这个时候，我们应该使用EF Code-First Migration的Seed方法。
    /// 详细请见BloggingDatabaseSeed.Seed的方法在Migration的Configuration.cs文件中的调用
    /// </summary>
    public class BloggingCreateDbIfNotExistsInitializer : CreateDatabaseIfNotExists<BloggingDbContext>
    {
        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed. </param>
        protected override void Seed(BloggingDbContext context)
        {
            base.Seed(context);
            BloggingDatabaseSeed.Seed(context);
        }
    }

}
