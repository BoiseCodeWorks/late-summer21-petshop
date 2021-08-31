using System.Collections.Generic;
using petshop.Models;

namespace petshop
{
  static public class FakeDB
  {
    static public List<Cat> Cats { get; set; } = new List<Cat>() { new Cat("Garfield", 12, "hungry") };
  }
}