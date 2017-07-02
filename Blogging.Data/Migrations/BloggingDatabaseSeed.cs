using System;
using System.Data.Entity.Migrations;
using Blogging.Data;
using Blogging.Data.Entities;

internal static class BloggingDatabaseSeed
{
    internal static void Seed(BloggingDbContext dbContext)
    {
        var blog = new BlogEntity
        {
            Id = 1,
            Title = "每个人都有选择幸福的自由",
            Content = "每个人都要为自己的选择负责 很多前来心理咨询的来访者，几乎都是是还没有学会爱自己的人，也是还不大明白对自己负责",
            Created = new DateTime(2017, 3, 19),
        };

        dbContext.Blogs.AddOrUpdate(b => b.Id, blog);

        var firstComment = new CommentEntity
        {
            Id = 1,
            Blog = blog,
            Content = "我感同身受",
        };

        var secondComment = new CommentEntity
        {
            Id = 2,
            BlogId = 1, //两种指定外键的方式，或者指定BlogId，或者指定Blog， EF会自动算出来.
            Content = "我感同身受",
        };

        dbContext.Comments.AddOrUpdate(c => c.Id, firstComment);
        dbContext.Comments.AddOrUpdate(c => c.Id, secondComment);
    }
}