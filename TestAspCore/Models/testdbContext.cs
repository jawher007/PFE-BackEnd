using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestAspCore.Models
{
    public partial class testdbContext : DbContext
    {
        public testdbContext()
        {
        }

        public testdbContext(DbContextOptions<testdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionVideo> SessionVideos { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestVideo> TestVideos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7SMRL6G;Initial Catalog=testdb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedbacks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Feedback1)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("feedback");

                entity.Property(e => e.Localization)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("localization");

                entity.Property(e => e.Userfeedback)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("userfeedback");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idtest)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idtest");

                entity.Property(e => e.Issuetext)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("issuetext");

                entity.Property(e => e.Tester)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tester");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.Browsername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("browsername");

                entity.Property(e => e.Browserversion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("browserversion");

                entity.Property(e => e.Cap1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap1");

                entity.Property(e => e.Cap10)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap10");

                entity.Property(e => e.Cap2)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap2");

                entity.Property(e => e.Cap3)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap3");

                entity.Property(e => e.Cap4)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap4");

                entity.Property(e => e.Cap5)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap5");

                entity.Property(e => e.Cap6)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap6");

                entity.Property(e => e.Cap7)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap7");

                entity.Property(e => e.Cap8)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap8");

                entity.Property(e => e.Cap9)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap9");

                entity.Property(e => e.Durationmin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durationmin");

                entity.Property(e => e.Durationsec)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durationsec");

                entity.Property(e => e.Os)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("os");

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");

                entity.Property(e => e.Sessiontitle)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("sessiontitle");

                entity.Property(e => e.StartedAt)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("startedAt");

                entity.Property(e => e.Testcount)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("testcount");

                entity.Property(e => e.Testfailed)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("testfailed");

                entity.Property(e => e.Testpassed)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("testpassed");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<SessionVideo>(entity =>
            {
                entity.ToTable("SessionVideo");

                entity.Property(e => e.Browsername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("browsername");

                entity.Property(e => e.Browserversion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("browserversion");

                entity.Property(e => e.Cap1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap1");

                entity.Property(e => e.Cap10)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap10");

                entity.Property(e => e.Cap2)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap2");

                entity.Property(e => e.Cap3)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap3");

                entity.Property(e => e.Cap4)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap4");

                entity.Property(e => e.Cap5)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap5");

                entity.Property(e => e.Cap6)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap6");

                entity.Property(e => e.Cap7)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap7");

                entity.Property(e => e.Cap8)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap8");

                entity.Property(e => e.Cap9)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cap9");

                entity.Property(e => e.Durationmin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durationmin");

                entity.Property(e => e.Durationsec)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durationsec");

                entity.Property(e => e.Os)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("os");

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");

                entity.Property(e => e.Sessiontitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sessiontitle");

                entity.Property(e => e.StartedAt)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("startedAt");

                entity.Property(e => e.Testcount)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("testcount");

                entity.Property(e => e.Testfailed)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("testfailed");

                entity.Property(e => e.Testpassed)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("testpassed");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Test");

                entity.Property(e => e.Durationmin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("durationmin");

                entity.Property(e => e.Durationsec)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("durationsec");

                entity.Property(e => e.Erreur)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("erreur");

                entity.Property(e => e.Screen1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen1");

                entity.Property(e => e.Screen10)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen10");

                entity.Property(e => e.Screen11)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen11");

                entity.Property(e => e.Screen12)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen12");

                entity.Property(e => e.Screen13)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen13");

                entity.Property(e => e.Screen14)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen14");

                entity.Property(e => e.Screen15)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen15");

                entity.Property(e => e.Screen16)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen16");

                entity.Property(e => e.Screen17)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen17");

                entity.Property(e => e.Screen18)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen18");

                entity.Property(e => e.Screen19)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen19");

                entity.Property(e => e.Screen2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen2");

                entity.Property(e => e.Screen20)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen20");

                entity.Property(e => e.Screen21)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen21");

                entity.Property(e => e.Screen22)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen22");

                entity.Property(e => e.Screen3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen3");

                entity.Property(e => e.Screen4)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen4");

                entity.Property(e => e.Screen5)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen5");

                entity.Property(e => e.Screen6)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen6");

                entity.Property(e => e.Screen7)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen7");

                entity.Property(e => e.Screen8)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen8");

                entity.Property(e => e.Screen9)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen9");

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");

                entity.Property(e => e.StartedAt)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("startedAt");

                entity.Property(e => e.Step1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step1");

                entity.Property(e => e.Step10)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step10");

                entity.Property(e => e.Step11)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step11");

                entity.Property(e => e.Step12)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step12");

                entity.Property(e => e.Step13)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step13");

                entity.Property(e => e.Step14)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step14");

                entity.Property(e => e.Step15)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step15");

                entity.Property(e => e.Step16)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step16");

                entity.Property(e => e.Step17)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step17");

                entity.Property(e => e.Step18)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step18");

                entity.Property(e => e.Step19)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step19");

                entity.Property(e => e.Step2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step2");

                entity.Property(e => e.Step20)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step20");

                entity.Property(e => e.Step21)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step21");

                entity.Property(e => e.Step22)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step22");

                entity.Property(e => e.Step3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step3");

                entity.Property(e => e.Step4)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step4");

                entity.Property(e => e.Step5)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step5");

                entity.Property(e => e.Step6)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step6");

                entity.Property(e => e.Step7)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step7");

                entity.Property(e => e.Step8)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step8");

                entity.Property(e => e.Step9)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step9");

                entity.Property(e => e.Testname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("testname");

                entity.Property(e => e.Testrank)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("testrank");

                entity.Property(e => e.Teststatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teststatus");

                entity.Property(e => e.Time1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time1");

                entity.Property(e => e.Time10)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time10");

                entity.Property(e => e.Time11)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time11");

                entity.Property(e => e.Time12)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time12");

                entity.Property(e => e.Time13)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time13");

                entity.Property(e => e.Time14)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time14");

                entity.Property(e => e.Time15)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time15");

                entity.Property(e => e.Time16)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time16");

                entity.Property(e => e.Time17)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time17");

                entity.Property(e => e.Time18)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time18");

                entity.Property(e => e.Time19)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time19");

                entity.Property(e => e.Time2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time2");

                entity.Property(e => e.Time20)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time20");

                entity.Property(e => e.Time21)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time21");

                entity.Property(e => e.Time22)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time22");

                entity.Property(e => e.Time3)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time3");

                entity.Property(e => e.Time4)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time4");

                entity.Property(e => e.Time5)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time5");

                entity.Property(e => e.Time6)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time6");

                entity.Property(e => e.Time7)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time7");

                entity.Property(e => e.Time8)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time8");

                entity.Property(e => e.Time9)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time9");
            });

            modelBuilder.Entity<TestVideo>(entity =>
            {
                entity.ToTable("TestVideo");

                entity.Property(e => e.Durationmin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durationmin");

                entity.Property(e => e.Durationsec)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durationsec");

                entity.Property(e => e.Erreur)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("erreur");

                entity.Property(e => e.Screen1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen1");

                entity.Property(e => e.Screen10)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen10");

                entity.Property(e => e.Screen11)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen11");

                entity.Property(e => e.Screen12)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen12");

                entity.Property(e => e.Screen13)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen13");

                entity.Property(e => e.Screen14)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen14");

                entity.Property(e => e.Screen15)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen15");

                entity.Property(e => e.Screen16)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen16");

                entity.Property(e => e.Screen17)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen17");

                entity.Property(e => e.Screen18)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen18");

                entity.Property(e => e.Screen19)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen19");

                entity.Property(e => e.Screen2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen2");

                entity.Property(e => e.Screen20)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen20");

                entity.Property(e => e.Screen21)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen21");

                entity.Property(e => e.Screen22)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen22");

                entity.Property(e => e.Screen3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen3");

                entity.Property(e => e.Screen4)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen4");

                entity.Property(e => e.Screen5)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen5");

                entity.Property(e => e.Screen6)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen6");

                entity.Property(e => e.Screen7)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen7");

                entity.Property(e => e.Screen8)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen8");

                entity.Property(e => e.Screen9)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("screen9");

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");

                entity.Property(e => e.StartedAt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("startedAt");

                entity.Property(e => e.Step1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step1");

                entity.Property(e => e.Step10)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step10");

                entity.Property(e => e.Step11)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step11");

                entity.Property(e => e.Step12)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step12");

                entity.Property(e => e.Step13)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step13");

                entity.Property(e => e.Step14)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step14");

                entity.Property(e => e.Step15)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step15");

                entity.Property(e => e.Step16)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step16");

                entity.Property(e => e.Step17)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step17");

                entity.Property(e => e.Step18)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step18");

                entity.Property(e => e.Step19)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step19");

                entity.Property(e => e.Step2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step2");

                entity.Property(e => e.Step20)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step20");

                entity.Property(e => e.Step21)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step21");

                entity.Property(e => e.Step22)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step22");

                entity.Property(e => e.Step3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step3");

                entity.Property(e => e.Step4)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step4");

                entity.Property(e => e.Step5)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step5");

                entity.Property(e => e.Step6)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step6");

                entity.Property(e => e.Step7)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step7");

                entity.Property(e => e.Step8)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step8");

                entity.Property(e => e.Step9)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("step9");

                entity.Property(e => e.Testname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("testname");

                entity.Property(e => e.Testrank)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("testrank");

                entity.Property(e => e.Teststatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teststatus");

                entity.Property(e => e.Time1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time1");

                entity.Property(e => e.Time10)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time10");

                entity.Property(e => e.Time11)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time11");

                entity.Property(e => e.Time12)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time12");

                entity.Property(e => e.Time13)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time13");

                entity.Property(e => e.Time14)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time14");

                entity.Property(e => e.Time15)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time15");

                entity.Property(e => e.Time16)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time16");

                entity.Property(e => e.Time17)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time17");

                entity.Property(e => e.Time18)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time18");

                entity.Property(e => e.Time19)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time19");

                entity.Property(e => e.Time2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time2");

                entity.Property(e => e.Time20)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time20");

                entity.Property(e => e.Time21)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time21");

                entity.Property(e => e.Time22)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time22");

                entity.Property(e => e.Time3)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time3");

                entity.Property(e => e.Time4)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time4");

                entity.Property(e => e.Time5)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time5");

                entity.Property(e => e.Time6)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time6");

                entity.Property(e => e.Time7)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time7");

                entity.Property(e => e.Time8)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time8");

                entity.Property(e => e.Time9)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time9");

                entity.Property(e => e.Videolink)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("videolink");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
