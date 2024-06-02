using Repositories;

namespace Services
{
    public class RadarService
    {
        private RadarRepository _radarRepository;

        public RadarService()
        {
            _radarRepository = new();
        }

        public bool InsertRadar()
        {
            return _radarRepository.Insert();
        }

        public bool GetAllRadar()
        {
            return _radarRepository.GetAll();
        }
    }
}