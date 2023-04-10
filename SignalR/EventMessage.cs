namespace SignalR
{
    public sealed class EventMessage
    {
        public string Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public EventMessage(string id, string title, DateTime utcNow)
        {
            Id = id;
            Title = title;
            CreatedOn = utcNow;
        }
    }
}
