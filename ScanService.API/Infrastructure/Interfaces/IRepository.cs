using ScanService.API.Entities;

namespace ScanService.API.Infrastructure.Interfaces;

public interface IRepository
{
    public IQueryable<ScanEntity> Scans { get; }

    public Task Create(ScanEntity scanEntity, CancellationToken cancellationToken);
}