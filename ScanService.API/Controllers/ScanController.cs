using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScanService.API.Application;
using ScanService.API.Entities;
using ScanService.Client.Models;

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
    
    /// <summary>
    /// Получение информации о задаче.
    /// </summary>
    [HttpGet("scan")]
    [ProducesResponseType(typeof(GetTaskResponseModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTask([FromQuery] Guid id) =>
        Ok(await _mediator.Send(new GetTaskRequest(id)));
    
    /// <summary>
    /// Получение всех задач.
    /// </summary>
    [HttpGet("scans")]
    [ProducesResponseType(typeof(ScanEntity), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList() =>
        Ok(await _mediator.Send(new GetTasksListRequest()));
}