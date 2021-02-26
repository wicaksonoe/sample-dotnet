using Microsoft.AspNetCore.Mvc;
using second_try.Models;
using second_try.Requests;
using second_try.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace second_try.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        // GET: api/vehicles
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> Get(VehicleRequest payload)
        {
            return await vehicleService.GetAllVehicles(payload);
        }

        // GET api/vehicles/5
        [HttpGet("{id}")]
        public async Task<Vehicle> Get(long id)
        {
            return await vehicleService.GetVehicle(id);
        }

        // POST api/vehicles
        [HttpPost]
        public async Task<IEnumerable<Vehicle>> Post(Vehicle[] vehicles)
        {
            return await vehicleService.PostVehicles(vehicles);
        }

        // PUT api/vehicles/5
        [HttpPut("{id}")]
        public async Task<Vehicle> Put(int id, Vehicle vehicle)
        {
            return await vehicleService.UpdateVehicle(id, vehicle);
        }

        // DELETE api/vehicles/5
        [HttpDelete("{id}")]
        public async Task<Vehicle> Delete(int id)
        {
            return await vehicleService.DeleteVehicle(id);
        }
    }
}
