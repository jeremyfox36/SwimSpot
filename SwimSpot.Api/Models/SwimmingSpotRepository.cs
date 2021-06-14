using Microsoft.EntityFrameworkCore;
using SwimSpot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimSpot.Api.Models
{
    public class SwimmingSpotRepository : ISwimmingSpotRepository
    {
        private readonly AppDbContext _appDbContext;

        public SwimmingSpotRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public SwimmingSpot AddSwimmingSpot(SwimmingSpot swimmingSpot)
        {
            var addedEntity = _appDbContext.SwimmingSpots.Add(swimmingSpot);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteSwimmingSpot(int swimmingSpotId)
        {
            var foundSwimmingSpot = _appDbContext.SwimmingSpots.FirstOrDefault(s => s.SwimmingSpotId == swimmingSpotId);
            if (foundSwimmingSpot == null)
            {
                return;
            }
                
            
            _appDbContext.SwimmingSpots.Remove(foundSwimmingSpot);
            _appDbContext.SaveChanges();
            
        }

        public IEnumerable<SwimmingSpot> GetAllSwimmingSpots()
        {
            var swimmingSpots = _appDbContext.SwimmingSpots
                .Include(sp => sp.Comments)
                .ToList();
            return swimmingSpots;
        }

        public SwimmingSpot GetSwimmingSpotById(int swimmingSpotId)
        {
            var swimmingSpot = _appDbContext.SwimmingSpots
                .Include(sp => sp.Comments)
                .FirstOrDefault(sp => sp.SwimmingSpotId == swimmingSpotId);
            return swimmingSpot;
        }

        public SwimmingSpot UpdateSwimmingSpot(SwimmingSpot swimmingSpot)
        {
            var foundSwimmingSpot = _appDbContext.SwimmingSpots.FirstOrDefault(s => s.SwimmingSpotId == swimmingSpot.SwimmingSpotId);

            if(foundSwimmingSpot != null)
            {
                foundSwimmingSpot.Latitude = swimmingSpot.Latitude;
                foundSwimmingSpot.Longitude = swimmingSpot.Longitude;
                _appDbContext.SaveChanges();
                return foundSwimmingSpot;

            }

            return null;
        }
    }
}
