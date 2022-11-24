using Microservice.Application.Features.Cars.Commands.CreateCar;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Presentation.Controllers;

[Route("api/[controller]")]
public sealed class CarController : ApiController
{
    public CarController (ISender sender)
        : base (sender) { }

    [HttpPost]
    public async Task<IActionResult> AddCar (int year, string make, string model, CancellationToken cancellationToken)
    {
        var command = new CreateCarCommand (year, make, model);

        var result = await Sender.Send (command, cancellationToken);

        return Ok (result.Value);
    }
}