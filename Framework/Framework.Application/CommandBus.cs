using Framework.Core.Application;
using Framework.Core.DependencyInjection;

namespace Framework.Application
{
    public class CommandBus : ICommandBus
    {
        private readonly IDiContainer diContainer;


        public CommandBus(IDiContainer diContainer)
        {
            this.diContainer = diContainer;
        }


        public void Dispatch<TCommand>(TCommand command) where TCommand : Command
        {
            var commandHandler = diContainer.Resolve<ICommandHandler<TCommand>>();
            var transactionalDecorator = new TransactionalCommandHandler<TCommand>(commandHandler, diContainer);
            var exceptionDecorator = new ExceptionCommandHandler<TCommand>(transactionalDecorator);
            exceptionDecorator.Execute(command);
        }
    }
}