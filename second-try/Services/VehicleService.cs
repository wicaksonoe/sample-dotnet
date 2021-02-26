using second_try.Models;
using second_try.Repository;
using second_try.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Services
{
    public class VehicleService
    {
        private readonly VehicleRepository vehicleRepository;

        public VehicleService(VehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles(VehicleRequest payload)
        {
            return await vehicleRepository.GetByCondition(v => v.UserId == payload.UserId);
        }

        public async Task<Vehicle> GetVehicle(long id)
        {
            return await vehicleRepository.FindById(id);
        }

        public async Task<IEnumerable<Vehicle>> PostVehicles(Vehicle[] vehicles)
        {
            await vehicleRepository.BulkInsert(vehicles);
            return vehicles;
        }

        public async Task<Vehicle> UpdateVehicle(long id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                throw new Exception("Bad request");
            }

            return await vehicleRepository.Update(vehicle);
        }

        public async Task<Vehicle> DeleteVehicle(long id)
        {
            return await vehicleRepository.Delete(id);
        }
    }
}
