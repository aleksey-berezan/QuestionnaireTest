namespace Questionnaire.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questionnaires", "EntityState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questionnaires", "EntityState");
        }
    }
}
