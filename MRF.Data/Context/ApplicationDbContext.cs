using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MRF.Models;

namespace MRF.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            CreateEntityModel(builder);
            base.OnModelCreating(builder);
        }

        private static void CreateEntityModel(ModelBuilder modelBuilder)
        {

        }

        //#region DataSets

        //public DbSet<Inventory> Inventories { get; set; }
        //public DbSet<Production> Productions { get; set; }
        //public DbSet<Sale> Sales { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Client> Clients { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        //public DbSet<Note> Notes { get; set; }

        //#endregion

        #region ITransactionScope Implementation

        internal Guid? TransactionToken { get; private set; }
        private IDbContextTransaction DbContextTransaction { get; set; }

        public Guid? BeginTransaction()
        {
            // If there is already a transaction running then do not issue a new token 
            if (HasTransactionStarted())
            {
                return null;
            }

            // Otherwise we are starting a new transaction 
            // and need to issue a new tracking token 
            // to be used to complete the transaction
            TransactionToken = Guid.NewGuid();
            DbContextTransaction = Database.BeginTransaction();
            return TransactionToken;
        }

        public void EndTransaction(Guid? token)
        {
            // If this token is not for this transaction then ignore 
            // the request to commit the changes to the database
            if (token.HasValue &&
                TransactionToken.HasValue &&
                TransactionToken.Value == token.Value &&
                DbContextTransaction != null)
            {
                try
                {
                    // Try to commit changes to the database
                    base.SaveChanges();
                    DbContextTransaction.Commit();
                }
                catch
                {
                    // Error, so roll back and dispose of transaction
                    DisposeTransaction(token, rollBack: true);
                    throw;
                }

                // Successfully committed so now just dispose, 
                // allowing for a new transaction to be started
                DisposeTransaction(token, rollBack: false);
            }
        }

        public void DisposeTransaction(Guid? token, bool rollBack)
        {
            // If this token is not for this transaction then ignore 
            // the request to disppse of the transaction
            if (token.HasValue &&
                TransactionToken.HasValue &&
                TransactionToken.Value == token.Value &&
                DbContextTransaction != null)
            {
                if (DbContextTransaction != null)
                {
                    // Check if we need to do a rollback
                    if (rollBack)
                    {
                        DbContextTransaction.Rollback();
                    }

                    // Dispose of the transaction
                    DbContextTransaction.Dispose();
                    DbContextTransaction = null;
                }

                // Dispose of the tracking token
                TransactionToken = null;
            }
        }

        public bool HasTransactionStarted()
        {
            // If there is a token being tracked 
            // then a transaction has been started
            return TransactionToken.HasValue;
        }

        #endregion
    }
}
