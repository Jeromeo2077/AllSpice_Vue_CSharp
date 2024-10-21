
using System.Collections.Frozen;
using Microsoft.AspNetCore.Mvc.Filters;

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

  internal Recipe GetRecipeById(int recipeId)
  {
    string sql = @"
SELECT
recipes.*,
accounts.* 
FROM recipes
JOIN accounts ON recipes.CreatorId = accounts.id
WHERE recipes.Id = @recipeId;";

    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, new { recipeId }).FirstOrDefault();

    return recipe;
  }

  internal Recipe UpdateRecipe(Recipe recipe)
  {
    string sql = @"
    UPDATE recipes
    SET
    title = @Title,
    instructions = @Instructions,
    img = @Img,
    category = @Category
    WHERE Id = @Id
    LIMIT 1;";

    int rowsAffected = _db.Execute(sql, recipe);

    if (rowsAffected == 0)
    {
      throw new Exception("Error: No recipes were updated!");
    }

    if (rowsAffected > 1)
    {
      throw new Exception("Error: Multiple recipes were updated!");
    }

    return recipe;
  }

  internal void DeleteRecipe(int recipeId)
  {
    string sql = @"
   DELETE FROM recipes WHERE recipes.id = @recipeId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { recipeId });

    if (rowsAffected == 0)
    {
      throw new Exception("Error: No recipes were deleted!");
    }

    if (rowsAffected > 1)
    {
      throw new Exception("Error: Multiple recipes were deleted!");
    }
  }
}

