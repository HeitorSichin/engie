using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Engie.Domain.Entities;
using Engie.Domain.Repositories;
using Engie.Infra.Contexts;

namespace Engie.Infra.Repositories
{
    public class PowerPlantRepository : IPowerPlantRepository
    {
        private readonly EngieDataContext _context;

        public PowerPlantRepository(EngieDataContext context)
        {
            _context = context;
        }

        public PowerPlant GetPowerPlant(int id)
        {
            return _context.PowerPlants
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<PowerPlant> GetPowerPlants()
        {
            return _context.PowerPlants.AsNoTracking();
        }

        public bool PowerPlantExists(string powerPlantUC, int supplier)
        {
            return _context.PowerPlants
                .Any(x => x.PowerPlantUC == powerPlantUC && x.Supplier.Id == supplier);
        }

        public void CreatePowerPlant(PowerPlant powerPlant)
        {
            _context.PowerPlants.Add(powerPlant);
        }
        public void UpdatePowerPlant(PowerPlant powerPlant)
        {
            _context.Entry(powerPlant).State = EntityState.Modified;
        }

        public void RemovePowerPlant(int id)
        {
            var powerPlant = GetPowerPlant(id);
            _context.PowerPlants.Remove(powerPlant);
        }

    }
}