using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Mysql
{
    public partial class ItrebolsoftDbContext : DbContext
    {
        public ItrebolsoftDbContext()
        {
        }

        public ItrebolsoftDbContext(DbContextOptions<ItrebolsoftDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=www.itrebolsoft.com; database=Itrebolsoft;user=e2n5kqnq8u5b;pwd=Danoshin@7");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
    }
}
