using MediatR;
using ScanService.Client.Models;

namespace ScanService.API.Application;

public record GetTaskRequest(Guid Id) : IRequest<GetTaskResponseModel>;