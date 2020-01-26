using System;
using System.Collections.Generic;
using AM.App.Services;
using AM.App.ViewModel;
using AM.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.Service.Controllers
{
    [Route("User")]
    [ApiController]
    public class ConsultaController : ControllerBase, IService<ConsultaModel>
    {
        private readonly ConsultaAppService _userAppService;

        public ConsultaController(ConsultaAppService userAppService)
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
        public ActionResult<ConsultaModel> Get(int id)
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
        public ActionResult<IList<ConsultaModel>> Get()
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
        public IActionResult Post(ConsultaModel obj)
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
        public IActionResult Put(int id, ConsultaModel obj)
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
