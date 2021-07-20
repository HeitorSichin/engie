using Engie.Domain.Enums;
using Engie.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Engie.Domain.Commands
{
    public class CreatePowerPlantCommand : Notifiable<Notification>, ICommand
    {
        public string PowerPlantUC { get; set; }
        public int Supplier { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreatePowerPlantCommand>()
                .Requires()
                .IsNotNullOrEmpty(PowerPlantUC, "PowerPlant.powerPlantUC", "O campo UC da usina é obrigatório.")
                .IsGreaterThan(0, Supplier, "PowerPlant.supplier", "O campo fornecedor é obrigatório.")
            );
        }
    }
}