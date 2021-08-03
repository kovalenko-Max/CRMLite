using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace CRMLite.TransactionStoreAPI.Serilog
{
    public class SerilogInitialize
    {
        private readonly long _fileSizeLimitBytes = 100000000;
        private readonly int _retainedFileCountLimit = 10;
        private readonly string _fileName = "TransactionStoreLog.txt";
        private readonly string _path = @"C:\TransactionStoreLogs\";

        public SerilogInitialize(LogEventLevel level)
        {
            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = level;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(_path+_fileName,
                LogEventLevel.Information,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: _retainedFileCountLimit,
                fileSizeLimitBytes: _fileSizeLimitBytes,
                rollOnFileSizeLimit: true)
                 .MinimumLevel.ControlledBy(levelSwitch)
                 .CreateLogger();
        }
    }
}
