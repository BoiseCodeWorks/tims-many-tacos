using System;
using System.Collections.Generic;
using timsTacos.Models;
using timsTacos.Repositories;

namespace timsTacos.Services
{
  public class TacoIngredientsService
  {

    private readonly TacoIngredientsRepository _repo;

    public TacoIngredientsService(TacoIngredientsRepository repo)
    {
      _repo = repo;
    }

    internal TacoIngredient Create(TacoIngredient newTacoIngredient)
    {
      int id = _repo.Create(newTacoIngredient);
      newTacoIngredient.Id = id;
      return newTacoIngredient;
    }

    internal IEnumerable<TacoIngredientViewModel> GetIngsByTacoId(int tacoId)
    {
      return _repo.GetIngsByTacoId(tacoId);
    }
    public TacoIngredient Get(int Id)
    {
      TacoIngredient exists = _repo.GetById(Id);
      if (exists == null) { throw new Exception("Invalid ingredient mi amigo"); }
      return exists;
    }

    internal TacoIngredient Delete(int id)
    {
      TacoIngredient exists = Get(id);
      _repo.Delete(id);
      return exists;
    }
  }
}