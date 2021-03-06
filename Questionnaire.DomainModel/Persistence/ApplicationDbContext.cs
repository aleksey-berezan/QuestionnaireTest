﻿using System.Data.Entity;
using Questionnaire.DomainModel.EntityConfigurations;
using Questionnaire.DomainModel.Model;

namespace Questionnaire.DomainModel.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerChoiceConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Model.Questionnaire> Questionnaires { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuestionnaireSession> QuestionnaireSessions { get; set; }
    }
}