using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost,1433; Database=balta; User ID=sa; Password=MsSQL2023; Encrypt=False";

using var connection = new SqlConnection(connectionString);

connection.Open();
Console.WriteLine("Connected!");

using SqlCommand command = new();
command.Connection = connection;
command.CommandType = System.Data.CommandType.Text;
command.CommandText = "SELECT [Id], [Title] FROM [Category]";

var reader = command.ExecuteReader();

while (reader.Read())
{
  // reader.GetGuid(int columnIndex)
  // reader.GetString(int columnIndex)
  // this reader contains methods for each c# data type
  Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
}
