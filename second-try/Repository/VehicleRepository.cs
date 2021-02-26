using second_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Repository
{
    public class VehicleRepository: RepositoryBase<Vehicle>
    {
        private readonly AppDbContext appDbContext;

        public VehicleRepository(AppDbContext appDbContext): base (appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Vehicle>> BulkInsert(Vehicle[] vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                appDbContext.Vehicles.Add(vehicle);
            }
            await appDbContext.SaveChangesAsync();

            return vehicles;
        }
    }
}
