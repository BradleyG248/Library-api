using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using library_api.Models;
using library_api.Services;

namespace library_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthorsController : ControllerBase
  {
    private readonly AuthorsService _bs;
    private readonly BookAuthorsService _bas;
    // NOTE Dependency Injection
    public AuthorsController(AuthorsService bs, BookAuthorsService bas)
    {
      _bs = bs;
      _bas = bas;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Author>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Author> Get(int id)
    {
      try
      {
        return Ok(_bs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/books")]
    public ActionResult<Author> GetBooks(int id)
    {
      try
      {
        return Ok(_bas.GetBooksByAuthorId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{bookId}")]
    public ActionResult<Author> Edit(int bookId, [FromBody] Author updatedAuthor)
    {
      try
      {
        updatedAuthor.Id = bookId;
        return Ok(_bs.Edit(updatedAuthor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Author> Create([FromBody] Author newAuthor)
    {
      try
      {
        return Ok(_bs.Create(newAuthor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{bookId}")]
    public ActionResult<Author> Delete(int bookId)
    {
      try
      {
        return Ok(_bs.Delete(bookId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
