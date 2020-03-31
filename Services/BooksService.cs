using System;
using System.Collections.Generic;
using library_api.Models;
using library_api.Repositories;

namespace library_api.Services
{
  public class BooksService
  {
    private readonly BooksRepository _repo;
    public BooksService(BooksRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Book> Get()
    {
      return _repo.Get();
    }
    public Book Get(int bookId)
    {
      Book found = _repo.Get(bookId);
      if (found == null)
      {
        throw new Exception("Can't find book by that ID");
      }
      return found;
    }
    public Book Edit(Book newBook)
    {
      Book original = Get(newBook.Id);
      original.Title = newBook.Title != null ? newBook.Title : original.Title;
      original.Author = newBook.Author != null ? newBook.Author : original.Author;
      original.Description = newBook.Description != null ? newBook.Description : original.Description;
      original.LibraryId = newBook.LibraryId != 0 ? newBook.LibraryId : original.LibraryId;
      _repo.Edit(original);
      return original;
    }
    public Book Create(Book newBook)
    {
      Book created = _repo.Create(newBook);
      if (created == null)
      {
        throw new Exception("Create Request Failed");
      }
      return created;
    }
    public string Delete(int bookId)
    {
      if (_repo.Delete(bookId))
      {
        return "Successfully Deleted.";
      }
      throw new Exception("Delete Failed.");
    }
  }
}