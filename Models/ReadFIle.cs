using Models;
using Newtonsoft.Json;

namespace Repositories
{
    public class ReadFile
    {
        public static List<DadoRadar> GetData()
        {
            StreamReader sr = new(@"C:\Users\adm\Documents\5by5-TrabalhoDesignPattern\5by5-Persist\radar.json");
            string jsonString = sr.ReadToEnd();

            var lst = JsonConvert.DeserializeObject<Radar>(jsonString);

            if (lst != null) return lst.ListaDadosRadar;
            return null;
        }
    }
}
