using System;
using System.Linq;
using Blogging.Data;
using Blogging.Data.Entities;
using Blogging.Services.ImplementedInterfaces;
using Blogging.Services.ImplementedInterfaces.InputModels;
using Blogging.Services.ImplementedInterfaces.Services;

namespace Blogging.Services
{
    public class BlogService:IBlogService
    {
        private readonly BloggingDbContext _dbContext; 

        public BlogService(BloggingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public long Create(BlogInputModel model)
        {
            if(model == null) throw new ArgumentNullException("model");

            var blog = new BlogEntity
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now
            };

            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();
            return blog.Id;
        }

        public long Comment(CommentInputModel model)
        {
            if(model == null) throw new ArgumentNullException("model");

            var blogFound = _dbContext.Blogs.Any(b=>b.Id == model.BlogId);

            if (!blogFound)
            {
                throw new BlogNotFoundException(string.Format("博客Id {0}找不到", model.BlogId));
            }

            var comment = new CommentEntity
            {
                BlogId = model.BlogId,
                Content = model.Content,
                Created = DateTime.Now
            };
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
            return comment.Id;
        }
    }
}
