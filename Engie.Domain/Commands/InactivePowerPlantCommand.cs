using Engie.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Engie.Domain.Commands
{
    public class InactivePowerPlantCommand : Notifiable<Notification>, ICommand
    {
        public InactivePowerPlantCommand() { }

        public InactivePowerPlantCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<InactivePowerPlantCommand>()
                .Requires()
            );
        }
    }
}