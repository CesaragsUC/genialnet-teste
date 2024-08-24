using Application.DTOs.Product;
using Application.DTOs.Supplier;
using Application.Handlers.Commands.Products;
using Application.Handlers.Commands.Supplier;
using Application.Handlers.Commands.Suppliers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Kernel;

namespace web.Controllers
{
    public class ProductsController(IMediator mediator) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var products = await mediator.Send(new GetAllProductsQuery());

            return View(products.Data);
        }
        public async Task<IActionResult> Add()
        {
            var suppliers = await mediator.Send(new GetAllSupplierQuery());

            var model = new ProductDto { Suppliers = suppliers.Data };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto model)
        {
            var result = await mediator.Send(new CreateProductCommand(model));
            if (!result.Succeeded)
            {
                return NotFound(result.Messages);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var product = await mediator.Send(new GetProductQuery(id));

            return View(product.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto model)
        {
            var result = await mediator.Send(new UpdateProductCommand(model));
            if (!result.Succeeded)
            {
                return NotFound(result.Messages);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(Guid id)
        {
            var product = await mediator.Send(new GetProductQuery(id));

            return View(product.Data);
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmRemove(Guid id)
        {
            await mediator.Send(new DeleteProductCommand(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var product = await mediator.Send(new GetProductQuery(id));

            return View(product.Data);
        }
    }
}
