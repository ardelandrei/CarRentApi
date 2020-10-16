using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using CarRentApi.IntegrationTests;
using DataAccess.Models;

namespace CarRentApi.IntegrationTest
{
    [TestFixture]
    public class IntegrationTestCarRentApi
    {
        private APIWebApplicationFactory factory;
        private HttpClient client;
        private string jsonContentType = "application/json";

        [OneTimeSetUp]
        public void Setup()
        {
            factory = new APIWebApplicationFactory();
            client = factory.CreateClient();
        }

        [Test]
        public async Task IntegrationTestAsync()
        {
            #region test get all
            var response = await client.GetAsync("/vehicles"); 
            try
            {
                Assert.AreEqual((int)response.StatusCode, 200);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            var data = await response.Content.ReadAsStreamAsync();
            var vehicles = await JsonSerializer.DeserializeAsync<IEnumerable<Vehicle>>(data);
            var initialCount = vehicles.Count();
            #endregion test get all

            #region test post
            var newVehicle = new Vehicle
            {
                CanBeRented = true,
                RentPricePerHour = 222.421m,
                ManufacturerDetails = new ManufacturerDetails
                {
                    VIN = RandomStringsGenerator.GetRandomString(17),
                    DateOfManufacture = new DateTime(2002, 2, 1),
                    Mark = "Dacia",
                    Model = "Duster"
                }
            };
            var jsonObject = JsonSerializer.Serialize(newVehicle);

            response = await client.PostAsync("/vehicles", new StringContent(
                    jsonObject.ToString(),
                    Encoding.UTF8,
                    jsonContentType)); 
            try
            {
                Assert.AreEqual((int)response.StatusCode, 201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            #endregion test post

            #region test get
            // get the id of the added vehicle from Location header
            var id = response.Headers.Location.ToString().Split("/").Last();
            response = await client.GetAsync($"/vehicles/{id}"); 
            try
            {
                Assert.AreEqual((int)response.StatusCode, 200);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            #endregion test get

            #region test the vehicle is Dacia by VIN
            // the vehicle added in the last call
            data = await response.Content.ReadAsStreamAsync();
            var vehicleDacia = await JsonSerializer.DeserializeAsync<Vehicle>(data);
            try
            {
                Assert.AreEqual(newVehicle.ManufacturerDetails.VIN, vehicleDacia.ManufacturerDetails.VIN);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            #endregion test the vehicle is Dacia by VIN

            #region test put
            vehicleDacia.ManufacturerDetails.Mark = "Renault";
            vehicleDacia.ManufacturerDetails.Model = "Captur";
            jsonObject = JsonSerializer.Serialize(vehicleDacia);
            response = await client.PutAsync($"/vehicles/{vehicleDacia.Id}", new StringContent(
                   jsonObject.ToString(),
                   Encoding.UTF8,
                   jsonContentType));
            try
            {
                Assert.AreEqual((int)response.StatusCode, 204);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            #endregion test put

            #region test vehicle is Renault and id didn't changed
            response = await client.GetAsync($"/vehicles/{vehicleDacia.Id}"); 
            data = await response.Content.ReadAsStreamAsync();
            var vehicleRenault = await JsonSerializer.DeserializeAsync<Vehicle>(data);
            try
            {
                Assert.AreEqual(vehicleDacia.Id, vehicleRenault.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

            try
            {
                Assert.AreEqual("Renault", vehicleRenault.ManufacturerDetails.Mark);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            #endregion test vehicle is Renault by VIN

            #region test delete
            response = await client.DeleteAsync($"/vehicles/{vehicleRenault.Id}"); 
            try
            {
                Assert.AreEqual((int)response.StatusCode, 204);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            #endregion test delete

            #region test count is initialCount
            response = await client.GetAsync("/vehicles");
            data = await response.Content.ReadAsStreamAsync();
            vehicles = await JsonSerializer.DeserializeAsync<IEnumerable<Vehicle>>(data);
            try
            {
                Assert.AreEqual(initialCount, vehicles.Count());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            #endregion test count is initialCount
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
            factory.Dispose();
        }
    }
}