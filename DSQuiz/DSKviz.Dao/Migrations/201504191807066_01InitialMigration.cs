namespace DSKviz.Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        Points = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalPoints = c.Int(nullable: false),
                        QuizID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Quizs", t => t.QuizID, cascadeDelete: true)
                .Index(t => t.QuizID);
            
            CreateTable(
                "dbo.ResultDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalPoints = c.Int(nullable: false),
                        QuizID = c.Int(nullable: false),
                        ResultDetail_ID = c.Int(),
                        Result_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Quizs", t => t.QuizID, cascadeDelete: true)
                .ForeignKey("dbo.ResultDetails", t => t.ResultDetail_ID)
                .ForeignKey("dbo.Results", t => t.Result_ID)
                .Index(t => t.QuizID)
                .Index(t => t.ResultDetail_ID)
                .Index(t => t.Result_ID);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        Quiz_ID = c.Int(nullable: false),
                        Question_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quiz_ID, t.Question_ID })
                .ForeignKey("dbo.Quizs", t => t.Quiz_ID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_ID, cascadeDelete: true)
                .Index(t => t.Quiz_ID)
                .Index(t => t.Question_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.ResultDetails", "Result_ID", "dbo.Results");
            DropForeignKey("dbo.ResultDetails", "ResultDetail_ID", "dbo.ResultDetails");
            DropForeignKey("dbo.ResultDetails", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.Results", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.QuizQuestions", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.QuizQuestions", "Quiz_ID", "dbo.Quizs");
            DropForeignKey("dbo.Questions", "CategoryID", "dbo.Categories");
            DropIndex("dbo.QuizQuestions", new[] { "Question_ID" });
            DropIndex("dbo.QuizQuestions", new[] { "Quiz_ID" });
            DropIndex("dbo.ResultDetails", new[] { "Result_ID" });
            DropIndex("dbo.ResultDetails", new[] { "ResultDetail_ID" });
            DropIndex("dbo.ResultDetails", new[] { "QuizID" });
            DropIndex("dbo.Results", new[] { "QuizID" });
            DropIndex("dbo.Questions", new[] { "CategoryID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.ResultDetails");
            DropTable("dbo.Results");
            DropTable("dbo.Quizs");
            DropTable("dbo.Categories");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
