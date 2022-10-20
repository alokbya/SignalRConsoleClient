namespace SignalConsoleClient.Models.cs;

public class BaseMessage
{
    public BaseMessage(Guid id, string user, string message)
    {
        Id = id;
        User = user;
        Message = message;
        Created = DateTime.Now;
    }

    #region Public Properties
    public Guid Id { get; }
    public string User { get; }
    public string Message { get; }
    public DateTime Created { get; }
    #endregion
    
    public override string ToString()
    {
        return $"{User}: {Message}";
    }
}