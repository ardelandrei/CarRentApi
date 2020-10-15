using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class ManufacturerDetails
    {
        public int ManufacturerDetailsId { get; set; }

        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }

        public string Mark { get; set; }

        public string Model { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfManufacture { get; set; }

    }
}
