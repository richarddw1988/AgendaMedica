using System;
using System.Collections.Generic;
using DDDCore.App.Services;
using DDDCore.App.ViewModel;
using DDDCore.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDCore.Service.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class UserController : ControllerBase, IService<UserModel>
  {
    private readonly UserAppService _userAppService;

    public UserController(UserAppService userAppService)
    {
      _userAppService = userAppService;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      try
      {
        _userAppService.Remove(id);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }     
    }

    [HttpGet("{id}", Name = "Get")]
    public ActionResult<UserModel> Get(int id)
    {
      try
      {
        return Ok(_userAppService.GetById(id));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
    }

    [HttpGet(Name = "GetList")]
    public ActionResult<IList<UserModel>> Get()
    {
      try
      {
        return Ok(_userAppService.GetAll());
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
    }

    [HttpPost]
    public IActionResult Post(UserModel obj)
    {
      try
      {
        _userAppService.Insert(obj);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UserModel obj)
    {
      try
      {
        _userAppService.Update(id, obj);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
    }
  }
}
