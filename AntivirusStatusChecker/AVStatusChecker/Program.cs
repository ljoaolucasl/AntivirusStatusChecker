using AntivirusStatusChecker.AVStatusChecker;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (OperatingSystem.IsWindows())
            AVStatusChecker.CheckAntivirusStatus();
    }
}