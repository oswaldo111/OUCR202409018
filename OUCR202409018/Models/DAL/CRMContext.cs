using Microsoft.EntityFrameworkCore;
using OUCR202409018.Models.EN;

namespace OUCR202409018.Models.DAL
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext>options) : base(options) { }

        public DbSet<ProductsOUCR> ProductsOUCR { get; set; }
    }
}
