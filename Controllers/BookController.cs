using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using library_api.Models;
using library_api.Services;

namespace library_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly BooksService _bs;
    // NOTE Dependency Injection
    public BooksController(BooksService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
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
    public ActionResult<Book> Get(int id)
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
    public ActionResult<Book> Edit(int bookId, [FromBody] Book updatedBook)
    {
      try
      {
        updatedBook.Id = bookId;
        return Ok(_bs.Edit(updatedBook));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Book> Create([FromBody] Book newBook)
    {
      try
      {
        return Ok(_bs.Create(newBook));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{bookId}")]
    public ActionResult<Book> Delete(int bookId)
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
