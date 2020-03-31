using System.Collections.Generic;
using System.Data;
using Dapper;
using library_api.Models;
namespace library_api.Repositories
{
  public class BooksRepository
  {
    private readonly IDbConnection _db;
    public BooksRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Book> Get()
    {
      string sql = "SELECT * FROM books";
      return _db.Query<Book>(sql);
    }
    public Book Get(int Id)
    {
      string sql = "SELECT * FROM books WHERE id = @Id";
      return _db.QueryFirstOrDefault<Book>(sql, new { Id });
    }
    public void Edit(Book newBook)
    {
      string sql = @"
      UPDATE books
      SET 
        title = @Title,
        description = @Description,
        author = @Author,
        libraryId = @LibraryId
      WHERE id = @Id;
      ";
      _db.Execute(sql, newBook);
    }
    public Book Create(Book newBook)
    {
      string sql = @"
            INSERT INTO books
            (title, description, author, libraryId)
            VALUES
            (@Title, @Description, @Author, @LibraryId);
            SELECT LAST_INSERT_ID();
            ";
      newBook.Id = _db.ExecuteScalar<int>(sql, newBook);
      return newBook;
    }
    public bool Delete(int Id)
    {
      string sql = "DELETE FROM books WHERE id = @Id LIMIT 1";
      int deleted = _db.Execute(sql, new { Id });
      return deleted == 1;
    }
  }
}