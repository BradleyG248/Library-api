using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using library_api.Models;
using library_api.Services;

namespace library_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LibrariesController : ControllerBase
  {
    private readonly LibrariesService _ls;
    // NOTE Dependency Injection
    public LibrariesController(LibrariesService ls)
    {
      _ls = ls;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Library>> Get()
    {
      try
      {
        return Ok(_ls.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Library> Get(int id)
    {
      try
      {
        return Ok(_ls.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/books")]
    public ActionResult<IEnumerable<Book>> GetBooks(int id)
    {
      try
      {
        return Ok(_ls.GetBooksByLibraryId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{libraryId}")]
    public ActionResult<Library> Edit(int libraryId, [FromBody] Library updatedLibrary)
    {
      try
      {
        updatedLibrary.Id = libraryId;
        return Ok(_ls.Edit(updatedLibrary));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Library> Create([FromBody] Library newLibrary)
    {
      try
      {
        return Ok(_ls.Create(newLibrary));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{libraryId}")]
    public ActionResult<Library> Delete(int libraryId)
    {
      try
      {
        return Ok(_ls.Delete(libraryId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
