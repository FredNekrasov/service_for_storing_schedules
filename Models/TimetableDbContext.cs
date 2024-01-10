using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.models
{
    public class TimetableDbContext(DbContextOptions<TimetableDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudienceType>().HasKey(i => i.TypeID);
            modelBuilder.Entity<AudienceType>().HasMany(i => i.Rooms).WithOne().HasForeignKey(i => i.AudienceID);

            modelBuilder.Entity<Audience>().HasKey(i => i.AudienceID);
            modelBuilder.Entity<Audience>().HasMany(i => i.Pairs).WithOne().HasForeignKey(i => i.AudienceID);

            modelBuilder.Entity<Group>().HasKey(i => i.GroupID);
            modelBuilder.Entity<Group>().HasMany(i => i.Pairs).WithOne().HasForeignKey(i => i.GroupID);
            
            modelBuilder.Entity<Teacher>().HasKey(i => i.TeacherID);
            modelBuilder.Entity<Teacher>().HasMany(i => i.Pairs).WithOne().HasForeignKey(i => i.TeacherID);

            modelBuilder.Entity<Subject>().HasKey(i => i.SubjectID);
            modelBuilder.Entity<Subject>().HasMany(i => i.Pairs).WithOne().HasForeignKey(i => i.SubjectID);

            modelBuilder.Entity<Semester>().HasKey(i => i.SemesterID);
            modelBuilder.Entity<Semester>().HasMany(i => i.Weeks).WithOne().HasForeignKey(i => i.SemesterID);

            modelBuilder.Entity<Week>().HasKey(i => i.WeekID);
            modelBuilder.Entity<Week>().HasMany(i => i.Days).WithOne().HasForeignKey(i => i.WeekID);

            modelBuilder.Entity<Pair>().HasKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days).WithOne().HasForeignKey(i => i.FirstPairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days1).WithOne().HasForeignKey(i => i.SecondPairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days2).WithOne().HasForeignKey(i => i.ThirdPairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days3).WithOne().HasForeignKey(i => i.FourthPairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days4).WithOne().HasForeignKey(i => i.FifthPairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days5).WithOne().HasForeignKey(i => i.SixthPairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days6).WithOne().HasForeignKey(i => i.SeventhPairID);

            modelBuilder.Entity<Day>().HasKey(i => i.DayID);
            modelBuilder.Entity<Users>().HasKey(i => i.UserID);
        }
        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Pair> Pair { get; set; }
        public virtual DbSet<Audience> Audience { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<AudienceType> AudienceType { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Week> Week { get; set; }
    }
}
