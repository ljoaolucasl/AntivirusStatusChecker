using AntivirusStatusChecker.AVStatusChecker;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        if (OperatingSystem.IsWindows())
            await AVStatusChecker.CheckAntivirusStatusAsync();
    }
}