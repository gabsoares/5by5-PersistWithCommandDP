using Controller;
using Repositories.Command;

Receiver re = new();

#region[Insert]
Console.WriteLine(new RadarController().InsertRadar() ? "Sucesso ao inserir" : "Erro ao inserir");
#endregion

#region[GetAll]
Console.WriteLine(new RadarController().GetAllRadar() ? "Sucesso ao trazer os itens" : "Erro ao trazer os itens");
var radares = re.GetAll();
foreach (var radar in radares)
{
    Console.WriteLine(radar);
    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine();
}
#endregion