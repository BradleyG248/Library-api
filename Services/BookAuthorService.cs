using System;
using System.Collections.Generic;
using library_api.Models;
using library_api.Repositories;

namespace library_api.Services
{
  public class BookAuthorsService
  {
    private readonly BookAuthorsRepository _repo;
    public BookAuthorsService(BookAuthorsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<BookAuthor> Get()
    {
      return _repo.Get();
    }
    public BookAuthor Get(int authorId)
    {
      BookAuthor found = _repo.Get(authorId);
      if (found == null)
      {
        throw new Exception("Can't find index by that ID");
      }
      return found;
    }
    public IEnumerable<Book> GetBooksByAuthorId(int authorId)
    {
      return _repo.GetBooksByAuthorId(authorId);
    }
    public IEnumerable<Author> GetAuthorsByBookId(int bookId)
    {
      return _repo.GetAuthorsByBookId(bookId);
    }
    public BookAuthor Edit(BookAuthor newBookAuthor)
    {
      BookAuthor original = Get(newBookAuthor.Id);
      original.AuthorId = newBookAuthor.AuthorId != 0 ? newBookAuthor.AuthorId : original.AuthorId;
      original.BookId = newBookAuthor.BookId != 0 ? newBookAuthor.BookId : original.BookId;
      _repo.Edit(original);
      return original;
    }
    public BookAuthor Create(BookAuthor newBookAuthor)
    {
      BookAuthor created = _repo.Create(newBookAuthor);
      if (created == null)
      {
        throw new Exception("Create Request Failed");
      }
      return created;
    }
    public string Delete(int authorId)
    {
      if (_repo.Delete(authorId))
      {
        return "Successfully Deleted.";
      }
      throw new Exception("Delete Failed.");
    }
  }
}