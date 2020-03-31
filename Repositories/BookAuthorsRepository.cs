using System.Collections.Generic;
using System.Data;
using Dapper;
using library_api.Models;
namespace library_api.Repositories
{
  public class BookAuthorsRepository
  {
    private readonly IDbConnection _db;
    public BookAuthorsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<BookAuthor> Get()
    {
      string sql = "SELECT * FROM bookauthors";
      return _db.Query<BookAuthor>(sql);
    }
    public BookAuthor Get(int Id)
    {
      string sql = "SELECT * FROM bookauthors WHERE id = @Id";
      return _db.QueryFirstOrDefault<BookAuthor>(sql, new { Id });
    }
    public IEnumerable<Book> GetBooksByAuthorId(int Id)
    {
      string sql = @"
      SELECT s.* FROM bookauthors ba
        INNER JOIN books s ON s.id = ba.bookId
        WHERE authorId = @Id;
      ";
      return _db.Query<Book>(sql, new { Id });
    }
    public IEnumerable<Author> GetAuthorsByBookId(int Id)
    {
      string sql = @"
      SELECT s.* FROM bookauthors ba
        INNER JOIN authors s ON s.id = ba.authorId
        WHERE bookId = @Id;
      ";
      return _db.Query<Author>(sql, new { Id });
    }
    public void Edit(BookAuthor newBookAuthor)
    {
      string sql = @"
      UPDATE bookauthors
      SET 
        bookId = @BookId,
        authorId = @AuthorId
      WHERE id = @Id;
      ";
      _db.Execute(sql, newBookAuthor);
    }
    public BookAuthor Create(BookAuthor newBookAuthor)
    {
      string sql = @"
            INSERT INTO bookauthors
            (bookId, authorId)
            VALUES
            (@BookId, @AuthorId);
            SELECT LAST_INSERT_ID();
            ";
      newBookAuthor.Id = _db.ExecuteScalar<int>(sql, newBookAuthor);
      return newBookAuthor;
    }
    public bool Delete(int Id)
    {
      string sql = "DELETE FROM bookauthors WHERE id = @Id LIMIT 1";
      int deleted = _db.Execute(sql, new { Id });
      return deleted == 1;
    }
  }
}