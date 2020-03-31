using System;

namespace library_api.Models
{
  public class Book
  {
    public string Title { get; set; }

    public string Author { get; set; }

    public string Description { get; set; }

    public bool CheckedOut { get; set; }
    public int LibraryId { get; set; }
    public int Id { get; set; }
  }
}
