using DataAccess.Models;
using System;
using System.Linq;

namespace DataAccess.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Vehicles.Any())
            {
                return;
            }

            var vehicles = new Vehicle[]
            {
                new Vehicle {
                    RentPricePerHour = 100.50m,
                    ManufacturerDetails = new ManufacturerDetails
                    {
                        VIN = "ASDFASDFASDFASDF1",
                        Mark = "Opel",
                        Model = "Astra",
                        YearOfManufacture = new DateTime(2008, 10, 1)
                    }
                },

                new Vehicle {
                    RentPricePerHour = 100.50m,
                    ManufacturerDetails = new ManufacturerDetails {
                        VIN = "ASDFASDFASDFASDF2",
                        Mark = "Audi",
                        Model = "A4",
                        YearOfManufacture = new DateTime(2007, 10, 1)
                    }
                },

                new Vehicle {
                    RentPricePerHour = 100.50m,
                    ManufacturerDetails = new ManufacturerDetails {
                        VIN = "ASDFASDFASDFASDF3",
                        Mark = "Mercedes",
                        Model = "Benz",
                        YearOfManufacture = new DateTime(2010, 10, 1)
                    }
                },

                new Vehicle {
                    RentPricePerHour = 100.50m,
                    ManufacturerDetails = new ManufacturerDetails {
                        VIN = "ASDFASDFASDFASDF4",
                        Mark = "Dacia",
                        Model = "Logan",
                        YearOfManufacture = new DateTime(2010, 10, 1)
                    }
                },

                new Vehicle {
                    RentPricePerHour = 100.50m,
                    ManufacturerDetails = new ManufacturerDetails {
                        VIN = "ASDFASDFASDFASDF5",
                        Mark = "Porsche",
                        Model = "Carrera",
                        YearOfManufacture = new DateTime(2010, 10, 1)
                    }
                },
            };

            dbContext.Vehicles.AddRange(vehicles);
            dbContext.SaveChanges();
        }
    }
}
