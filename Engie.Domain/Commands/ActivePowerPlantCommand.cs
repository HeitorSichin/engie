using Engie.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Engie.Domain.Commands
{
    public class ActivePowerPlantCommand : Notifiable<Notification>, ICommand
    {
        public ActivePowerPlantCommand() { }

        public ActivePowerPlantCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<ActivePowerPlantCommand>()
                .Requires()
            );
        }
    }
}