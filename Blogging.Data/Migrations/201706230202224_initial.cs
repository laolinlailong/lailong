namespace Blogging.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Content = c.String(maxLength: 1000),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Content = c.String(maxLength: 200),
                        Created = c.DateTime(nullable: false),
                        BlogId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blog", t => t.BlogId)
                .Index(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "BlogId", "dbo.Blog");
            DropIndex("dbo.Comment", new[] { "BlogId" });
            DropTable("dbo.Comment");
            DropTable("dbo.Blog");
        }
    }
}
