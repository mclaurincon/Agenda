// See https://aka.ms/new-console-template for more information
using Consumidorapi;
using Flurl.Http;

Console.WriteLine("Hello, World!");

string path = "https://localhost:7085/";
#region "Tarefas"
Item tarefa1 = new Item();
tarefa1.Id= 1;
tarefa1.Nome = "Fazer compras";
tarefa1.Feito = true;

Item tarefa2 = new Item();
tarefa2.Id = 2;
tarefa2.Nome = "Comprar remedio";
tarefa2.Feito = false;

#endregion
#region Post + Listar
//Gerar uma tarefa 
string endpoint = path + "api/Tarefas";

//usar o flurl (post) 
await endpoint.PostJsonAsync(tarefa1);
await endpoint.PostJsonAsync(tarefa2);

//Ler a lista (Listar)
IEnumerable<Item> listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach(var item in listaTarefas)
{
    Console.WriteLine($"A tarefa foi {item.Nome} está {item.Feito}");

}
#endregion

#region alterar
Console.WriteLine("Digite um ID");
//Alterar a lista (update)
//não foi considerado uso de letras, apenas numeros

int id = Convert.ToInt32(Console.ReadLine());
string endpointalterar = path + $"api/Tarefas/{id}";
Item tarefa3 = new Item(); 
tarefa3.Id = 1;
tarefa3.Nome = "Comprar papel";
tarefa3.Feito = false;

await endpointalterar.PutJsonAsync(tarefa3);

//Ler a lista 
listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listaTarefas)
{
    Console.WriteLine($"A tarefa foi {item.Nome} está {item.Feito}");

}
#endregion

#region Deletar
//Deletar um item (Delete)
string endpointdeletar = path + $"api/Tarefas/1";
await endpointdeletar.DeleteAsync();

//Ler a lista
listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listaTarefas)
{
    Console.WriteLine($"A tarefa foi {item.Nome} está {item.Feito}");

}
#endregion
Console.WriteLine("Aperta qualquer tecla para finalizar a aplicacao");
Console.Read();

