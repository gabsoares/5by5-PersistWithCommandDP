using Newtonsoft.Json;

namespace Models
{
    public class Radar
    {
        [JsonProperty("radar")]
        public List<DadoRadar>? ListaDadosRadar { get; set; }
    }
}