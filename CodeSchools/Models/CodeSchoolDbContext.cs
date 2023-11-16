using Microsoft.EntityFrameworkCore;

namespace CodeSchools.Models
{
    public class CodeSchoolDbContext: DbContext
    {
        public CodeSchoolDbContext(DbContextOptions<CodeSchoolDbContext> options) : base(options)
        {

        }
        public DbSet<StudentMaster> Student_master { get; set; }
        public DbSet<StudentDetails> Student_details{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentMaster>()
                .HasOne(e => e.Student_details)
                .WithOne(e => e.Student_master)
                .HasForeignKey<StudentDetails>(e => e.Student_master_id)
                .IsRequired();
        }
    }
}
