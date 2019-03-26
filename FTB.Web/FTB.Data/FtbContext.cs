using FTB.Models;
using Microsoft.EntityFrameworkCore;

namespace FTB.Data
{
    public class FtbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;DataBase=FTB;Integrated Security=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
