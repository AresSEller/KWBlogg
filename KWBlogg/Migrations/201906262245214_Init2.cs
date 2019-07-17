namespace KWBlogg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers");
            AddColumn("dbo.Comments", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Comments", "Post_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.BlogPosts", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "ApplicationUser_Id");
            CreateIndex("dbo.Comments", "Post_Id");
            CreateIndex("dbo.BlogPosts", "AuthorId");
            AddForeignKey("dbo.Comments", "Post_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BlogPosts", "AuthorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BlogPosts", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.BlogPosts", "AuthorId");
            DropColumn("dbo.Comments", "Post_Id");
            DropColumn("dbo.Comments", "ApplicationUser_Id");
            AddForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers", "Id");
        }
    }
}
