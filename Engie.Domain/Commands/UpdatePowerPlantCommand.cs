using Engie.Domain.Enums;
using Engie.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Engie.Domain.Commands
{
    public class UpdatePowerPlantCommand : Notifiable<Notification>, ICommand
    {
        public int Id { get; set; }
        public string PowerPlantUC { get; set; }
        public EActive Active { get; set; }
        public int Supplier { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdatePowerPlantCommand>()
                .Requires()
                .IsNotNullOrEmpty(PowerPlantUC, "PowerPlant.powerPlantUC", "O campo UC da usina é obrigatório.")
                .IsGreaterThan(0, Supplier, "PowerPlant.supplier", "O campo fornecedor é obrigatório.")
            );
        }

    }
}