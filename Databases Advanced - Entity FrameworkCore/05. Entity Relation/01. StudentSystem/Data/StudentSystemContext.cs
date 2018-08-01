using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public StudentSystemContext()
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    //.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(e =>
            {
                e.HasKey(pk => new { pk.StudentId, pk.CourseId });

                e.HasOne(s => s.Student)
                .WithMany(sc => sc.CourseEnrollments)
                .HasForeignKey(s => s.StudentId);

                e.HasOne(c => c.Course)
                .WithMany(sc => sc.StudentsEnrolled)
                .HasForeignKey(c => c.CourseId);
            });

            modelBuilder.Entity<Student>(e =>
            {
                e.Property(n => n.Name).HasMaxLength(100).IsUnicode().IsRequired();
                e.Property(pn => pn.PhoneNumber).IsRequired(false).IsUnicode(false).HasColumnType("CHAR(10)");
                e.Property(r => r.RegisteredOn).IsRequired();
                e.Property(bt => bt.Birthday).IsRequired(false);
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.Property(n => n.Name).HasMaxLength(80).IsUnicode().IsRequired();
                e.Property(d => d.Description).IsRequired(false).IsUnicode();
                e.Property(sd => sd.StartDate).IsRequired();
                e.Property(ed => ed.EndDate).IsRequired();
                e.Property(p => p.Price).IsRequired();
            });

            modelBuilder.Entity<Resource>(e =>
            {
                e.Property(n => n.Name).HasMaxLength(50).IsUnicode().IsRequired();
                e.Property(u => u.Url).IsRequired().IsUnicode(false);

                e.Property(rt => rt.ResourceType).IsRequired();

                e.HasOne(c => c.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(c => c.CourseId);
            });

            modelBuilder.Entity<Homework>(e =>
            {
                e.Property(c => c.Content).IsUnicode(false).IsRequired();

                e.Property(s => s.SubmissionTime).IsRequired();

                e.Property(ct => ct.ContentType).IsRequired();

                e.HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);

                e.HasOne(s => s.Student)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(s => s.StudentId);
            });
        }
    }
}
