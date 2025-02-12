using exchangeRateList.Models;
using Microsoft.EntityFrameworkCore;

namespace exchangeRateList.Dat
{
    public class ExchanceDbContext : DbContext
    {
        public ExchanceDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join( path, "ExchangeRateListDatabase.db" );
        }

        public DbSet<Currency> Currency { get; set; }
        public string DbPath { get; }
        protected override void OnConfiguring( DbContextOptionsBuilder options )
                => options.UseSqlite( $"Data Source={DbPath}" );
    }
}
