using System;
using System.Linq;
using Framework.Core.Application;

namespace Framework.Application
{
    public class ExceptionCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
    {
        private readonly ICommandHandler<TCommand> commandHandler;


        public ExceptionCommandHandler(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }


        public void Execute(TCommand command)
        {
            try
            {
                commandHandler.Execute(command);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 1 && ex.InnerExceptions.All(z => z.Message == ex.InnerException.Message))
                {
                    throw ex.Flatten().InnerException;
                }
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}