using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookstore.WebApp.Helpers
{
	public class DropDownFormatter
	{
		public static SelectList FormatGenres()
		{
			return new SelectList
				(
					ModelFunctions
						.GetAllGenres()
						.OrderBy
						(
							g => g.GenreType
						)
						.ToDictionary
						(
							g => g.GenreId,
							g => g.GenreType
						),
					"Key",
					"Value"
				);
		}

		public static SelectList FormatAuthors()
		{
			return new SelectList
				(
					ModelFunctions
						.GetAllAuthors()
						.OrderBy
						(
							a => a.AuthorLast
						)
						.ToDictionary
						(
							a => a.AuthorId,
							a => a.AuthorLast + ", " + a.AuthorFirst
						),
					"Key",
					"Value"
				);
		}
	}
}
