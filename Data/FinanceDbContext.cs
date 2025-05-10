using Microsoft.EntityFrameworkCore;
using gp2.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace gp2.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is User user && entry.State == EntityState.Added)
                {
                    user.CreatedAt = DateTime.UtcNow; 
                    
                }
                if (entry.Entity is Transaction transaction && entry.State == EntityState.Added)
                {
                    transaction.TransactionDate = DateTime.UtcNow;

                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }


    }

}
