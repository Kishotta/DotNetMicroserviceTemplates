using Microservice.Application.Features.Cars.Commands.CreateCar;
using Microservice.Application.Features.Cars.Queries.GetCarById;
using Microservice.Application.Features.Cars.Queries.GetCars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

namespace Microservice.Presentation.Controllers;

[Route("api/[controller]")]
public sealed class CarsController : ApiController
{
    public CarsController (ISender sender)
        : base (sender) { }

    [HttpOptions]
    public IActionResult Options ()
    {
        HttpContext.Response.Headers.AppendCommaSeparatedValues(
            HeaderNames.Allow,
            HttpMethods.Options,
            HttpMethods.Head,
            HttpMethods.Get,
            HttpMethods.Post
        );
        return Ok ();
    }
    
    [HttpHead]
    [HttpGet]
    public async Task<IActionResult> GetCars (CancellationToken cancellationToken)
    {
        var query = new GetCarsQuery ();

        var response = await Sender.Send (query, cancellationToken);
        
        return Ok (response.Value);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCar (int year, string make, string model, CancellationToken cancellationToken)
    {
        var command = new CreateCarCommand (year, make, model);

        var result = await Sender.Send (command, cancellationToken);

        return CreatedAtAction (nameof(GetCarById), new { id = result.Value.Id }, result.Value);
    }
    
    [HttpOptions ("{id:guid}")]
    public IActionResult Options (Guid id)
    {
        HttpContext.Response.Headers.AppendCommaSeparatedValues(
            HeaderNames.Allow,
            HttpMethods.Options,
            HttpMethods.Head,
            HttpMethods.Get,
            HttpMethods.Post
        );
        return Ok ();
    }

    [HttpHead ("{id:guid}")]
    [HttpGet ("{id:guid}")]
    public async Task<IActionResult> GetCarById (Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCarByIdQuery (id);
        
        var response = await Sender.Send (query, cancellationToken);
        
        return response.IsSuccess ? Ok (response.Value) : NotFound (response.Error);
    }
}