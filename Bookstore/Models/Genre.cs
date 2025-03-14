using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    [Display(Name = "Genre")]
	public string GenreType { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
