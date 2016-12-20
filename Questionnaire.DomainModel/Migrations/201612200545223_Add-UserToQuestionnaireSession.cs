namespace Questionnaire.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToQuestionnaireSession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionnaireSessions", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.QuestionnaireSessions", "UserId");
            AddForeignKey("dbo.QuestionnaireSessions", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionnaireSessions", "UserId", "dbo.Users");
            DropIndex("dbo.QuestionnaireSessions", new[] { "UserId" });
            DropColumn("dbo.QuestionnaireSessions", "UserId");
        }
    }
}
