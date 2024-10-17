namespace allspice_vue_csharp.Services;


public class RecipesService
{

  public RecipesService(RecipesRepository recipesRepository)
  {
    _recipesRepository = recipesRepository;
  }

  private readonly RecipesRepository _recipesRepository;

}