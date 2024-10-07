﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIMYTSoacha.Context;

#nullable disable

namespace SIMYTSoacha.Migrations
{
    [DbContext(typeof(SimytDbContext))]
    partial class SimytDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SIMYTSoacha.Model.Brands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Colors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Contacts", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<int>("TcontactId")
                        .HasColumnType("int");

                    b.HasKey("ContactId");

                    b.HasIndex("PeopleId");

                    b.HasIndex("TcontactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.DocumentsTypes", b =>
                {
                    b.Property<int>("DtypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DtypesId"));

                    b.Property<string>("Dtype")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("DtypesId");

                    b.ToTable("DocumentsTypes");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.DriverLicenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateIssue")
                        .HasColumnType("datetime2");

                    b.Property<int>("EcenterId")
                        .HasColumnType("int");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Nlicense")
                        .HasColumnType("int");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("RestrictionId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EcenterId");

                    b.HasIndex("ProcedureId");

                    b.HasIndex("RestrictionId");

                    b.HasIndex("StateId");

                    b.ToTable("DriverLicenses");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Ecenters", b =>
                {
                    b.Property<int>("EcenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EcenterId"));

                    b.Property<string>("Ecenter")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("EcenterId");

                    b.ToTable("ExpeditionsCenters");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Fines", b =>
                {
                    b.Property<int>("FinesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FinesId"));

                    b.Property<int>("InfractionId")
                        .HasColumnType("int");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MimpositionId")
                        .HasColumnType("int");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.HasKey("FinesId");

                    b.HasIndex("InfractionId");

                    b.HasIndex("MimpositionId");

                    b.HasIndex("ProcedureId");

                    b.ToTable("Fines");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Histories", b =>
                {
                    b.Property<int>("HistorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistorieId"));

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DtypeId")
                        .HasColumnType("int");

                    b.Property<string>("Fnames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifyBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ndocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtypeId")
                        .HasColumnType("int");

                    b.HasKey("HistorieId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Infractions", b =>
                {
                    b.Property<int>("InfractionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InfractionId"));

                    b.Property<string>("InfractionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("InfractionId");

                    b.ToTable("Infractions");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Levels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.LevelsxMatches", b =>
                {
                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LevelsId")
                        .HasColumnType("int");

                    b.Property<int>("MatchsPeopleId")
                        .HasColumnType("int");

                    b.Property<int>("Scored")
                        .HasColumnType("int");

                    b.HasKey("LevelId", "MatchId");

                    b.HasIndex("LevelsId");

                    b.HasIndex("MatchsPeopleId");

                    b.ToTable("LevelsxMatches");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Lines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Matches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeopleId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Mimpositions", b =>
                {
                    b.Property<int>("MimpositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MimpositionId"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MimpositionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MimpositionId");

                    b.ToTable("Mimpositions");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.ModelXLine", b =>
                {
                    b.Property<int>("LineNumberId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("LineNumberId", "ModelId");

                    b.HasIndex("ModelId");

                    b.ToTable("ModelXLine");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Models", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NModel")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.People", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeopleId"));

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DtypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lnames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ndocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passcodes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("PeopleId");

                    b.HasIndex("DtypeId");

                    b.HasIndex("SexId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("People");

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Permissions", b =>
                {
                    b.Property<int>("Pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pid"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Pid");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Procedures", b =>
                {
                    b.Property<int>("ProcedureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcedureId"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Procedure")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("ProcedureId");

                    b.HasIndex("RequestId");

                    b.HasIndex("StateId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Requests", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OfficerId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Request")
                        .HasColumnType("datetime2");

                    b.HasKey("RequestId");

                    b.HasIndex("OfficerId");

                    b.HasIndex("PeopleId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Restrictions", b =>
                {
                    b.Property<int>("RestrictionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestrictionId"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RestrictionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RestrictionId");

                    b.ToTable("Restrictions");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Sex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PreferredSex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sex");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.States", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("StatesName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.TrafficLicenses", b =>
                {
                    b.Property<int>("TlicensesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TlicensesId"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("TserviceId")
                        .HasColumnType("int");

                    b.Property<int>("TvehicleId")
                        .HasColumnType("int");

                    b.Property<int>("VstatesId")
                        .HasColumnType("int");

                    b.HasKey("TlicensesId");

                    b.HasIndex("ProcedureId");

                    b.HasIndex("TserviceId");

                    b.HasIndex("TvehicleId");

                    b.HasIndex("VstatesId");

                    b.ToTable("TrafficLicenses");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.TypesContacts", b =>
                {
                    b.Property<int>("TcontactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TcontactId"));

                    b.Property<string>("Dtype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("TcontactId");

                    b.ToTable("TypesContacts");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.TypesServices", b =>
                {
                    b.Property<int>("TservicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TservicesId"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TservicesName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TservicesId");

                    b.ToTable("TypesServices");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.TypesVehicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Tvehicle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesVehicles");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.UsersTypes", b =>
                {
                    b.Property<int>("UtypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UtypesId"));

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UtypesName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UtypesId");

                    b.ToTable("UsersTypes");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.UsersXPermissions", b =>
                {
                    b.Property<int>("UtypeId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("UtypeId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UsersXPermissions");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Vehicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Echasis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MlineId")
                        .HasColumnType("int");

                    b.Property<string>("Nmotor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ColorId");

                    b.HasIndex("MlineId");

                    b.HasIndex("PeopleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Contacts", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.TypesContacts", "TypesContacts")
                        .WithMany()
                        .HasForeignKey("TcontactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");

                    b.Navigation("TypesContacts");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.DriverLicenses", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Ecenters", "Ecenters")
                        .WithMany()
                        .HasForeignKey("EcenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Procedures", "Procedures")
                        .WithMany()
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Restrictions", "Restrictions")
                        .WithMany()
                        .HasForeignKey("RestrictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.States", "States")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ecenters");

                    b.Navigation("Procedures");

                    b.Navigation("Restrictions");

                    b.Navigation("States");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Fines", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Infractions", "Infractions")
                        .WithMany()
                        .HasForeignKey("InfractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Mimpositions", "Mimpositions")
                        .WithMany()
                        .HasForeignKey("MimpositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Procedures", "Procedures")
                        .WithMany()
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infractions");

                    b.Navigation("Mimpositions");

                    b.Navigation("Procedures");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.LevelsxMatches", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Levels", "Levels")
                        .WithMany()
                        .HasForeignKey("LevelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.People", "Matchs")
                        .WithMany()
                        .HasForeignKey("MatchsPeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Levels");

                    b.Navigation("Matchs");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Matches", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.ModelXLine", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Lines", "Line")
                        .WithMany()
                        .HasForeignKey("LineNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Models", "Models")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.People", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.DocumentsTypes", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DtypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.UsersTypes", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("Sex");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Procedures", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Requests", "Requests")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.States", "States")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requests");

                    b.Navigation("States");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Requests", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.People", "Officer")
                        .WithMany()
                        .HasForeignKey("OfficerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Officer");

                    b.Navigation("People");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.TrafficLicenses", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Procedures", "Procedures")
                        .WithMany()
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.TypesServices", "Services")
                        .WithMany()
                        .HasForeignKey("TserviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.TypesVehicles", "Vehicles")
                        .WithMany()
                        .HasForeignKey("TvehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.States", "States")
                        .WithMany()
                        .HasForeignKey("VstatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Procedures");

                    b.Navigation("Services");

                    b.Navigation("States");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.UsersXPermissions", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Permissions", "Permissions")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.UsersTypes", "UsersType")
                        .WithMany()
                        .HasForeignKey("UtypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permissions");

                    b.Navigation("UsersType");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Vehicles", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Brands", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Colors", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Models", "Models")
                        .WithMany()
                        .HasForeignKey("MlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Color");

                    b.Navigation("Models");

                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
