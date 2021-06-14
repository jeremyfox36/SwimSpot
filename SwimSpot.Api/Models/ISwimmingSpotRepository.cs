using SwimSpot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimSpot.Api.Models
{
    public interface ISwimmingSpotRepository
    {
        IEnumerable<SwimmingSpot> GetAllSwimmingSpots();
        SwimmingSpot GetSwimmingSpotById(int swimmingSpotId);
        SwimmingSpot AddSwimmingSpot(SwimmingSpot swimmingSpot);
        SwimmingSpot UpdateSwimmingSpot(SwimmingSpot swimmingSpot);
        void DeleteSwimmingSpot(int swimmingSpotId);
    }
}
