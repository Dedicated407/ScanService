using Microsoft.EntityFrameworkCore;
using ScanService.API.Entities;
using ScanService.API.Infrastructure.Interfaces;

namespace ScanService.API.Infrastructure;

public sealed class DataContext : DbContext, IDataContext, IRepository
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    #region DbSet

    public DbSet<ScanEntity> DbScans { get; set; }

    #endregion

    #region IQueryable

    public IQueryable<ScanEntity> Scans => DbScans;

    #endregion

    public async Task Create(ScanEntity scanEntity, CancellationToken cancellationToken)
    {
        if (scanEntity == null)
        {
            throw new ArgumentNullException(nameof(scanEntity));
        }

        await AddAsync(scanEntity, cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task Update(ScanEntity scanEntity, CancellationToken cancellationToken)
    {
        if (scanEntity == null)
        {
            throw new ArgumentNullException(nameof(scanEntity));
        }
        
        Update(scanEntity);
        await SaveChangesAsync(cancellationToken);
    }
}