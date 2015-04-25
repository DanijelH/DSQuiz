namespace DSKviz.Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04FixOfAFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "Category_ID" });
            DropColumn("dbo.Questions", "Category_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Category_ID", c => c.Int());
            CreateIndex("dbo.Questions", "Category_ID");
            AddForeignKey("dbo.Questions", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
