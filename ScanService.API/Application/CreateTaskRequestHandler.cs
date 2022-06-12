using MediatR;
using ScanService.API.Entities;
using ScanService.API.Infrastructure.Interfaces;

namespace ScanService.API.Application;

public class CreateTaskRequestHandler : IRequestHandler<CreateTaskRequest, Guid>
{
    private readonly IRepository _repository;

    public CreateTaskRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<Guid> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        ScanEntity entity = new ScanEntity(request.Directory);

        await _repository.Create(entity, cancellationToken);

        return entity.Id;
    }
}