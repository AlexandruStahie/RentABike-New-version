using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentABike.Models
{
    public class Bicycle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BicycleId { get; set; }
        [Required]
        public string BModel { get; set; }
        [Required]
        public decimal? PricePerHour { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public byte[] BicycleImg { get; set; }
    }
}