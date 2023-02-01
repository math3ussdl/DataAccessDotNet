using Dapper;
using DataAccessDotNet.Models;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost,1433; Database=balta; User ID=sa; Password=MsSQL2023; Encrypt=False";

var category = new Category(
  title: "Amazon AWS",
  url: "amazon",
  summary: "AWS Cloud",
  order: 8,
  description: "Cloud AWS Services",
  featured: false
);

string insertCategorySQL = @"
  INSERT INTO [Category]
  (
    [Id],
    [Title],
    [Url],
    [Summary],
    [Order],
    [Description],
    [Featured]
  )
  VALUES (
    @Id,
    @Title,
    @Url,
    @Summary,
    @Order,
    @Description,
    @Featured
  )
";

using var connection = new SqlConnection(connectionString);

// Create a new category
int rows = connection.Execute(insertCategorySQL, new
{
  category.Id,
  category.Title,
  category.Url,
  category.Summary,
  category.Order,
  category.Description,
  category.Featured
});

Console.WriteLine($"Category with Id {category.Id} successfully created!");
Console.WriteLine($"Rows affected: {rows}");

// List all categories from database
var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
foreach (var item in categories)
{
  Console.WriteLine($"{item.Id} - {item.Title}");
}
