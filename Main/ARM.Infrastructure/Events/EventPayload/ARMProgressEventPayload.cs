namespace ARM.Infrastructure.Events.EventPayload
{
    /// <summary>
    /// Класс що передає значення прогресу всім слухачам події.
    /// </summary>
    public class ARMProgressEventPayload
    {
        public int Progress { get; set; }
    }
}