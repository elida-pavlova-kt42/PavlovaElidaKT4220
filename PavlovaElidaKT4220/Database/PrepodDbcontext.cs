using Microsoft.EntityFrameworkCore;
using PavlovaElidaKT4220.Database.Configurations;
using PavlovaElidaKT4220.Models;
using System.Text.RegularExpressions;

namespace PavlovaElidaKT4220.Database
{
    public class PrepodDbcontext : DbContext
    {
        //Добавляем таблицы
        DbSet<Kafedra> Kafedra { get; set; }
        DbSet<Prepod> Prepod { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
        }
        public PrepodDbcontext(DbContextOptions<PrepodDbcontext> options) : base(options)
        {
        }
    }
}
