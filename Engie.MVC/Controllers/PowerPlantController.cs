using Engie.Domain.Commands;
using Engie.Domain.Handlers;
using Engie.Domain.Repositories;
using Engie.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Engie.MVC.Controllers
{
    public class PowerPlantController : Controller
    {
        private readonly PowerPlantHandler _handler;

        public PowerPlantController(PowerPlantHandler handler)
        {
            _handler = handler;
        }

        public IActionResult Index([FromServices] IPowerPlantRepository repository)
        {
            return View(repository.GetPowerPlants());
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePowerPlantCommand command, [FromServices] PowerPlantHandler handler)
        {
            handler.Handle(command);
            return RedirectToAction("./Index");
        }
    }
}