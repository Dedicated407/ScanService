namespace ScanService.Client.Models;

public class GetTaskResponseModel
{
    public string Directory { get; set; }
    public ushort ProcessedFiles { get; set; }
    public ushort JSDetects { get; set; }
    public ushort RmRfDetects { get; set; }
    public ushort RunDllDetects { get; set; }
    public ushort Errors { get; set; }
    public DateTime Time { get; set; }
}