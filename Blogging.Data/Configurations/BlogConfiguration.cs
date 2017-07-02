using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogging.Data.Entities;

namespace Blogging.Data.Configurations
{
    public class BlogConfiguration: EntityTypeConfiguration<BlogEntity>
    {
        public BlogConfiguration()
        {
            ToTable("Blog");
            HasKey(k => k.Id);
            Property(p => p.Title).HasMaxLength(50);
            Property(p => p.Content).HasMaxLength(1000);
        }
    }
}
