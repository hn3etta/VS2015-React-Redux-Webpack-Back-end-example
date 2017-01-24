using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BackendStarter.Models;

namespace VS2015backendexample.Migrations
{
    [DbContext(typeof(BackendStarterContext))]
    partial class BackendStarterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackendStarter.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BackendStarter.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("WatchHref")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("BackendStarter.Models.OpenCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Attendees");

                    b.Property<int>("CourseId");

                    b.Property<int>("MaxAttendees");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("OpenCourses");
                });

            modelBuilder.Entity("BackendStarter.Models.Course", b =>
                {
                    b.HasOne("BackendStarter.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackendStarter.Models.OpenCourse", b =>
                {
                    b.HasOne("BackendStarter.Models.Course")
                        .WithOne("OpenCourse")
                        .HasForeignKey("BackendStarter.Models.OpenCourse", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
