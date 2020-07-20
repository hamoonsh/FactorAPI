using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FactorAPI.Models.Entities
{
    public class FactorDBContext : DbContext
    {
        private IConfiguration _config;
        public FactorDBContext(IConfiguration config) : base()
        {
            _config = config;
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config.GetConnectionString("FactorDB"));
        }
    }
}
