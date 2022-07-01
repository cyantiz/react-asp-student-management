﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220605083455_addSemesterColumn")]
    partial class addSemesterColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.DatabaseModels.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.Classroom", b =>
                {
                    b.Property<string>("ClassroomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AcademicYear")
                        .HasColumnType("int");

                    b.Property<string>("EducationalProgramId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FacultyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassroomId");

                    b.HasIndex("EducationalProgramId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.Course", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("requiredCourseId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.CourseClassroom", b =>
                {
                    b.Property<string>("CourseClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseClassId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseClassroom");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.CourseEducationProgram", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EducationalProgramId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "EducationalProgramId");

                    b.HasIndex("EducationalProgramId");

                    b.ToTable("CourseEducationProgram");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.EducationalProgram", b =>
                {
                    b.Property<string>("EducationalProgramId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EducationalProgramId");

                    b.ToTable("EducationalProgram");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.Faculty", b =>
                {
                    b.Property<string>("FacultyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseClassroomId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ExcerciseRate")
                        .HasColumnType("float");

                    b.Property<double>("ExcerciseScore")
                        .HasColumnType("float");

                    b.Property<double>("FinalTermRate")
                        .HasColumnType("float");

                    b.Property<double>("FinalTermScore")
                        .HasColumnType("float");

                    b.Property<double>("MidTermRate")
                        .HasColumnType("float");

                    b.Property<double>("MidTermScore")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CourseClassroomId");

                    b.HasIndex("UserId");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassroomId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Dob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("ClassroomId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.UserCourseClassroom", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseClassroomId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "CourseClassroomId");

                    b.HasIndex("CourseClassroomId");

                    b.ToTable("UserCourseClassroom");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.Account", b =>
                {
                    b.HasOne("API.Models.DatabaseModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.Classroom", b =>
                {
                    b.HasOne("API.Models.DatabaseModels.EducationalProgram", "EducationalProgram")
                        .WithMany()
                        .HasForeignKey("EducationalProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.DatabaseModels.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EducationalProgram");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.CourseClassroom", b =>
                {
                    b.HasOne("API.Models.DatabaseModels.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.CourseEducationProgram", b =>
                {
                    b.HasOne("API.Models.DatabaseModels.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.DatabaseModels.EducationalProgram", "EducationalProgram")
                        .WithMany()
                        .HasForeignKey("EducationalProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("EducationalProgram");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.Score", b =>
                {
                    b.HasOne("API.Models.DatabaseModels.CourseClassroom", "CourseClassroom")
                        .WithMany()
                        .HasForeignKey("CourseClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.DatabaseModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClassroom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.User", b =>
                {
                    b.HasOne("API.Models.DatabaseModels.Classroom", "Classroom")
                        .WithMany("Students")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.UserCourseClassroom", b =>
                {
                    b.HasOne("API.Models.DatabaseModels.CourseClassroom", "CourseClassroom")
                        .WithMany()
                        .HasForeignKey("CourseClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.DatabaseModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClassroom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.DatabaseModels.Classroom", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
