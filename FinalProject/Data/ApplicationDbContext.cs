using FinalProject.Data.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public DbSet<ReportLog> reportLogs { get; set; }
        public DbSet<Attachfile> Attachfiles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teamleader> teamleaders { get; set; }
        public DbSet<UniversitySupervisor> supervisors { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Objective> objectives { get; set; }
        public DbSet<ReportStatus> reportStatuses { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<Apprenticeship> apprenticeships { get; set; }
        public DbSet<ObjectivesSkills> objectivesSkills{ get; set; }
        public DbSet<ApprenticeshipsObjectives> apprenticeshipsObjectives { get; set; }
        public DbSet<AssignmentObjectives> assignmentObjectives { get; set; }
        
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Apprenticeship>().HasKey(x => x.apprenticeshipId);
            builder.Entity<ObjectivesSkills>().HasKey(x =>new {x.ObjectivecId,x.skillId});
            builder.Entity<ApprenticeshipsObjectives>().HasKey(x =>new {x.objectiveId,x.apprenticeshipId});
            builder.Entity<AssignmentObjectives>().HasKey(x =>new {x.assignmentId,x.objectivesId});
        }
    }
}