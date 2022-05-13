using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mentoring.Models
{
    public class MentorDataContext:IdentityDbContext
    {
        public DbSet<Subject> subject { get; set; }

        public DbSet<Semester> semester { get; set; }
        public DbSet<Group> group { get; set; }
        public DbSet<Mentee> mentee { get; set; }
        public DbSet<Mentor> mentors { get; set; }
        public DbSet<Session> session { get; set; }


        public MentorDataContext(DbContextOptions<MentorDataContext> options): base(options)
        {
            Database.EnsureCreated();
        }

    }
}
