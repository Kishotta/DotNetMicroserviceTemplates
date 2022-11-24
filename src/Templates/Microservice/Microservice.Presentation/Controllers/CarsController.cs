using System.Net;
using Microservice.Application.Features.Cars;
using Microservice.Application.Features.Cars.Commands.CreateCar;
using Microservice.Application.Features.Cars.Commands.RemoveCar;
using Microservice.Application.Features.Cars.Commands.UpdateCar;
using Microservice.Application.Features.Cars.Queries.GetCarById;
using Microservice.Application.Features.Cars.Queries.GetCars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Microservice.Presentation.Controllers;

[Route("api/[controller]")]
public sealed class CarsController : ApiController
{
    private readonly ILogger<CarsController> _logger;
    
    public CarsController (ISender sender, ILogger<CarsController> logger)
        : base (sender)
    {
        _logger = logger;
    }
    
    [HttpOptions]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ApiExplorerSettings (IgnoreApi = true)]
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
    [Produces ("application/json")]
    [ProducesResponseType (StatusCodes.Status200OK)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IActionResult> HeadCars (CancellationToken cancellationToken)
    {
        var query = new GetCarsQuery ();

        var result = await Sender.Send (query, cancellationToken);
        
        return Ok (result.Value);
    }
    
    [HttpGet]
    [Produces ("application/json")]
    [ProducesResponseType (typeof(IEnumerable<CarResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCars (CancellationToken cancellationToken)
    {
        var query = new GetCarsQuery ();

        var result = await Sender.Send (query, cancellationToken);
        
        return Ok (result.Value);
    }
    
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType (typeof(CarResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateCar (int year, string make, string model, CancellationToken cancellationToken)
    {
        var command = new CreateCarCommand (year, make, model);

        var result = await Sender.Send (command, cancellationToken);

        return result.IsSuccess ? CreatedAtAction (nameof(GetCarById), new { id = result.Value.Id }, result.Value) : BadRequest(result.Error);
    }
    
    [HttpOptions ("{id:guid}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Options (Guid id)
    {
        HttpContext.Response.Headers.AppendCommaSeparatedValues(
            HeaderNames.Allow,
            HttpMethods.Options,
            HttpMethods.Head,
            HttpMethods.Get,
            HttpMethods.Put,
            HttpMethods.Patch,
            HttpMethods.Delete
        );
        return Ok ();
    }

    [HttpHead ("{id:guid}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IActionResult> HeadCarById (Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCarByIdQuery (id);
        
        var result = await Sender.Send (query, cancellationToken);
        
        return result.IsSuccess ? Ok (result.Value) : NotFound (result.Error);
    }
    
    [HttpGet ("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType (typeof(CarResponse), StatusCodes.Status200OK)]
    [ProducesResponseType (typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCarById (Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCarByIdQuery (id);
        
        var result = await Sender.Send (query, cancellationToken);
        
        return result.IsSuccess ? Ok (result.Value) : NotFound (result.Error);
    }
    
    [HttpPut ("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType (typeof(CarResponse), StatusCodes.Status200OK)]
    [ProducesResponseType (typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCar (Guid id, int year, string make, string model, CancellationToken cancellationToken)
    {
        var command = new UpdateCarCommand (id, year, make, model);

        var result = await Sender.Send (command, cancellationToken);

        return result.IsSuccess ? Ok (result.Value) : NotFound (result.Error);
    }

    [HttpPatch ("{id:guid}")]
    [Consumes("application/json-patch+json")]
    [Produces("application/json")]
    [ProducesResponseType (typeof(CarResponse), StatusCodes.Status200OK)]
    [ProducesResponseType (typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PatchCar (Guid id, JsonPatchDocument<CarResponse> patchDocument, CancellationToken cancellationToken)
    {
        var query = new GetCarByIdQuery (id);
        
        var queryResult = await Sender.Send (query, cancellationToken);
        
        if (queryResult.IsFailure)
            return NotFound (queryResult.Error);

        var carResponse = queryResult.Value;
        
        patchDocument.ApplyTo(carResponse);
        
        var command = new UpdateCarCommand (id, carResponse.Year, carResponse.Make, carResponse.Model);
        
        var commandResult = await Sender.Send (query, cancellationToken);

        return commandResult.IsSuccess ? Ok (commandResult.Value) : NotFound (commandResult.Error);
    }
    
    [HttpDelete ("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType (StatusCodes.Status204NoContent)]
    [ProducesResponseType (typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveCar (Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveCarCommand (id);

        var result = await Sender.Send (command, cancellationToken);

        return result.IsSuccess ? NoContent () : NotFound (result.Error);
    }
}