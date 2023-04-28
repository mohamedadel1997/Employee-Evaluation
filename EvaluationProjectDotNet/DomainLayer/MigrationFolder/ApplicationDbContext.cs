using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.MigrationFolder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(d => d.Department)
                .WithMany(e => e.Employees)
                .HasForeignKey(d => d.DepartmentId);

            modelBuilder.Entity<Evaluation>()
                .HasOne<Department>(d => d.Department)
                .WithMany(e => e.Evaluations)
                .HasForeignKey(d => d.DepartmentId);

            modelBuilder.Entity<EmployeeEvaluationAnswer>()
                .HasOne<Employee>(e => e.Employee)
                .WithMany(v => v.EmployeeEvaluationAnswers)
                .HasForeignKey(f => f.EmployeeId);

            modelBuilder.Entity<EmployeeEvaluationAnswer>()
                .HasOne<QuestionsEvaluation>(qe => qe.QuestionsEvaluation)
                .WithMany(a => a.EmployeeEvaluationAnswers)
                .HasForeignKey(f => f.QuestionsEvaluationId);

            modelBuilder.Entity<QuestionsEvaluation>()
                .HasOne<Questions>(qe => qe.Questions)
                .WithMany(a => a.QuestionsEvaluations)
                .HasForeignKey(f => f.QuestionId);

            modelBuilder.Entity<QuestionsEvaluation>()
                .HasOne<Evaluation>(e => e.Evaluation)
                .WithMany(a => a.QuestionsEvaluations)
                .HasForeignKey(f => f.EvaluationId);

            modelBuilder.Entity<EmployeeEvaluation>()
                .Ignore("Id");


            //modelBuilder.Entity<QuestionsEvaluation>()
            //    .HasKey(qe => new { qe.EvaluationId, qe.QuestionId });

            modelBuilder.Entity<EmployeeEvaluation>()
                .HasKey(ee => new { ee.EmployeeId, ee.EvaluationId });

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuestionsEvaluation> QuestionsEvaluations { get; set; }
        public DbSet<EmployeeEvaluationAnswer> EmployeeEvaluationAnswers { get; set; }
        public DbSet<EmployeeEvaluation> GetEmployeeEvaluations { get; set; }


    }
}
