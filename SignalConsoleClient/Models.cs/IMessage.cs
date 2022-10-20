namespace SignalConsoleClient.Models.cs;

public interface IMessage
{
    public Guid Id { get; }
    public string User { get; }
    public string Message { get; }
    public DateTime Created { get; }
}