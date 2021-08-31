using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using petshop.Models;
using petshop.Services;

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
    private readonly CatsService _catsService;
    // Required Service to struct (Dependency Injection)
    public CatsController(CatsService catsService)
    {
      _catsService = catsService;
    }


    // GetAll through GET request
    [HttpGet]
    // returns HTTPResult (ok, badrequest, forbidden) of type collection (aka IEnumerable) of type Cat
    // ActionResult defines the response will be an HTTPRequest
    public ActionResult<IEnumerable<Cat>> Get()
    {
      try
      {
        IEnumerable<Cat> cats = _catsService.Get();
        // Ok is the HTTPResponse: 200 ok
        return Ok(cats);
      }
      catch (Exception err)
      {
        // BadRequest is HTTPResponse: 400 Bad Request
        return BadRequest(err.Message);
      }
    }


    // '/:id' : "{id}"
    [HttpGet("{id}")]
    // req.params.id : value caputured in parameters
    public ActionResult<Cat> Get(string id)
    {
      try
      {
        Cat found = _catsService.Get(id);
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
        Cat cat = _catsService.Create(newCat);
        return Ok(cat);
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
        _catsService.Delete(id);
        return Ok("Successfully Adopted out Cat");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}