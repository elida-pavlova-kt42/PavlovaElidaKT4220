﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PavlovaElidaKT4220.Database;

#nullable disable

namespace PavlovaElidaKT4220.Migrations
{
    [DbContext(typeof(PrepodDbcontext))]
    [Migration("20231031110504_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PavlovaElidaKT4220.Models.Kafedra", b =>
                {
                    b.Property<int>("KafedraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("kafedra_id")
                        .HasComment("Идентификатор записи кафедры");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KafedraId"));

                    b.Property<string>("KafedraName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_kafedra_name")
                        .HasComment("Название кафедры");

                    b.HasKey("KafedraId")
                        .HasName("pk_cd_kafedra_kafedra_id");

                    b.ToTable("cd_kafedra", (string)null);
                });

            modelBuilder.Entity("PavlovaElidaKT4220.Models.Prepod", b =>
                {
                    b.Property<int>("PrepodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("prepod_id")
                        .HasComment("Индетификатор записи преподавателя");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrepodId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<int>("KafedraId")
                        .HasColumnType("int")
                        .HasColumnName("kafedra_id")
                        .HasComment("Индетификатор кафедры");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_lastname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_middlename")
                        .HasComment("Отчество преподавателя");

                    b.HasKey("PrepodId")
                        .HasName("pk_cd_prepod_prepod_id");

                    b.HasIndex(new[] { "KafedraId" }, "idx_cd_prepod_fk_f_kafedra_id");

                    b.ToTable("cd_prepod", (string)null);
                });

            modelBuilder.Entity("PavlovaElidaKT4220.Models.Prepod", b =>
                {
                    b.HasOne("PavlovaElidaKT4220.Models.Kafedra", "Kafedra")
                        .WithMany()
                        .HasForeignKey("KafedraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_kafedra_id");

                    b.Navigation("Kafedra");
                });
#pragma warning restore 612, 618
        }
    }
}
