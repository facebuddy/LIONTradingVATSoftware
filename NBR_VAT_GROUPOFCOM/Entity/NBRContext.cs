using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.Entity
{
    public class NBRContext : DbContext
    {
        public NBRContext() : base(nameOrConnectionString: "NBR_POS_ConnString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Test> TestsR { get; set; }
    }
}