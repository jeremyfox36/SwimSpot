using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimSpot.Shared
{
    public class SwimmingSpot
    {
        public int SwimmingSpotId{ get; set; }

        [Required]
        [Column(TypeName = "decimal(17, 15)")]
        public decimal Latitude { get; set; }
        [Required]
        [Column(TypeName = "decimal(17, 15)")]
        public decimal Longitude { get; set; }
        public List<SwimmingSpotComment> Comments { get; set; }

    }
}
