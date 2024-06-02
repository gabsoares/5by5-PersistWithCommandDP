namespace Repositories.Command
{
    public class Invoker
    {
        private ICommand? _command;

        public void SetCommand(ICommand com)
        {
            _command = com;
        }

        public void ExecuteCommand()
        {
            _command?.Execute();
        }
    }
}
