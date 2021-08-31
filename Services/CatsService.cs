using System;
using System.Collections.Generic;
using petshop.Models;

namespace petshop.Services
{
  public class CatsService
  {
    internal IEnumerable<Cat> Get()
    {
      return FakeDB.Cats;
    }

    internal Cat Get(string id)
    {
      Cat found = FakeDB.Cats.Find(c => c.Id == id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Cat Create(Cat newCat)
    {
      FakeDB.Cats.Add(newCat);
      return newCat;
    }

    internal void Delete(string id)
    {
      int deleted = FakeDB.Cats.RemoveAll(c => c.Id == id);
      if (deleted == 0)
      {
        throw new Exception("Invalid Id");
      }
    }
  }
}