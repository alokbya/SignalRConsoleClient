using System.Text;

namespace SignalConsoleClient.Models.cs;

public class Chatroom
{
    private Consumer _consumer;

    public Chatroom(Consumer? consumer)
    {
        _consumer = consumer ?? new Consumer();
        Messages = new List<BaseMessage>();
    }
    public List<BaseMessage> Messages { get; set; }

    public async Task DisplayMessages()
    {
        Console.Clear();
        StringBuilder sb = new StringBuilder();
        
        if (_consumer.Messages.Count != this.Messages.Count)
        {
            this.Messages = _consumer.Messages;
            foreach (BaseMessage message in Messages)
            {
                Console.WriteLine(message.ToString());
            }
        }
    }

    public async Task Run()
    {
        while (true)
        {
            await DisplayMessages();
            await _consumer.Send();
        }
    }
}