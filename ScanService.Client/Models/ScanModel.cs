namespace ScanService.Client.Models;

public class ScanModel
{
    public Guid Id { get; set; }
    public ushort ProcessedFiles { get; set; }
    public ushort JSDetects { get; set; }
    public ushort RmRfDetects { get; set; }
    public ushort RunDllDetects { get; set; }
    public ushort Errors { get; set; }
}