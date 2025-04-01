namespace DocoSoftTest.Application.Interfaces
{
    /// <summary>
    /// Logger class Interface
    /// </summary>
    public interface ILogger
    {
        // Log a message object
        void Debug(object message);
        void Info(object message);
        void Warn(object message);
        void Error(object message);
        void Fatal(object message);

        // Log a message object with exception
        void Debug(object message, Exception exception);
        void Info(object message, Exception exception);
        void Warn(object message, Exception exception);
        void Error(object message, Exception exception);
        void Fatal(object message, Exception exception);

        // Log an exception including stack trace
        void Error(Exception exception);
        void Fatal(Exception exception);
    }
}
