namespace DataAccessDotNet.Models;

public class Category
{
  public Category()
  {
    Id = Guid.NewGuid();
  }

  public Category(string title, string url, string summary, int order, string description, bool featured)
  {
    Id = Guid.NewGuid();
    Title = title;
    Url = url;
    Summary = summary;
    Order = order;
    Description = description;
    Featured = featured;
  }

  public Guid Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Url { get; set; } = string.Empty;
  public string Summary { get; set; } = string.Empty;
  public int Order { get; set; }
  public string Description { get; set; } = string.Empty;
  public bool Featured { get; set; }
}
