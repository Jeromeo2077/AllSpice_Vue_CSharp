using System.ComponentModel.DataAnnotations;

namespace allspice_vue_csharp.Models;

public class Ingredient
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  [MaxLength(255)]
  public string Name { get; set; }

  [MaxLength(255)]
  public string Quantity { get; set; }

  public int RecipeId { get; set; }
  public Account Creator { get; set; }
  public string CreatorId { get; set; }
}