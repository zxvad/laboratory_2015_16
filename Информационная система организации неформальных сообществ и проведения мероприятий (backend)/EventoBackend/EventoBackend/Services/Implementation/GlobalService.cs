namespace EventoBackend.Services.Implementation
{
    public class GlobalService
    {
        public IEventService EventService { get; set; }
        public IGroupService GroupService { get; set; }
        public IParticipantService ParticipantService { get; set; } 
    }
}