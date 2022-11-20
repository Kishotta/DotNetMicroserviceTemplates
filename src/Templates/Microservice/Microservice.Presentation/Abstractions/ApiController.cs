using Microsoft.AspNetCore.Mvc;

namespace Microservice.Presentation.Abstractions;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected ApiController (ISender sender) => Sender = sender;
}