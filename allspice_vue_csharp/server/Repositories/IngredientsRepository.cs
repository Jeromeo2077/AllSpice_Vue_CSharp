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
INSERT INTO 
ingredients(name, quantity, recipeId)
VALUES(@Name, @Quantity, @RecipeId);

SELECT
ingredients.*,
accounts.*
FROM ingredients
JOIN accounts ON accounts.id = CreatorId
WHERE ingredients.id = LAST_INSERT_ID();";

    Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();

    return ingredient;
  }
}