﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIMYTSoacha.Context;

#nullable disable

namespace SIMYTSoacha.Migrations
{
    [DbContext(typeof(SimytDbContext))]
    [Migration("20240909192343_configDb")]
    partial class configDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<int>("TcontactId")
                        .HasColumnType("int");

                    b.Property<int>("TypesContactsTcontactId")
                        .HasColumnType("int");

                    b.HasKey("ContactId");

                    b.HasIndex("PeopleId");

                    b.HasIndex("TypesContactsTcontactId");

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

                    b.HasKey("DtypesId");

                    b.ToTable("DocumentsTypes");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.DriverLicenses", b =>
                {
                    b.Property<int>("DriverLicenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverLicenseId"));

                    b.Property<DateTime>("DateIssue")
                        .HasColumnType("datetime2");

                    b.Property<int>("EcenterId")
                        .HasColumnType("int");

                    b.Property<int>("EcentersEcenterId")
                        .HasColumnType("int");

                    b.Property<int>("Nlicense")
                        .HasColumnType("int");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("ProceduresProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("RestrictionId")
                        .HasColumnType("int");

                    b.Property<int>("RestrictionsRestrictionId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("StatesStateId")
                        .HasColumnType("int");

                    b.HasKey("DriverLicenseId");

                    b.HasIndex("EcentersEcenterId");

                    b.HasIndex("ProceduresProcedureId");

                    b.HasIndex("RestrictionsRestrictionId");

                    b.HasIndex("StatesStateId");

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

                    b.Property<int>("InfractionsInfractionId")
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("ManagersId")
                        .HasColumnType("int");

                    b.Property<int>("MimpositionId")
                        .HasColumnType("int");

                    b.Property<int>("MimpositionsMimpositionId")
                        .HasColumnType("int");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("ProceduresProcedureId")
                        .HasColumnType("int");

                    b.HasKey("FinesId");

                    b.HasIndex("InfractionsInfractionId");

                    b.HasIndex("ManagersId");

                    b.HasIndex("MimpositionsMimpositionId");

                    b.HasIndex("ProceduresProcedureId");

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

                    b.Property<string>("Lname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

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

                    b.HasKey("InfractionId");

                    b.ToTable("Infractions");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Managers", b =>
                {
                    b.Property<int>("ManagersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagersId"));

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeXPermission")
                        .HasColumnType("int");

                    b.Property<int>("UsersXPermissionsUpermissionId")
                        .HasColumnType("int");

                    b.HasKey("ManagersId");

                    b.HasIndex("PeopleId");

                    b.HasIndex("UsersXPermissionsUpermissionId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Mimpositions", b =>
                {
                    b.Property<int>("MimpositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MimpositionId"));

                    b.Property<string>("MimpositionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MimpositionId");

                    b.ToTable("Mimpositions");
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

                    b.Property<string>("Lnames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ndocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeXPermission")
                        .HasColumnType("int");

                    b.HasKey("PeopleId");

                    b.HasIndex("DtypeId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Permissions", b =>
                {
                    b.Property<int>("Pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pid"));

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

                    b.Property<int>("Procedure")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("RequestsRequestId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("StatesStateId")
                        .HasColumnType("int");

                    b.HasKey("ProcedureId");

                    b.HasIndex("RequestsRequestId");

                    b.HasIndex("StatesStateId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Requests", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("ManagersId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Request")
                        .HasColumnType("datetime2");

                    b.HasKey("RequestId");

                    b.HasIndex("ManagersId");

                    b.HasIndex("PeopleId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Restrictions", b =>
                {
                    b.Property<int>("RestrictionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestrictionId"));

                    b.Property<string>("RestrictionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RestrictionId");

                    b.ToTable("Restrictions");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.States", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

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

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("ProceduresProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesTservicesId")
                        .HasColumnType("int");

                    b.Property<int>("StatesStateId")
                        .HasColumnType("int");

                    b.Property<int>("TserviceId")
                        .HasColumnType("int");

                    b.Property<int>("TvehicleId")
                        .HasColumnType("int");

                    b.Property<int>("VstatesId")
                        .HasColumnType("int");

                    b.HasKey("TlicensesId");

                    b.HasIndex("ProceduresProcedureId");

                    b.HasIndex("ServicesTservicesId");

                    b.HasIndex("StatesStateId");

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

                    b.HasKey("TcontactId");

                    b.ToTable("TypesContacts");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.TypesServices", b =>
                {
                    b.Property<int>("TservicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TservicesId"));

                    b.Property<string>("TservicesName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TservicesId");

                    b.ToTable("TypesServices");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.UsersTypes", b =>
                {
                    b.Property<int>("UtypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UtypesId"));

                    b.Property<string>("UtypesName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UtypesId");

                    b.ToTable("UsersTypes");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.UsersXPermissions", b =>
                {
                    b.Property<int>("UpermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UpermissionId"));

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("UtypeId")
                        .HasColumnType("int");

                    b.HasKey("UpermissionId");

                    b.HasIndex("Permission");

                    b.HasIndex("UtypeId");

                    b.ToTable("UsersXPermissions");
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
                        .HasForeignKey("TypesContactsTcontactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");

                    b.Navigation("TypesContacts");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.DriverLicenses", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Ecenters", "Ecenters")
                        .WithMany()
                        .HasForeignKey("EcentersEcenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Procedures", "Procedures")
                        .WithMany()
                        .HasForeignKey("ProceduresProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Restrictions", "Restrictions")
                        .WithMany()
                        .HasForeignKey("RestrictionsRestrictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.States", "States")
                        .WithMany()
                        .HasForeignKey("StatesStateId")
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
                        .HasForeignKey("InfractionsInfractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Managers", "Managers")
                        .WithMany()
                        .HasForeignKey("ManagersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Mimpositions", "Mimpositions")
                        .WithMany()
                        .HasForeignKey("MimpositionsMimpositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.Procedures", "Procedures")
                        .WithMany()
                        .HasForeignKey("ProceduresProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infractions");

                    b.Navigation("Managers");

                    b.Navigation("Mimpositions");

                    b.Navigation("Procedures");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Managers", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.UsersXPermissions", "UsersXPermissions")
                        .WithMany()
                        .HasForeignKey("UsersXPermissionsUpermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");

                    b.Navigation("UsersXPermissions");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.People", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.DocumentsTypes", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DtypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Procedures", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Requests", "Requests")
                        .WithMany()
                        .HasForeignKey("RequestsRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.States", "States")
                        .WithMany()
                        .HasForeignKey("StatesStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requests");

                    b.Navigation("States");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.Requests", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Managers", "Managers")
                        .WithMany()
                        .HasForeignKey("ManagersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Managers");

                    b.Navigation("People");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.TrafficLicenses", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Procedures", "Procedures")
                        .WithMany()
                        .HasForeignKey("ProceduresProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.TypesServices", "Services")
                        .WithMany()
                        .HasForeignKey("ServicesTservicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMYTSoacha.Model.States", "States")
                        .WithMany()
                        .HasForeignKey("StatesStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Procedures");

                    b.Navigation("Services");

                    b.Navigation("States");
                });

            modelBuilder.Entity("SIMYTSoacha.Model.UsersXPermissions", b =>
                {
                    b.HasOne("SIMYTSoacha.Model.Permissions", "Permissions")
                        .WithMany()
                        .HasForeignKey("Permission")
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
#pragma warning restore 612, 618
        }
    }
}
