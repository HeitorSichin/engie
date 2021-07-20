using System.Collections.Generic;
using Engie.Domain.Entities;

namespace Engie.Domain.Repositories
{
    public interface IPowerPlantRepository
    {
        void CreatePowerPlant(PowerPlant powerPlant);
        PowerPlant GetPowerPlant(int id);
        IEnumerable<PowerPlant> GetPowerPlants();
        void UpdatePowerPlant(PowerPlant powerPlant);
        void RemovePowerPlant(int id);

        bool PowerPlantExists(string powerPlantUC, int supplier);
    }
}