using System.Data.Entity.ModelConfiguration;
using Blogging.Data.Entities;

namespace Blogging.Data.Configurations
{
    public class CommentConfiguration : EntityTypeConfiguration<CommentEntity>
    {
        public CommentConfiguration()
        {
            ToTable("Comment");
            HasKey(k => k.Id);
            Property(p => p.Content).HasMaxLength(200);
            //���������ϵ
            HasRequired(c=>c.Blog).WithMany(b=>b.Comments).HasForeignKey(fk => fk.BlogId).WillCascadeOnDelete(false);
        }
    }
}