using Dapper;
using DataAccessDotNet.Models;
using Microsoft.Data.SqlClient;

namespace DataAccessDotNet.Repositories;

public static class CategoryRepository
{
  public static void GetAllCategories(this SqlConnection connection)
  {
    var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
    foreach (var item in categories)
    {
      Console.WriteLine($"{item.Id} - {item.Title}");
    }
  }

  public static void GetOneCategory(this SqlConnection connection, string id)
  {
    var category = connection.QueryFirst<Category>("SELECT [Id], [Title] FROM [Category] WHERE [Id] = @id", new { id = id });
    Console.WriteLine($"{category.Id} - {category.Title}");
  }

  public static void CreateCategory(this SqlConnection connection, Category category)
  {
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
  }

  public static void UpdateCategory(this SqlConnection connection)
  {

  }
}
