using System.ComponentModel.DataAnnotations;

namespace allspice_vue_csharp.Models;

public class Recipe
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  [MaxLength(255)]
  public string Title { get; set; }

  [MaxLength(5000)]
  public string Instructions { get; set; }

  [MaxLength(1000)]
  public string Img { get; set; }

  public string Category { get; set; }
  public string CreatorId { get; set; }
  public Account Creator { get; set; }
}