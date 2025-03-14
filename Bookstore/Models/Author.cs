using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    [Display(Name = "First Name")]
	public string AuthorFirst { get; set; } = null!;

	[Display(Name = "Last Name")]
	public string AuthorLast { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
