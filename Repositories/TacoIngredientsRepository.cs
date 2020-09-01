using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using timsTacos.Models;

namespace timsTacos.Repositories
{
  public class TacoIngredientsRepository
  {
    private readonly IDbConnection _db;

    public TacoIngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(TacoIngredient newTacoIngredient)
    {
      string sql = @"
        INSERT INTO tacoingredients
        (tacoId, ingredientId)
        VALUES
        (@TacoId, @IngredientId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newTacoIngredient);
    }

    internal IEnumerable<TacoIngredientViewModel> GetIngsByTacoId(int tacoId)
    {
      string sql = @"
        SELECT 
            ingredients.*,
            tacoingredients.id as tacoIngId
        FROM tacoingredients
        INNER JOIN ingredients ON ingredients.id = tacoingredients.ingredientId 
        WHERE(tacoingredients.tacoId = @tacoId)";
      return _db.Query<TacoIngredientViewModel>(sql, new { tacoId });
    }


    //this way uses aliasing on the table names
    // internal IEnumerable<TacoIngredientViewModel> GetIngsByTacoId(int tacoId)
    // {
    //   string sql = @"
    //     SELECT 
    //         i.*,
    //         ti.id as tacoIngId,
    //         t.name as tacoName
    //     FROM tacoingredients ti
    //     INNER JOIN ingredients i ON i.id = ti.ingredientId 
    //     INNER JOIN tacos t on t.id = ti.tacoId
    //     WHERE(ti.tacoId = @tacoId)";
    //   return _db.Query<TacoIngredientViewModel>(sql, new { tacoId });
    // }

    internal TacoIngredient GetById(int id)
    {
      string sql = "SELECT * FROM tacoingredients WHERE id = @Id";
      return _db.QueryFirstOrDefault<TacoIngredient>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM tacoingredients WHERE id = @Id";
      _db.Execute(sql, new { id });

    }
  }
}