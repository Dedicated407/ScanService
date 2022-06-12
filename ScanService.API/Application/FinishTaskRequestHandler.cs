using MediatR;
using Microsoft.EntityFrameworkCore;
using ScanService.API.Infrastructure.Interfaces;

namespace ScanService.API.Application;

public class FinishTaskRequestHandler : IRequestHandler<FinishTaskRequest>
{
    private readonly IRepository _repository;

    public FinishTaskRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<Unit> Handle(FinishTaskRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Scans
            .FirstOrDefaultAsync(x => 
                x.Id == request.Id, 
                cancellationToken);

        if (entity == null)
        {
            throw new ArgumentException($"ScanEntity with Id={request.Id} is not found!");
        }

        entity.IsFinished = true;
        entity.ProcessedFiles = request.ProcessedFiles;
        entity.JSDetects = request.JSDetects;
        entity.RmRfDetects = request.RmRfDetects;
        entity.RunDllDetects = request.RunDllDetects;
        entity.Errors = request.Errors;
        entity.EndTime = DateTime.UtcNow;
        
        await _repository.Update(entity, cancellationToken);

        return Unit.Value;
    }
}