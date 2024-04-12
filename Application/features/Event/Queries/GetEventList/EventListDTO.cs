namespace Application.features.Event.Queries.GetEventList
{
    public class EventListDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}
