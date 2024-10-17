namespace allspice_vue_csharp.Controllers;

public class RecipesController : ControllerBase
{

  public RecipesController(RecipesService recipesService)
  {
    _recipesService = recipesService;
  }

  private readonly RecipesService _recipesService;

}