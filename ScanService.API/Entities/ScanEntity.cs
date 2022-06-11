﻿namespace ScanService.API.Entities;

public class ScanEntity
{
    public Guid Id { get; private set; }
    public string Directory { get; private set; }
    public ushort ProcessedFiles { get; set; }
    public ushort JSDetects { get; set; }
    public ushort RmRfDetects { get; set; }
    public ushort RunDllDetects { get; set; }
    public ushort Errors { get; set; }
    public TimeOnly ExecutionTime { get; set; }

    public ScanEntity(string directory) : base()
    {
        Directory = directory;
    }
    
    private ScanEntity()
    {
        Id = Guid.NewGuid();
    }
}