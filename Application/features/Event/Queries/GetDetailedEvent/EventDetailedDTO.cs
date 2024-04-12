namespace Application.features.Event.Queries.GetDetailedEvent
{
    public class EventDetailedDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}
