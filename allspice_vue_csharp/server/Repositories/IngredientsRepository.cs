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
ingredients(name, quantity, recipeId, creatorId, creator)
VALUES(@Name, @Quantity, @RecipeId, @CreatorId, @Creator);

SELECT * From ingredients WHERE id = LAST_INSERT_ID();";

    Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();

    return ingredient;
  }
}