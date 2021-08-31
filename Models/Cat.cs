using System;
using System.ComponentModel.DataAnnotations;

namespace petshop.Models
{
  public class Cat
  {
    //FAKING IDS for NOW
    public string Id { get; set; }
    // DataAnnotations apply to value below them
    [Required]
    [MinLength(3)]
    [MaxLength(15)]
    public string Name { get; set; }
    [Range(0, int.MaxValue)]
    public int Age { get; set; }
    public string Mood { get; set; }
    public Cat(string name, int age, string mood)
    {
      Name = name;
      Age = age;
      Mood = mood;
      // creates a unique id
      Id = Guid.NewGuid().ToString();
    }
  }
}