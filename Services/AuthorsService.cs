using System;
using System.Collections.Generic;
using library_api.Models;
using library_api.Repositories;

namespace library_api.Services
{
  public class AuthorsService
  {
    private readonly AuthorsRepository _repo;
    public AuthorsService(AuthorsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Author> Get()
    {
      return _repo.Get();
    }
    public Author Get(int authorId)
    {
      Author found = _repo.Get(authorId);
      if (found == null)
      {
        throw new Exception("Can't find author by that ID");
      }
      return found;
    }
    public Author Edit(Author newAuthor)
    {
      Author original = Get(newAuthor.Id);
      original.Name = newAuthor.Name != null ? newAuthor.Name : original.Name;
      _repo.Edit(original);
      return original;
    }
    public Author Create(Author newAuthor)
    {
      Author created = _repo.Create(newAuthor);
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