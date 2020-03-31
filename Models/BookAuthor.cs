using System;

namespace library_api.Models
{
  public class BookAuthor
  {
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public int BookId { get; set; }

    public class DBBookAuthor : BookAuthor
    {
      public int baId { get; set; }
    }

  }
}
