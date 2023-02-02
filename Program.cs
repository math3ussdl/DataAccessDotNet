using DataAccessDotNet.Repositories;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost,1433; Database=balta; User ID=sa; Password=MsSQL2023; Encrypt=False";
using var connection = new SqlConnection(connectionString);
Console.WriteLine("[Banco conectado!]");

Console.WriteLine("--------------------------");
Console.WriteLine("     CATEGORY MANAGER     ");
Console.WriteLine("--------------------------");
Console.WriteLine("l -> Listar categorias");
Console.WriteLine("lr -> Ler uma categoria");
Console.WriteLine("c -> Criar uma categoria");
Console.WriteLine("a -> Atualizar uma categoria");
Console.WriteLine("d -> Deletar uma categoria");
Console.WriteLine("e -> Sair!");

string? option = null;

while (true)
{
  Console.Write(">> ");
  option = Console.ReadLine();

    if (option is not null)
    {
      switch (option.ToLower())
      {
        case "l":
          connection.GetAllCategories();
          break;

        case "lr":
          bool idValid = false;
          string? id = null;

          do
          {
            Console.Write("Informe o Id: ");
            id = Console.ReadLine();

            idValid = Guid.TryParse(id, out _);

            if (id is not null && idValid)
            {
              break;
            }
            else
            {
              Console.WriteLine("Id inválido! Tente novamente.");
            }
          } while (id is null || idValid is false);

          connection.GetOneCategory(id);
          break;

        case "e":
          Console.WriteLine("Até logo...");
          Environment.Exit(0);
          break;

        default:
          Console.WriteLine("Invalid command! Try again...");
          break;
      }
    }
    else
    {
      Console.WriteLine("Invalid command! Try again...");
    }
}
