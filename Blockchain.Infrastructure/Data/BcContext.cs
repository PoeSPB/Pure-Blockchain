using Microsoft.EntityFrameworkCore;
using Blockchain.Domain.Model;

namespace Blockchain.Infrastructure.Data
{
    public class BcContext : DbContext
    {
        public BcContext(DbContextOptions<BcContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        public DbSet<Block> Blocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Payload> Payloads { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
