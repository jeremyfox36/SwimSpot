using Microsoft.EntityFrameworkCore;
using SwimSpot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimSpot.Api.Models
{
    public class AppDbContext : DbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<SwimmingSpot> SwimmingSpots { get; set; }
        public DbSet<SwimmingSpotComment> SwimmingSpotComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SwimmingSpot>().HasData(new SwimmingSpot { SwimmingSpotId = 1, SwimmingSpotName = "Stantling Craigs", Latitude = 55.6455217723385M, Longitude = -2.9060585301065363M });
            modelBuilder.Entity<SwimmingSpotComment>().HasData(new SwimmingSpotComment { SwimmingSpotCommentId = 1, SwimmingSpotId = 1, CommentDate = new DateTime(2021, 06, 08), SwimDate = new DateTime(2021, 06, 06), WaterTemp = 20, Content = "Swam along west shore with Doug", UserId = 1, UserName = "Jem" });

            modelBuilder.Entity<SwimmingSpot>().HasData(new SwimmingSpot { SwimmingSpotId = 2, SwimmingSpotName = "Gladhouse Reservoir", Latitude = 55.77398808982048M, Longitude = -3.1221541644140895M });
            modelBuilder.Entity<SwimmingSpotComment>().HasData(new SwimmingSpotComment { SwimmingSpotCommentId = 2, SwimmingSpotId = 2, CommentDate = new DateTime(2021, 06, 08), SwimDate = new DateTime(2021, 06, 06), WaterTemp = 20, Content = "Swam around the island", UserId = 1, UserName = "Jem" });
        }
    }
}
 