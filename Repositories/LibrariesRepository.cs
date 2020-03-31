using System.Collections.Generic;
using System.Data;
using Dapper;
using library_api.Models;
namespace library_api.Repositories
{
  public class LibrariesRepository
  {
    private readonly IDbConnection _db;
    public LibrariesRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Library> Get()
    {
      string sql = "SELECT * FROM libraries";
      return _db.Query<Library>(sql);
    }
    public Library Get(int Id)
    {
      string sql = "SELECT * FROM libraries WHERE id = @Id";
      return _db.QueryFirstOrDefault<Library>(sql, new { Id });
    }
    public IEnumerable<Book> GetBooksByLibraryId(int Id)
    {
      string sql = "SELECT * FROM books WHERE libraryId = @Id";
      return _db.Query<Book>(sql, new { Id });
    }
    public void Edit(Library newLibrary)
    {
      string sql = @"
      UPDATE libraries
      SET 
        name = @Name,
        location = @Location
      WHERE id = @Id;
      ";
      _db.Execute(sql, newLibrary);
    }
    public Library Create(Library newLibrary)
    {
      string sql = @"
            INSERT INTO libraries
            (name, location)
            VALUES
            (@Name, @Location);
            SELECT LAST_INSERT_ID();
            ";
      newLibrary.Id = _db.ExecuteScalar<int>(sql, newLibrary);
      return newLibrary;
    }
    public bool Delete(int Id)
    {
      string sql = "DELETE FROM libraries WHERE id = @Id LIMIT 1";
      int deleted = _db.Execute(sql, new { Id });
      return deleted == 1;
    }
  }
}