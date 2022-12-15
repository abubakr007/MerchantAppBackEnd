namespace Epay.UserContext.Domain.Contracts.Events
{
    public class TokenGeneratedEvent
    {
        public string AccessToken { get; set; } = null!;
    }
}
