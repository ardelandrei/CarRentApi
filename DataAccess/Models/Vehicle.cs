using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public bool CanBeRented { get; set; }

        [Column(TypeName = "decimal(10, 3)")]
        public decimal RentPricePerHour { get; set; }


        public int ManufacturerDetailsId { get; set; }

        public ManufacturerDetails ManufacturerDetails { get; set; }
    }
}
