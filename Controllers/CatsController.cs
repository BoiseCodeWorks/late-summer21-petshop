using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using petshop.Models;

namespace petshop.Controllers
{
  // Attributes
  // ApiController tells Dotnet register this class as a controller
  [ApiController]
  // super() : Route  ("[controller]") injects the name of the Controller 
  // ex: WeatherForecastController injects as WeatherForecast
  [Route("/api/[controller]")]
  public class CatsController : ControllerBase
  {


    // GetAll through GET request
    [HttpGet]
    // returns HTTPResult (ok, badrequest, forbidden) of type collection (aka IEnumerable) of type Cat
    // ActionResult defines the response will be an HTTPRequest
    public ActionResult<IEnumerable<Cat>> Get()
    {
      try
      {
        // Ok is the HTTPResponse: 200 ok
        return Ok(FakeDB.Cats);
      }
      catch (Exception err)
      {
        // BadRequest is HTTPResponse: 400 Bad Request
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    // req.params.id : value caputured in parameters
    public ActionResult<Cat> Get(string id)
    {
      try
      {
        Cat found = FakeDB.Cats.Find(c => c.Id == id);
        if (found == null)
        {
          throw new Exception("Invalid Id");
        }
        return Ok(found);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    // req.body : [FromBody]
    // C# will take the body and try to convert it into the type provided
    public ActionResult<Cat> Create([FromBody] Cat newCat)
    {
      try
      {
        FakeDB.Cats.Add(newCat);
        return Ok(newCat);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(string id)
    {
      try
      {
        // this is later handled in the actual DB
        int deleted = FakeDB.Cats.RemoveAll(c => c.Id == id);
        if (deleted == 0)
        {
          throw new Exception("Invalid Id");
        }
        return Ok("Successfully Deleted Cat");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}