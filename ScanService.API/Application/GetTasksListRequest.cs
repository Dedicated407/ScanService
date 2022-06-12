using MediatR;
using ScanService.API.Entities;

namespace ScanService.API.Application;

public class GetTasksListRequest : IRequest<ICollection<ScanEntity>>
{
}