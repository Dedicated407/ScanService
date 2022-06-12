using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScanService.API.Application;

namespace ScanService.API.Controllers;

[ApiController]
[Route("api")]
public class ScanController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ScanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Создание задач на сканирование файлов.
    /// </summary>
    [HttpPost("scan")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request) =>
        Ok(await _mediator.Send(request));
}