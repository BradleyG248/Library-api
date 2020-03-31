using System;
using System.Collections.Generic;
using library_api.Models;
using library_api.Repositories;

namespace library_api.Services
{
  public class LibrariesService
  {
    private readonly LibrariesRepository _repo;
    public LibrariesService(LibrariesRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Library> Get()
    {
      return _repo.Get();
    }
    public Library Get(int libraryId)
    {
      Library found = _repo.Get(libraryId);
      if (found == null)
      {
        throw new Exception("Can't find library by that ID");
      }
      return found;
    }
    public IEnumerable<Book> GetBooksByLibraryId(int id)
    {
      return _repo.GetBooksByLibraryId(id);
    }
    public Library Edit(Library newLibrary)
    {
      Library original = Get(newLibrary.Id);
      original.Name = newLibrary.Name != null ? newLibrary.Name : original.Name;
      original.Location = newLibrary.Location != null ? newLibrary.Location : original.Location;
      _repo.Edit(original);
      return original;
    }
    public Library Create(Library newLibrary)
    {
      Library created = _repo.Create(newLibrary);
      if (created == null)
      {
        throw new Exception("Create Request Failed");
      }
      return created;
    }
    public string Delete(int libraryId)
    {
      if (_repo.Delete(libraryId))
      {
        return "Successfully Deleted.";
      }
      throw new Exception("Delete Failed.");
    }
  }
}