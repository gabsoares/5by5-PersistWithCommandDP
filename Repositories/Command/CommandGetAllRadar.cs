using Models;

namespace Repositories.Command
{
    public class CommandGetAllRadar : ICommand
    {
        private Receiver _getAllRadar;

        public CommandGetAllRadar(Receiver getAllRadar)
        {
            _getAllRadar = getAllRadar;
        }

        public void Execute()
        {
            _getAllRadar.GetAll();
        }
    }
}
