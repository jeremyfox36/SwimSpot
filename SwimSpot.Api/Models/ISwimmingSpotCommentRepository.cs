using SwimSpot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimSpot.Api.Models
{
    public interface ISwimmingSpotCommentRepository
    {
        SwimmingSpotComment AddSwimmingSpotComment(SwimmingSpotComment swimmingSpotComment);
        void DeleteSwimmingSpotComment(int swimmingSpotCommentId);
        IEnumerable<SwimmingSpotComment> GetAllSwimmingSpotCommentsBySwimmingSpotId(int swimmingSpotId);
        SwimmingSpotComment GetSwimmingSpotCommentById(int swimmingSpotCommentId);
        void ApproveSwimmingSpotComment(int swimmingSpotCommentId);


    }
}
