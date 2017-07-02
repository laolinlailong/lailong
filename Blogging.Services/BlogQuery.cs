using System;
using System.Collections.Generic;
using System.Linq;
using Blogging.Data;
using Blogging.Services.ImplementedInterfaces;
using Blogging.Services.ImplementedInterfaces.InputModels;
using Blogging.Services.ImplementedInterfaces.Queries;

namespace Blogging.Services
{
    public class BlogQuery:IBlogQuery
    {
        private readonly BloggingDbContext _dbContext;
        public BlogQuery(BloggingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BlogListItemViewModel> Blogs()
        {
            return (from blog in _dbContext.Blogs
                orderby blog.Created descending
                select new BlogListItemViewModel
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Content = blog.Content,
                    Created = blog.Created,
                }
                ).Take(50).ToList();
        }

        public BlogDetailViewModel Blog(long id)
        {
            var blogEntity = _dbContext.Blogs.FirstOrDefault(b => b.Id == id);
            if(blogEntity == null) throw new BlogNotFoundException(id.ToString());

            var blog = new BlogDetailViewModel
            {
                 Id = blogEntity.Id,
                 Title = blogEntity.Title,
                 Content = blogEntity.Content,
                 Created = blogEntity.Created,
            };

            blog.Comments = (from comment in _dbContext.Comments
                where comment.BlogId == id
                orderby comment.Created descending
                select new CommentListItemViewModel
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    Created = comment.Created,
                }).Take(20).ToList();
            return blog;
        }
    }
}
