namespace allspice_vue_csharp.Services;

public class IngredientsService
{

  public IngredientsService(IngredientsRepository ingredientsRepository)
  {
    _ingredientsRespository = ingredientsRepository;
  }
  private readonly IngredientsRepository _ingredientsRespository;

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Ingredient ingredient = _ingredientsRespository.CreateIngredient(ingredientData);
    return ingredient;
  }
}