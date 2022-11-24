using Microservice.Application.Features.Cars.Commands.CreateCar;
using Microservice.Application.Features.Cars.Queries.GetCarById;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Presentation.Controllers;

[Route("api/[controller]")]
public sealed class CarsController : ApiController
{
    public CarsController (ISender sender)
        : base (sender) { }

    [HttpHead ("{id:guid}")]
    [HttpGet ("{id:guid}")]
    public async Task<IActionResult> GetCarById (Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCarByIdQuery (id);
        
        var response = await Sender.Send (query, cancellationToken);
        
        return response.IsSuccess ? Ok (response.Value) : NotFound (response.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCar (int year, string make, string model, CancellationToken cancellationToken)
    {
        var command = new CreateCarCommand (year, make, model);

        var result = await Sender.Send (command, cancellationToken);

        return Ok (result.Value);
    }
}