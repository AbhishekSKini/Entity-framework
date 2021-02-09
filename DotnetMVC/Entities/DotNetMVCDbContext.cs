using Microsoft.EntityFrameworkCore;
using System;

namespace DotnetMVC.Entities
{
    /// <summary>
    /// BurganBankDbContext class
    /// </summary>
    public class DotNetMVCDbContext : DbContext
    {
        //// region ModuleListEntity#
        public virtual DbSet<Country> Country
        {
            get;
            set;
        }
        public virtual DbSet<state> state
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DotNetMVCDbContext(DbContextOptions<DotNetMVCDbContext> options) : base(options)
        {
        }
    }
}