using System.Collections.Generic;
using System.Data;
using Dapper;
using library_api.Models;
namespace library_api.Repositories
{
  public class AuthorsRepository
  {
    private readonly IDbConnection _db;
    public AuthorsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Author> Get()
    {
      string sql = "SELECT * FROM authors";
      return _db.Query<Author>(sql);
    }
    public Author Get(int Id)
    {
      string sql = "SELECT * FROM authors WHERE id = @Id";
      return _db.QueryFirstOrDefault<Author>(sql, new { Id });
    }
    public void Edit(Author newAuthor)
    {
      string sql = @"
      UPDATE authors
      SET 
        name = @Name
      WHERE id = @Id;
      ";
      _db.Execute(sql, newAuthor);
    }
    public Author Create(Author newAuthor)
    {
      string sql = @"
            INSERT INTO authors
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
      newAuthor.Id = _db.ExecuteScalar<int>(sql, newAuthor);
      return newAuthor;
    }
    public bool Delete(int Id)
    {
      string sql = "DELETE FROM authors WHERE id = @Id LIMIT 1";
      int deleted = _db.Execute(sql, new { Id });
      return deleted == 1;
    }
  }
}