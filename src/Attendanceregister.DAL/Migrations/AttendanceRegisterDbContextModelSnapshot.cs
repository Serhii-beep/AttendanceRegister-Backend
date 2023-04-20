﻿// <auto-generated />
using System;
using Attendanceregister.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Attendanceregister.DAL.Migrations
{
    [DbContext(typeof(AttendanceRegisterDbContext))]
    partial class AttendanceRegisterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("ClassProfileId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.ClassProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProfileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClassProfiles");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAnnual")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinal")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSemester")
                        .HasColumnType("bit");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectClassId")
                        .HasColumnType("int");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.HasIndex("SubjectClassId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("PupilId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("PupilId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Pupil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(230)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Pupils");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.SubjectClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectClasses");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.TeacherSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSubjects");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Class", b =>
                {
                    b.HasOne("Attendanceregister.DAL.Entities.ClassProfile", "ClassProfile")
                        .WithMany("Classes")
                        .HasForeignKey("ClassProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CN_Classes_ClassProfiles");

                    b.HasOne("Attendanceregister.DAL.Entities.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CN_Classes_Teachers");

                    b.Navigation("ClassProfile");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Lesson", b =>
                {
                    b.HasOne("Attendanceregister.DAL.Entities.Section", "Section")
                        .WithMany("Lessons")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CN_Lessons_Sections");

                    b.HasOne("Attendanceregister.DAL.Entities.SubjectClass", "SubjectClass")
                        .WithMany("Lessons")
                        .HasForeignKey("SubjectClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("CN_Lessons_SubjectClasses");

                    b.Navigation("Section");

                    b.Navigation("SubjectClass");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Mark", b =>
                {
                    b.HasOne("Attendanceregister.DAL.Entities.Lesson", "Lesson")
                        .WithMany("Marks")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("CN_Marks_Lessons");

                    b.HasOne("Attendanceregister.DAL.Entities.Pupil", "Pupil")
                        .WithMany("Marks")
                        .HasForeignKey("PupilId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("CN_Marks_Pupils");

                    b.Navigation("Lesson");

                    b.Navigation("Pupil");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Pupil", b =>
                {
                    b.HasOne("Attendanceregister.DAL.Entities.Class", "Class")
                        .WithMany("Pupils")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("CN_Pupils_Classes");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.SubjectClass", b =>
                {
                    b.HasOne("Attendanceregister.DAL.Entities.Class", "Class")
                        .WithMany("SubjectClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CN_SubjectClasses_Classes");

                    b.HasOne("Attendanceregister.DAL.Entities.Subject", "Subject")
                        .WithMany("SubjectClasses")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CN_SubjectClasses_Subjects");

                    b.Navigation("Class");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.TeacherSubject", b =>
                {
                    b.HasOne("Attendanceregister.DAL.Entities.Subject", "Subject")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CN_TeacherSubjects_Subjects");

                    b.HasOne("Attendanceregister.DAL.Entities.Teacher", "Teacher")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CN_TeacherSubjects_Teachers");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Class", b =>
                {
                    b.Navigation("Pupils");

                    b.Navigation("SubjectClasses");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.ClassProfile", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Lesson", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Pupil", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Section", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Subject", b =>
                {
                    b.Navigation("SubjectClasses");

                    b.Navigation("TeacherSubjects");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.SubjectClass", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Attendanceregister.DAL.Entities.Teacher", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("TeacherSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
