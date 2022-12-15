using Framework.Core.Application;

namespace Epay.UserContext.ApplicationService.Contracts
{
    public class UserLoginCommand : Command
    {
        public string TerminalId { get; set; }
        public string PosSerialNumber { get; set; }
        public string Password { get; set; }

    }
}
