using Microsoft.Data.SqlClient;
using System.Data;
using Models;
namespace Repositories.Command
{
    public class Receiver
    {
        private string _strConn = "Data Source = 127.0.0.1; Initial Catalog=5BY5-PERSIST; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True;";
        SqlConnection conn;

        public Receiver()
        {
            conn = new SqlConnection(_strConn);
            conn.Open();
        }

        public bool InsertData(List<DadoRadar> l)
        {
            bool result = false;
            foreach (var item in l)
            {
                string[]? dataInativacao = item.DataInativacao;
                string? dataInativacaoString = string.Join(",", dataInativacao);
                DadoRadar dadoRadar = new DadoRadar();

                try
                {
                    SqlCommand cmd = new(dadoRadar.Insert(), conn);
                    cmd.Parameters.Add("@CONCESSIONARIA", SqlDbType.VarChar, 50).Value = item.Concessionaria;
                    cmd.Parameters.Add("@ANO_PNV", SqlDbType.Char, 4).Value = item.AnoPNV;
                    cmd.Parameters.Add("@TIPO_RADAR", SqlDbType.VarChar, 50).Value = item.TipoRadar;
                    cmd.Parameters.Add("@RODOVIA", SqlDbType.VarChar, 50).Value = item.Rodovia;
                    cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = item.UF;
                    cmd.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = item.KM;
                    cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar, 50).Value = item.Municipio;
                    cmd.Parameters.Add("@TIPO_PISTA", SqlDbType.VarChar, 50).Value = item.TipoPista;
                    cmd.Parameters.Add("@SENTIDO", SqlDbType.VarChar, 50).Value = item.Sentido;
                    cmd.Parameters.Add("@SITUACAO", SqlDbType.VarChar, 50).Value = item.Situacao;
                    cmd.Parameters.AddWithValue("@DATA_INATIVACAO", (object)dataInativacaoString ?? DBNull.Value);
                    cmd.Parameters.Add("@LATITUDE", SqlDbType.VarChar, 50).Value = item.Latitude;
                    cmd.Parameters.Add("@LONGITUDE", SqlDbType.VarChar, 50).Value = item.Longitude;
                    cmd.Parameters.Add("@VELOCIDADE_LEVE", SqlDbType.VarChar, 50).Value = item.VelocidadeLeve;
                    cmd.ExecuteNonQuery();

                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao inserir: " + e.Source?.ToString());
                }
            }
            conn.Close();
            return result;
        }

        public List<DadoRadar> GetAll()
        {
            List<DadoRadar> l = new();
            DadoRadar dadoRadar = new DadoRadar();
            try
            {
                SqlCommand cmd = new(dadoRadar.GetAll(), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DadoRadar d = new()
                    {
                        Concessionaria = reader.GetString(0),
                        AnoPNV = reader.GetString(1),
                        TipoRadar = reader.GetString(2),
                        Rodovia = reader.GetString(3),
                        UF = reader.GetString(4),
                        KM = reader.GetString(5),
                        Municipio = reader.GetString(6),
                        TipoPista = reader.GetString(7),
                        Sentido = reader.GetString(8),
                        Situacao = reader.GetString(9),
                        DataInativacao = reader.GetString(10).Split(","),
                        Latitude = reader.GetString(11),
                        Longitude = reader.GetString(12),
                        VelocidadeLeve = reader.GetString(13)
                    };

                    l.Add(d);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Source?.ToString());
            }
            finally
            {
                conn.Close();
            }
            return l;
        }
    }
}