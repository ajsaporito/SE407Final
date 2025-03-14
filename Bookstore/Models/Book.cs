using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models;

public partial class Book
{
    public int BookId { get; set; }

	[Display(Name = "Book Title")]
	public string BookTitle { get; set; } = null!;

    public int GenreId { get; set; }

    public int AuthorId { get; set; }

    [Display(Name = "Year of Release")]
	public short YearOfRelease { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
