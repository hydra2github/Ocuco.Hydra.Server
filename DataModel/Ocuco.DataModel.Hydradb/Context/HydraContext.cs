
using Microsoft.EntityFrameworkCore;
using Ocuco.DataModel.Hydradb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocuco.DataModel.Hydradb.Context
{
    public class HydraContext : DbContext
    {
        public HydraContext(DbContextOptions<HydraContext> options) : base(options) { }


        ////////////////////
        // Sample tables
        ////////////////////

        public DbSet<ArtProduct> ArtProducts { get; set; }
        public DbSet<ArtOrder> ArtOrders { get; set; }

        //////////////////////////////
        // Luxottica RXO Tables 
        //////////////////////////////

        public DbSet<RxoDoor> RxoDoors { get; set; }
        public DbSet<RxoWsAuditing> RxoWsAuditingTable { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // AC 2.1
            //modelBuilder.Entity<Order>()
            //    .HasData(new Order()
            //    {
            //        Id = 1,
            //        OrderDate = DateTime.UtcNow,
            //        OrderNumber = "12345"
            //    });
        }
    }
}
