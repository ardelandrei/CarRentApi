using System.ComponentModel.DataAnnotations.Schema;

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
