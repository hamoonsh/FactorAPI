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

            var connString = _config["Data:HospitalConnString"];

            optionsBuilder.UseSqlServer("data source=185.159.152.62;initial catalog=pmwebsit_FactorDB;user id=pmwebsit_FactorDBAdmin;password=bDxc368^;multipleactiveresultsets=True;application name=EntityFramework&quot;");
        }
    }
}
