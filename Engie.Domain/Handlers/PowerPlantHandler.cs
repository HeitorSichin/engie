using Engie.Domain.Commands;
using Engie.Domain.Entities;
using Engie.Domain.Repositories;
using Engie.Shared.Commands;
using Engie.Shared.Handlers;
using Flunt.Notifications;

namespace Engie.Domain.Handlers
{
    public class PowerPlantHandler :
        Notifiable<Notification>,
        IHandler<CreatePowerPlantCommand>,
        IHandler<UpdatePowerPlantCommand>,
        IHandler<ActivePowerPlantCommand>,
        IHandler<InactivePowerPlantCommand>
    {
        private readonly IPowerPlantRepository _powerPlantRepository;
        private readonly ISupplierRepository _supplierRepository;

        public PowerPlantHandler(IPowerPlantRepository powerPlantRepository, ISupplierRepository supplierRepository)
        {
            _powerPlantRepository = powerPlantRepository;
            _supplierRepository = supplierRepository;
        }

        public ICommandResult Handle(CreatePowerPlantCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível salvar a nova usina");
            }

            if (_powerPlantRepository.PowerPlantExists(command.PowerPlantUC, command.Supplier))
            {
                AddNotification("PowerPlantUC", "Já existe uma usina cadastra para esse fornecedor com essa UC");
            }

            var supplier = _supplierRepository.GetSupplier(command.Supplier);
            var powerPlant = new PowerPlant(command.PowerPlantUC, supplier);

            AddNotifications(supplier, powerPlant);

            if (!IsValid)
                return new CommandResult(false, "Não foi possível salvar a nova usina");

            _powerPlantRepository.CreatePowerPlant(powerPlant);

            return new CommandResult(true, "Usina salva com sucesso.");
        }

        public ICommandResult Handle(UpdatePowerPlantCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível salvar a alteração da usina");
            }

            if (_powerPlantRepository.PowerPlantExists(command.PowerPlantUC, command.Supplier))
            {
                AddNotification("PowerPlantUC", "Já existe uma usina cadastra para esse fornecedor com essa UC");
            }

            var supplier = _supplierRepository.GetSupplier(command.Supplier);
            var powerPlant = _powerPlantRepository.GetPowerPlant(command.Id);

            powerPlant.Update(command.PowerPlantUC, supplier, command.Active);

            AddNotifications(supplier, powerPlant);

            if (!IsValid)
                return new CommandResult(false, "Não foi possível salvar a alteração da usina");

            _powerPlantRepository.UpdatePowerPlant(powerPlant);

            return new CommandResult(true, "Usina salva com sucesso.");
        }

        public ICommandResult Handle(ActivePowerPlantCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível salvar a alteração da usina");
            }

            var powerPlant = _powerPlantRepository.GetPowerPlant(command.Id);
            powerPlant.Activate();

            _powerPlantRepository.UpdatePowerPlant(powerPlant);

            return new CommandResult(true, "Usina ativada com sucesso");
        }

        public ICommandResult Handle(InactivePowerPlantCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível salvar a alteração da usina");
            }

            var powerPlant = _powerPlantRepository.GetPowerPlant(command.Id);
            powerPlant.Inactivate();

            _powerPlantRepository.UpdatePowerPlant(powerPlant);

            return new CommandResult(true, "Usina inativada com sucesso");
        }
    }
}