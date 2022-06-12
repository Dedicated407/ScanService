namespace ScanService.Client.Models;

public class GetTaskResponseModel
{
    public string Directory { get; set; }
    public ushort ProcessedFiles { get; set; }
    public ushort JSDetects { get; set; }
    public ushort RmRfDetects { get; set; }
    public ushort RunDllDetects { get; set; }
    public ushort Errors { get; set; }
    public int ExecutionTime { get; set; }

    public override string ToString()
    {
        return $"Directory: {Directory}\n" + 
               $"Processed files: {ProcessedFiles}\n" +
               $"JS detects: {JSDetects}\n" +
               $"rm -rf detects: {RmRfDetects}\n" +
               $"Rundll32 detects: {RunDllDetects}\n" +
               $"Errors: {Errors}\n" +
               $"Execution time: {ExecutionTime} sec";
    }
}