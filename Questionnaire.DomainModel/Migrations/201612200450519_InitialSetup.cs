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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Choices", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Choices", "NavigateToSectionId", "dbo.Sections");
            DropForeignKey("dbo.Sections", "QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.Sections", "NextSectionId", "dbo.Sections");
            DropIndex("dbo.Choices", new[] { "NavigateToSectionId" });
            DropIndex("dbo.Choices", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "SectionId" });
            DropIndex("dbo.Sections", new[] { "NextSectionId" });
            DropIndex("dbo.Sections", new[] { "QuestionnaireId" });
            DropTable("dbo.Choices");
            DropTable("dbo.Questions");
            DropTable("dbo.Sections");
            DropTable("dbo.Questionnaires");
        }
    }
}
