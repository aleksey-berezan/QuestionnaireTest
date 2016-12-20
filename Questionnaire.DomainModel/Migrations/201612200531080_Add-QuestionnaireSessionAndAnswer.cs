namespace Questionnaire.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionnaireSessionAndAnswer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionnaireSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionnaireId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        CurrentQuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.CurrentQuestionId)
                .ForeignKey("dbo.Questionnaires", t => t.QuestionnaireId, cascadeDelete: true)
                .Index(t => t.QuestionnaireId)
                .Index(t => t.CurrentQuestionId);
            
            CreateTable(
                "dbo.SelectedAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        QuestionnaireSessionId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        ChoiceId = c.Int(nullable: false),
                        QuestionnaireSession_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Choices", t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionnaireSessions", t => t.Id)
                .ForeignKey("dbo.QuestionnaireSessions", t => t.QuestionnaireSession_Id)
                .Index(t => t.Id)
                .Index(t => t.QuestionId)
                .Index(t => t.QuestionnaireSession_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionnaireSessions", "QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.QuestionnaireSessions", "CurrentQuestionId", "dbo.Questions");
            DropForeignKey("dbo.SelectedAnswers", "QuestionnaireSession_Id", "dbo.QuestionnaireSessions");
            DropForeignKey("dbo.SelectedAnswers", "Id", "dbo.QuestionnaireSessions");
            DropForeignKey("dbo.SelectedAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.SelectedAnswers", "Id", "dbo.Choices");
            DropIndex("dbo.SelectedAnswers", new[] { "QuestionnaireSession_Id" });
            DropIndex("dbo.SelectedAnswers", new[] { "QuestionId" });
            DropIndex("dbo.SelectedAnswers", new[] { "Id" });
            DropIndex("dbo.QuestionnaireSessions", new[] { "CurrentQuestionId" });
            DropIndex("dbo.QuestionnaireSessions", new[] { "QuestionnaireId" });
            DropTable("dbo.SelectedAnswers");
            DropTable("dbo.QuestionnaireSessions");
        }
    }
}
