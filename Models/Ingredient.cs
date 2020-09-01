namespace timsTacos.Models
{
  public class Ingredient
  {
    public int Id { get; set; }
    public int KCal { get; set; }
    public string Name { get; set; }
  }

  public class TacoIngredientViewModel : Ingredient
  {
    public int TacoIngId { get; set; }
    public string TacoName { get; set; }
  }
}