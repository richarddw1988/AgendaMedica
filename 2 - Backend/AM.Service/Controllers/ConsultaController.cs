using System;
using System.Collections.Generic;
using System.Linq;
using AM.App.Services;
using AM.App.ViewModel;
using AM.Domain.Exceptions;
using AM.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.Service.Controllers
{
    [Route("Consulta")]
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

        [HttpGet(Name = "GetList"), Route("GetList")]
        public ActionResult<IList<ConsultaModel>> GetAll()
        {
            try
            {
                return Ok(_userAppService.GetAll().ToList());
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
            catch (BusinessException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
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
            catch (BusinessException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
