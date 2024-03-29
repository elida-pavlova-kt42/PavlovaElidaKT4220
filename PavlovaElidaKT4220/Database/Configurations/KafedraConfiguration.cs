﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PavlovaElidaKT4220.Database.Helpers;
using PavlovaElidaKT4220.Models;

namespace PavlovaElidaKT4220.Database.Configurations
{
    public class KafedraConfiguration : IEntityTypeConfiguration<Kafedra>
    {
        private const string TableName = "cd_kafedra";

        public void Configure(EntityTypeBuilder<Kafedra> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.KafedraId)
                .HasName($"pk_{TableName}_kafedra_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.KafedraId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.KafedraId)
                .HasColumnName("kafedra_id")
                .HasComment("Идентификатор записи кафедры");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.KafedraName)
                .IsRequired()
                .HasColumnName("c_kafedra_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название кафедры");

            builder.ToTable(TableName);
        }
    
}
}
