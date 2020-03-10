using Microsoft.EntityFrameworkCore;

namespace InsurancePolicyApplication.Models
{
    public class InsurancePolicyDBContext:DbContext
    {
        public InsurancePolicyDBContext(DbContextOptions<InsurancePolicyDBContext> options):base(options)
        {
        }
        public DbSet<ContentInsurance> ContentInsurances { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
