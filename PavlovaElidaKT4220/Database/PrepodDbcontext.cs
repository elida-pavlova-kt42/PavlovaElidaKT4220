using Microsoft.EntityFrameworkCore;
using PavlovaElidaKT4220.Database.Configurations;
using PavlovaElidaKT4220.Models;
using System.Text.RegularExpressions;

namespace PavlovaElidaKT4220.Database
{
    public class PrepodDbcontext : DbContext
    {
        //Добавляем таблицы
        public DbSet<Kafedra> Kafedra { get; set; }
         public DbSet<Prepod> Prepod { get; set; }
        public DbSet<Stepen> Stepen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
            modelBuilder.ApplyConfiguration(new StepenConfiguration());
        }
        public PrepodDbcontext(DbContextOptions<PrepodDbcontext> options) : base(options)
        {
        }
    }
}
