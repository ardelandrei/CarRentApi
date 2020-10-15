using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

        public DateTime YearOfManufacture { get; set; }

    }
}
