namespace TimeTracker.Domain.Infrastructure.Commands
{
    public static class CommandBusExtensions
    {
        public static void Send(this ICommandBus commandBus, ICommand command)
        {
            commandBus.SendAsync(command).Wait();
        }
    }
}
