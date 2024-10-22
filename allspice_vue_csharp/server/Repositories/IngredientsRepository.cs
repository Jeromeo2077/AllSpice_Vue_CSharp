using System.Data.Common;

namespace allspice_vue_csharp.Repositories;

public class IngredientsRepository
{

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
INSERT into 
ingredients(name, quantity, creatorId, recipeId)
values(@Name, @Quantity, @CreatorId @RecipeId);

SELECT
ingredients.*,
accounts.*
From ingredients
JOIN accounts on ingredients.CreatorId = accounts.id
 WHERE ingredients.id = LAST_INSERT_ID();";

    Ingredient ingredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
    {
      ingredient.Creator = account;
      return ingredient;
    }, ingredientData).FirstOrDefault();

    return ingredient;
  }
}