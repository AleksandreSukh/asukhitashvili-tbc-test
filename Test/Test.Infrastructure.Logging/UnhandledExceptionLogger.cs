namespace Test.Infrastructure.Logging
{
    public class UnhandledExceptionLogger
    {
        public void LogUnhandledException(Exception e)
        {
            System.Diagnostics.Debug.WriteLine($"Unhandled exception: {e.Message}");
        }
    }
}
