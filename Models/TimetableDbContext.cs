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
            modelBuilder.Entity<AudienceType>().HasKey(i => i.ID);
            modelBuilder.Entity<AudienceType>().HasMany(i => i.Rooms).WithOne(i => i.AudienceType).HasForeignKey(i => i.AudienceTypeID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Audience>().HasKey(i => i.ID);
            modelBuilder.Entity<Audience>().HasMany(i => i.Pairs).WithOne(i => i.Audience).HasForeignKey(i => i.AudienceID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Group>().HasKey(i => i.ID);
            modelBuilder.Entity<Group>().HasMany(i => i.Pairs).WithOne(i => i.Group).HasForeignKey(i => i.GroupID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Teacher>().HasKey(i => i.ID);
            modelBuilder.Entity<Teacher>().HasMany(i => i.Pairs).WithOne(i => i.Teacher).HasForeignKey(i => i.TeacherID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Subject>().HasKey(i => i.ID);
            modelBuilder.Entity<Subject>().HasMany(i => i.Pairs).WithOne(i => i.Subject).HasForeignKey(i => i.SubjectID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Semester>().HasKey(i => i.ID);
            modelBuilder.Entity<Semester>().HasMany(i => i.Weeks).WithOne(i => i.Semester).HasForeignKey(i => i.SemesterID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Week>().HasKey(i => i.ID);
            modelBuilder.Entity<Week>().HasMany(i => i.Days).WithOne(i => i.Week).HasForeignKey(i => i.WeekID).HasPrincipalKey(i => i.ID);

            modelBuilder.Entity<Pair>().HasKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days).WithOne(i => i.Pair1).HasForeignKey(i => i.FirstPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days1).WithOne(i => i.Pair2).HasForeignKey(i => i.SecondPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days2).WithOne(i => i.Pair3).HasForeignKey(i => i.ThirdPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days3).WithOne(i => i.Pair4).HasForeignKey(i => i.FourthPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days4).WithOne(i => i.Pair5).HasForeignKey(i => i.FifthPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days5).WithOne(i => i.Pair6).HasForeignKey(i => i.SixthPairID).HasPrincipalKey(i => i.PairID);
            modelBuilder.Entity<Pair>().HasMany(i => i.Days6).WithOne(i => i.Pair7).HasForeignKey(i => i.SeventhPairID).HasPrincipalKey(i => i.PairID);

            modelBuilder.Entity<Day>().HasKey(i => i.ID);
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
