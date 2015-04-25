namespace DSKviz.Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03FixCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "CategoryID" });
            RenameColumn(table: "dbo.Questions", name: "CategoryID", newName: "Category_ID");
            AddColumn("dbo.Quizs", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Category_ID", c => c.Int());
            CreateIndex("dbo.Questions", "Category_ID");
            CreateIndex("dbo.Quizs", "CategoryID");
            AddForeignKey("dbo.Quizs", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Category_ID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Quizs", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Quizs", new[] { "CategoryID" });
            DropIndex("dbo.Questions", new[] { "Category_ID" });
            AlterColumn("dbo.Questions", "Category_ID", c => c.Int(nullable: false));
            DropColumn("dbo.Quizs", "CategoryID");
            RenameColumn(table: "dbo.Questions", name: "Category_ID", newName: "CategoryID");
            CreateIndex("dbo.Questions", "CategoryID");
            AddForeignKey("dbo.Questions", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
