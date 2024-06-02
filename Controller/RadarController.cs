using Services;

namespace Controller
{
    public class RadarController
    {
        private RadarService _radarService;

        public RadarController()
        {
            _radarService = new();
        }

        public bool InsertRadar()
        {
            return _radarService.InsertRadar();
        }

        public bool GetAllRadar()
        {
            return _radarService.GetAllRadar();
        }
    }
}
