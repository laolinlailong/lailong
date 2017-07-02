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
            Title = "ÿ���˶���ѡ���Ҹ�������",
            Content = "ÿ���˶�ҪΪ�Լ���ѡ���� �ܶ�ǰ��������ѯ�������ߣ����������ǻ�û��ѧ�ᰮ�Լ����ˣ�Ҳ�ǻ��������׶��Լ�����",
            Created = new DateTime(2017, 3, 19),
        };

        dbContext.Blogs.AddOrUpdate(b => b.Id, blog);

        var firstComment = new CommentEntity
        {
            Id = 1,
            Blog = blog,
            Content = "�Ҹ�ͬ����",
        };

        var secondComment = new CommentEntity
        {
            Id = 2,
            BlogId = 1, //����ָ������ķ�ʽ������ָ��BlogId������ָ��Blog�� EF���Զ������.
            Content = "�Ҹ�ͬ����",
        };

        dbContext.Comments.AddOrUpdate(c => c.Id, firstComment);
        dbContext.Comments.AddOrUpdate(c => c.Id, secondComment);
    }
}