using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using library_api.Models;
using library_api.Services;

namespace library_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BookAuthorsController : ControllerBase
  {
    private readonly BookAuthorsService _bs;
    // NOTE Dependency Injection
    public BookAuthorsController(BookAuthorsService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BookAuthor>> Get()
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
    public ActionResult<BookAuthor> Get(int id)
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
    [HttpPut("{bookId}")]
    public ActionResult<BookAuthor> Edit(int bookId, [FromBody] BookAuthor updatedBookAuthor)
    {
      try
      {
        updatedBookAuthor.Id = bookId;
        return Ok(_bs.Edit(updatedBookAuthor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<BookAuthor> Create([FromBody] BookAuthor newBookAuthor)
    {
      try
      {
        return Ok(_bs.Create(newBookAuthor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{bookId}")]
    public ActionResult<BookAuthor> Delete(int bookId)
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
