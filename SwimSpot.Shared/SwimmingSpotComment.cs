using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwimSpot.Shared
{ 
    public class SwimmingSpotComment
    {
        public int SwimmingSpotCommentId { get; set; }
        [Required]
        public int SwimmingSpotId { get; set; }
    
        public string Content { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
        public int WaterTemp { get; set; }
        [Required]
        public DateTime SwimDate { get; set; }
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }


    }
}
