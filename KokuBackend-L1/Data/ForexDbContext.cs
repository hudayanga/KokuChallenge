using System;
using KokuBackend.Business;
using KokuBackend_L1.Business;
using Microsoft.EntityFrameworkCore;

namespace KokuBackend_L1.Data
{
    public class ForexDbContext :  DbContext
    {
        private const string connectionString = "Server=tcp:hudayanga.database.windows.net,1433;Initial Catalog=Forex;Persist Security Info=False;User ID=hudayanga;Password=1qaz2wsx@V;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<RateL2> L2Rates { get; set; }

        public DbSet<RateL3> L3Rates { get; set; }
    }
}
