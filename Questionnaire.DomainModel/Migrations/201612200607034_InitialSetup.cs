namespace Questionnaire.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questionnaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        EntityState = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        Version = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        QuestionnaireId = c.Int(nullable: false),
                        NextSectionId = c.Int(),
                        EntityId = c.Int(nullable: false),
                        Version = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.NextSectionId)
                .ForeignKey("dbo.Questionnaires", t => t.QuestionnaireId, cascadeDelete: true)
                .Index(t => t.QuestionnaireId)
                .Index(t => t.NextSectionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        SectionId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        Version = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        NavigateToSectionId = c.Int(),
                        Score = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        Version = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.NavigateToSectionId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.NavigateToSectionId);
            
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.CurrentQuestionId)
                .ForeignKey("dbo.Questionnaires", t => t.QuestionnaireId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.QuestionnaireId)
                .Index(t => t.CurrentQuestionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SelectedAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        QuestionnaireSessionId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        ChoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Choices", t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionnaireSessions", t => t.QuestionnaireSessionId)
                .Index(t => t.Id)
                .Index(t => t.QuestionnaireSessionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionnaireSessions", "UserId", "dbo.Users");
            DropForeignKey("dbo.QuestionnaireSessions", "QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.QuestionnaireSessions", "CurrentQuestionId", "dbo.Questions");
            DropForeignKey("dbo.SelectedAnswers", "QuestionnaireSessionId", "dbo.QuestionnaireSessions");
            DropForeignKey("dbo.SelectedAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.SelectedAnswers", "Id", "dbo.Choices");
            DropForeignKey("dbo.Questions", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Choices", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Choices", "NavigateToSectionId", "dbo.Sections");
            DropForeignKey("dbo.Sections", "QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.Sections", "NextSectionId", "dbo.Sections");
            DropIndex("dbo.SelectedAnswers", new[] { "QuestionId" });
            DropIndex("dbo.SelectedAnswers", new[] { "QuestionnaireSessionId" });
            DropIndex("dbo.SelectedAnswers", new[] { "Id" });
            DropIndex("dbo.QuestionnaireSessions", new[] { "UserId" });
            DropIndex("dbo.QuestionnaireSessions", new[] { "CurrentQuestionId" });
            DropIndex("dbo.QuestionnaireSessions", new[] { "QuestionnaireId" });
            DropIndex("dbo.Choices", new[] { "NavigateToSectionId" });
            DropIndex("dbo.Choices", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "SectionId" });
            DropIndex("dbo.Sections", new[] { "NextSectionId" });
            DropIndex("dbo.Sections", new[] { "QuestionnaireId" });
            DropTable("dbo.Users");
            DropTable("dbo.SelectedAnswers");
            DropTable("dbo.QuestionnaireSessions");
            DropTable("dbo.Choices");
            DropTable("dbo.Questions");
            DropTable("dbo.Sections");
            DropTable("dbo.Questionnaires");
        }
    }
}
