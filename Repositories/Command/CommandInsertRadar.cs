using Models;

namespace Repositories.Command
{
    public class CommandInsertRadar : ICommand
    {
        private Receiver _insertRadar;

        public CommandInsertRadar(Receiver insertRadar)
        {
            _insertRadar = insertRadar;
        }

        public void Execute()
        {
            var lst = ReadFile.GetData();
            _insertRadar.InsertData(lst);
        }
    }
}
