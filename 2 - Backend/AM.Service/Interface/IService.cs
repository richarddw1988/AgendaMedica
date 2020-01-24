using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DDDCore.Service.Interface
{
  public interface IService<T> where T : class
  {
    [HttpPost]
    IActionResult Post(T obj);

    [HttpPut("{id}")]
    IActionResult Put(int id, T obj);

    [HttpDelete("{id}")]
    IActionResult Delete(int id);

    [HttpGet("{id}", Name = "Get")]
    ActionResult<T> Get(int id);

    [HttpGet(Name = "Get")]
    ActionResult<IList<T>> Get();
  }
}
