using Application.response;

namespace Application.features.Event.Commands
{
    public class EventCommandResponse : BaseResponse
    {
        public EventCommandResponse() : base()
        {
            
        }

        public EventDTO EventDTO { get; set; }
    }
}
