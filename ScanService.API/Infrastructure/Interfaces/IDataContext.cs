using Microsoft.EntityFrameworkCore;
using ScanService.API.Entities;

namespace ScanService.API.Infrastructure.Interfaces;

public interface IDataContext
{
    DbSet<ScanEntity> DbScans { get; set; }
}