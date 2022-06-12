using MediatR;
using Microsoft.EntityFrameworkCore;
using ScanService.API.Infrastructure.Interfaces;
using ScanService.Client.Models;

namespace ScanService.API.Application;

public class GetTaskRequestHandler : IRequestHandler<GetTaskRequest, GetTaskResponseModel>
{
    private readonly IRepository _repository;

    public GetTaskRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<GetTaskResponseModel> Handle(GetTaskRequest request, CancellationToken cancellationToken)
    {
        var scanEntity = await _repository.Scans
            .FirstOrDefaultAsync(scan => scan.Id == request.Id, cancellationToken);
        
        if (scanEntity == null)
        {
            throw new ArgumentException($"ScanEntity with Id={request.Id} is not found!");
        }

        if (!scanEntity.IsFinished)
        {
            throw new ArgumentException("Scan task in progress, please wait");
        }

        var responseModel = new GetTaskResponseModel
        {
            Directory = scanEntity.Directory,
            ProcessedFiles = scanEntity.ProcessedFiles,
            JSDetects = scanEntity.JSDetects,
            RmRfDetects = scanEntity.RmRfDetects,
            RunDllDetects = scanEntity.RunDllDetects,
            Errors = scanEntity.Errors,
            Time = scanEntity.Time,
        };

        return responseModel;
    }
}