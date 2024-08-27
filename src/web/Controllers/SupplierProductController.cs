using Application.DTOs.ProductSupplier;
using Application.Handlers.Commands.Products;
using Application.Handlers.Commands.Supplier;
using Application.Handlers.Commands.SupplierProduct;
using Application.Handlers.Commands.Suppliers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class SupplierProductController(IMediator mediator) : Controller
{

    public async Task<IActionResult> Index()
    {
        var products = await mediator.Send(new GetAllSupplierProductsQuery());

        return View(products.Data);
    }

    public async Task<IActionResult> Add()
    {
        var suppliers = await mediator.Send(new GetAllSupplierQuery());
        var products = await mediator.Send(new GetAllProductsQuery());

        var model = new SupplierProductDto { Suppliers = suppliers.Data, Products = products.Data  };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SupplierProductDto model)
    {
        var result = await mediator.Send(new CreateSupplierProductCommand(model));
        if (!result.Succeeded)
        {
            return NotFound(result.Messages);
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(Guid id)
    {
        var model = await BuildSupplierProductDto(id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(SupplierProductDto model)
    {
        var result = await mediator.Send(new UpdateSupplierProductCommand(model));
        if (!result.Succeeded)
        {
            return NotFound(result.Messages);
        }
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Remove(Guid id)
    {
        await mediator.Send(new DeleteSupplierProdutoCommand(id));
        return RedirectToAction("Index");
    }

    private async Task<SupplierProductDto> BuildSupplierProductDto(Guid id)
    {
        var suppliers = await mediator.Send(new GetAllSupplierQuery());
        var products = await mediator.Send(new GetAllProductsQuery());

        var model = new SupplierProductDto { Suppliers = suppliers.Data, Products = products.Data };

        var result = await mediator.Send(new GetSupplierProductQuery(id));

        model.SupplierId = result.Data.SupplierId;
        model.ProductId = result.Data.ProductId;
        model.Price = result.Data.Price;

        return model;
    }

}