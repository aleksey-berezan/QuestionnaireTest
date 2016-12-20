namespace Questionnaire.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAnswer : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SelectedAnswers", newName: "ChosenAnswers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ChosenAnswers", newName: "SelectedAnswers");
        }
    }
}
