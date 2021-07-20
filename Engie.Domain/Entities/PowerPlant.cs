using Engie.Domain.Enums;
using Engie.Shared.Entities;
using Flunt.Validations;

namespace Engie.Domain.Entities
{
    public class PowerPlant : Entity
    {
        public PowerPlant(string powerPlantUC, Supplier supplier)
        {
            PowerPlantUC = powerPlantUC;
            Active = EActive.Active;
            Supplier = supplier;

            AddNotifications(new Contract<PowerPlant>()
                .Requires()
                .IsNotNullOrEmpty(powerPlantUC, "PowerPlant.powerPlantUC", "O campo UC da usina é obrigatório.")
                .IsNotNull(supplier, "PowerPlant.supplier", "O campo fornecedor é obrigatório.")
            );
        }

        public int Id { get; private set; }
        public string PowerPlantUC { get; private set; }
        public EActive Active { get; private set; }
        public Supplier Supplier { get; private set; }

        public void Activate()
        {
            Active = EActive.Active;
        }

        public void Inactivate()
        {
            Active = EActive.Inactive;
        }

        public void Update(string powerPlantUC, Supplier supplier, EActive active)
        {

            AddNotifications(new Contract<PowerPlant>()
                .Requires()
                .IsNotNullOrEmpty(powerPlantUC, "PowerPlant.powerPlantUC", "O campo UC da usina é obrigatório.")
                .IsNotNullOrEmpty(supplier.Name, "PowerPlant.supplier.name", "O campo fornecedor é obrigatório.")
            );
        }
    }
}