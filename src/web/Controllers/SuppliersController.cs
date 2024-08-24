using Application.DTOs.Supplier;
using Application.Handlers.Commands.Supplier;
using Application.Handlers.Commands.Suppliers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Kernel;

namespace web.Controllers
{
    public class SuppliersController(IMediator mediator) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var suppliers = await mediator.Send(new GetAllSupplierQuery());

            return View(suppliers.Data);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplierDto model)
        {
            var result = await mediator.Send(new CreateSupplierCommand(model));
            
            if(!result.Succeeded)
            {
               return NotFound(result.Messages);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var suppliers = await mediator.Send(new GetSupplierQuery(id));

            return View(suppliers.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SupplierDto model)
        {
            var result = await mediator.Send(new UpdateSupplierCommand(model));

            if (!result.Succeeded)
            {
                return NotFound(result.Messages);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            var suppliers = await mediator.Send(new GetSupplierQuery(id));

            return View(suppliers.Data);
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmRemove(Guid id)
        {
            await mediator.Send(new DeleteSupplierCommand(id));
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var suppliers = await mediator.Send(new GetSupplierQuery(id));

            return View(suppliers.Data);
        }


    }
}
