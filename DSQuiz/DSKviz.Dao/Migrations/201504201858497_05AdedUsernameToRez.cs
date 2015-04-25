namespace DSKviz.Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05AdedUsernameToRez : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResultDetails", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.ResultDetails", "ResultDetail_ID", "dbo.ResultDetails");
            DropForeignKey("dbo.ResultDetails", "Result_ID", "dbo.Results");
            DropIndex("dbo.ResultDetails", new[] { "QuizID" });
            DropIndex("dbo.ResultDetails", new[] { "ResultDetail_ID" });
            DropIndex("dbo.ResultDetails", new[] { "Result_ID" });
            RenameColumn(table: "dbo.ResultDetails", name: "Result_ID", newName: "ResultID");
            AddColumn("dbo.Results", "UserName", c => c.String());
            AddColumn("dbo.ResultDetails", "Question", c => c.String());
            AddColumn("dbo.ResultDetails", "CorrectAnswer", c => c.String());
            AddColumn("dbo.ResultDetails", "UserAnswer", c => c.String());
            AddColumn("dbo.ResultDetails", "IsCorect", c => c.String());
            AddColumn("dbo.ResultDetails", "UserName", c => c.String());
            AlterColumn("dbo.ResultDetails", "ResultID", c => c.Int(nullable: false));
            CreateIndex("dbo.ResultDetails", "ResultID");
            AddForeignKey("dbo.ResultDetails", "ResultID", "dbo.Results", "ID", cascadeDelete: true);
            DropColumn("dbo.ResultDetails", "TotalPoints");
            DropColumn("dbo.ResultDetails", "QuizID");
            DropColumn("dbo.ResultDetails", "ResultDetail_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ResultDetails", "ResultDetail_ID", c => c.Int());
            AddColumn("dbo.ResultDetails", "QuizID", c => c.Int(nullable: false));
            AddColumn("dbo.ResultDetails", "TotalPoints", c => c.Int(nullable: false));
            DropForeignKey("dbo.ResultDetails", "ResultID", "dbo.Results");
            DropIndex("dbo.ResultDetails", new[] { "ResultID" });
            AlterColumn("dbo.ResultDetails", "ResultID", c => c.Int());
            DropColumn("dbo.ResultDetails", "UserName");
            DropColumn("dbo.ResultDetails", "IsCorect");
            DropColumn("dbo.ResultDetails", "UserAnswer");
            DropColumn("dbo.ResultDetails", "CorrectAnswer");
            DropColumn("dbo.ResultDetails", "Question");
            DropColumn("dbo.Results", "UserName");
            RenameColumn(table: "dbo.ResultDetails", name: "ResultID", newName: "Result_ID");
            CreateIndex("dbo.ResultDetails", "Result_ID");
            CreateIndex("dbo.ResultDetails", "ResultDetail_ID");
            CreateIndex("dbo.ResultDetails", "QuizID");
            AddForeignKey("dbo.ResultDetails", "Result_ID", "dbo.Results", "ID");
            AddForeignKey("dbo.ResultDetails", "ResultDetail_ID", "dbo.ResultDetails", "ID");
            AddForeignKey("dbo.ResultDetails", "QuizID", "dbo.Quizs", "ID", cascadeDelete: true);
        }
    }
}
