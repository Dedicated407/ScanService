using MediatR;
using ScanService.Client.Models;

namespace ScanService.API.Application;

public class CreateTaskRequest : CreateTaskRequestModel, IRequest<Guid>
{
}