


namespace allspice_vue_csharp.Services;


public class RecipesService
{

  public RecipesService(RecipesRepository Repository)
  {
    _repository = Repository;
  }

  private readonly RecipesRepository _repository;



  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repository.CreateRecipe(recipeData);
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repository.GetAllRecipes();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _repository.GetRecipeById(recipeId) ?? throw new Exception($"The Recipe ID {recipeId} is invalid");
    return recipe;
  }
}