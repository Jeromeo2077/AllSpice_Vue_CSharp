
using System.Collections.Frozen;

namespace allspice_vue_csharp.Repositories;


public class RecipesRepository
{

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO
    recipes(title, instructions, img, category, creatorId)
    VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);

    SELECT
    recipes.*,
    accounts.*
    FROM recipes
    JOIN accounts ON recipes.CreatorId = accounts.id
    WHERE recipes.id = LAST_INSERT_ID();";

    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, recipeData).FirstOrDefault();

    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    SELECT 
    recipes.*,
    accounts.*
    FROM recipes
    JOIN accounts on recipes.CreatorId = accounts.id;";

    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;
    }).ToList();

    return recipes;
  }
}

