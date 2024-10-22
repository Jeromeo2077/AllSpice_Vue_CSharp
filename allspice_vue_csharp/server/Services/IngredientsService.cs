namespace allspice_vue_csharp.Services;

public class IngredientsService
{

  public IngredientsService(IngredientsRepository ingredientsRepository)
  {
    _ingredientsRespository = ingredientsRepository;
  }
  private readonly IngredientsRepository _ingredientsRespository;
}