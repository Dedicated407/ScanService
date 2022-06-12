using MediatR;
using Microsoft.EntityFrameworkCore;
using ScanService.API.Entities;
using ScanService.API.Infrastructure.Interfaces;

namespace ScanService.API.Application;

public class GetTasksListRequestHandler : IRequestHandler<GetTasksListRequest, ICollection<ScanEntity>>
{
    private readonly IRepository _repository;

    public GetTasksListRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<ICollection<ScanEntity>> Handle(GetTasksListRequest request, CancellationToken cancellationToken)
    {
        var entities = await _repository.Scans
            .ToArrayAsync(cancellationToken);

        return entities;
    }
}