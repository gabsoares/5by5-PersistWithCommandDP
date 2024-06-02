using Newtonsoft.Json;
using System.Text;

namespace Models
{
    public class DadoRadar
    {
        public StringBuilder INSERT = new StringBuilder();
        public StringBuilder GETALL = new StringBuilder();

        [JsonProperty("concessionaria")]
        public string? Concessionaria { get; set; }

        [JsonProperty("ano_do_pnv_snv")]
        public string? AnoPNV { get; set; }

        [JsonProperty("tipo_de_radar")]
        public string? TipoRadar { get; set; }

        [JsonProperty("rodovia")]
        public string? Rodovia { get; set; }

        [JsonProperty("uf")]
        public string? UF { get; set; }

        [JsonProperty("km_m")]
        public string? KM { get; set; }

        [JsonProperty("municipio")]
        public string? Municipio { get; set; }

        [JsonProperty("tipo_pista")]
        public string? TipoPista { get; set; }

        [JsonProperty("sentido")]
        public string? Sentido { get; set; }

        [JsonProperty("situacao")]
        public string? Situacao { get; set; }

        [JsonProperty("data_da_inativacao")]
        public string[]? DataInativacao { get; set; }

        [JsonProperty("latitude")]
        public string? Latitude { get; set; }

        [JsonProperty("longitude")]
        public string? Longitude { get; set; }

        [JsonProperty("velocidade_leve")]
        public string? VelocidadeLeve { get; set; }

        public string Insert()
        {
            INSERT.Append("INSERT INTO DADOS_RADAR ");
            INSERT.Append("(CONCESSIONARIA, ANO_PNV,");
            INSERT.Append("TIPO_RADAR, RODOVIA,");
            INSERT.Append("UF, KM, MUNICIPIO,");
            INSERT.Append("TIPO_PISTA, SENTIDO, SITUACAO,");
            INSERT.Append("DATA_INATIVACAO, LATITUDE, LONGITUDE, VELOCIDADE_LEVE) ");
            INSERT.Append("VALUES (@CONCESSIONARIA, @ANO_PNV,");
            INSERT.Append("@TIPO_RADAR, @RODOVIA,");
            INSERT.Append("@UF, @KM, @MUNICIPIO,");
            INSERT.Append("@TIPO_PISTA, @SENTIDO, @SITUACAO,");
            INSERT.Append("@DATA_INATIVACAO, @LATITUDE, @LONGITUDE, @VELOCIDADE_LEVE)");

            return INSERT.ToString();
        }

        public string GetAll()
        {
            GETALL.Append("SELECT ");
            GETALL.Append("CONCESSIONARIA, ANO_PNV,");
            GETALL.Append("TIPO_RADAR, RODOVIA,");
            GETALL.Append("UF, KM, MUNICIPIO,");
            GETALL.Append("TIPO_PISTA, SENTIDO, SITUACAO,");
            GETALL.Append("DATA_INATIVACAO, LATITUDE, LONGITUDE, VELOCIDADE_LEVE ");
            GETALL.Append("FROM DADOS_RADAR");

            return GETALL.ToString();
        }

        public override string ToString()
        {
            string dataInativacaoString = string.Join(",", DataInativacao);
            return $"Concessionaria: {Concessionaria}\nAno_PNV: {AnoPNV}\n" +
                   $"Tipo Radar: {TipoRadar}\nRodovia: {Rodovia}\nUF: {UF}\nKM: {KM}\n" +
                   $"Municipio: {Municipio}\nTipo Pista: {TipoPista}\nSentido: {Sentido}\nSituacao: {Situacao}\n" +
                   $"Data Inativacao: {dataInativacaoString}\nLatitude: {Latitude}\nLongitude: {Longitude}\nVelocidade Leve: {VelocidadeLeve}";
        }
    }
}
