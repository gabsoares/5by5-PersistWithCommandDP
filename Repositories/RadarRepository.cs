using Microsoft.Data.SqlClient;
using Repositories.Command;

namespace Repositories
{
    public class RadarRepository
    {

        private Receiver _radar;
        private Invoker _invoker;

        private SqlConnection _conn;

        public RadarRepository()
        {
            _radar = new Receiver();
            _invoker = new Invoker();
        }

        public bool Insert()
        {
            bool result = false;
            ICommand insertRadar = new CommandInsertRadar(_radar);

            try
            {
                _invoker.SetCommand(insertRadar);
                _invoker.ExecuteCommand();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro " + ex.Source?.ToString());
            }

            return result;
        }

        public bool GetAll()
        {
            bool result = false;
            ICommand getAllRadar = new CommandGetAllRadar(_radar);

            try
            {
                _invoker.SetCommand(getAllRadar);
                _invoker.ExecuteCommand();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro " + ex.Source?.ToString());
            }

            return result;
        }

    }
}
