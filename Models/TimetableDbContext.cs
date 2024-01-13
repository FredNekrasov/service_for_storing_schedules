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
            modelBuilder.Entity<AudienceType>().HasMany(i => i.Rooms).WithOne(i => i.AudienceType).HasForeignKey(i => i.AudienceTypeID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Audience>().HasMany(i => i.Pairs).WithOne(i => i.Audience).HasForeignKey(i => i.AudienceID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Group>().HasMany(i => i.Pairs).WithOne(i => i.Group).HasForeignKey(i => i.GroupID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Teacher>().HasMany(i => i.Pairs).WithOne(i => i.Teacher).HasForeignKey(i => i.TeacherID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Subject>().HasMany(i => i.Pairs).WithOne(i => i.Subject).HasForeignKey(i => i.SubjectID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Semester>().HasKey(i => i.ID);
            modelBuilder.Entity<Semester>().HasMany(i => i.Weeks).WithOne(i => i.Semester).HasForeignKey(i => i.SemesterID);

            modelBuilder.Entity<Week>().HasKey(i => i.ID);
            modelBuilder.Entity<Week>().HasMany(i => i.Days).WithOne(i => i.Week).HasForeignKey(i => i.WeekID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Pair>().HasMany(i => i.Days).WithOne(i => i.Pair1).HasForeignKey(i => i.FirstPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days1).WithOne(i => i.Pair2).HasForeignKey(i => i.SecondPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days2).WithOne(i => i.Pair3).HasForeignKey(i => i.ThirdPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days3).WithOne(i => i.Pair4).HasForeignKey(i => i.FourthPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days4).WithOne(i => i.Pair5).HasForeignKey(i => i.FifthPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days5).WithOne(i => i.Pair6).HasForeignKey(i => i.SixthPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days6).WithOne(i => i.Pair7).HasForeignKey(i => i.SeventhPairID).HasPrincipalKey(i => i.PairID);
        }
        public DbSet<Day> Day { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Pair> Pair { get; set; }
        public DbSet<Audience> Audience { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<AudienceType> AudienceType { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Week> Week { get; set; }
    }
}
