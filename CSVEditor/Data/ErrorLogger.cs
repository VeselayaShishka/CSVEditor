namespace CSVEditor.Services;

public class ErrorLogger
{ 
    public static void LogError(Exception error)
    {
        string logFile = Path.Combine(
            Path.Combine(
                Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..")),
                "Logs"), 
            "ErrorLog.txt");
        
        using StreamWriter sw = File.AppendText(logFile);
        
        sw.WriteLine($"Error occured at: {DateTime.Now} | {error.Message}");
    }
}