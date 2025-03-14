using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore
{
	public class ModelFunctions
	{
		public static List<Book> GetAllBooks()
		{
			using (var db = new Se407BookStoreContext())
			{
				var books = db.Books
					.Include(b => b.Genre)
					.Include(b => b.Author)
					.ToList();

				return books;
			}
		}

		public static Book? GetBookById(int id)
		{
			using (var db = new Se407BookStoreContext())
			{
				var book = db.Books
					.Include(b => b.Genre)
					.Include(b => b.Author)
					.Where(b => b.BookId == id)
					.FirstOrDefault();

				return book;
			}
		}

		public static List<Genre> GetAllGenres()
		{
			using (var db = new Se407BookStoreContext())
			{
				return db.Genres
					.ToList();
			}
		}

		public static Genre? GetGenreById(int id)
		{
			using (var db = new Se407BookStoreContext())
			{
				var genre = db.Genres
					.Where(g => g.GenreId == id)
					.FirstOrDefault();
				return genre;
			}
		}

		public static List<Author> GetAllAuthors()
		{
			using (var db = new Se407BookStoreContext())
			{
				return db.Authors
					.ToList();
			}
		}

		public static Author? GetAuthorById(int id)
		{
			using (var db = new Se407BookStoreContext())
			{
				var author = db.Authors
					.Where(a => a.AuthorId == id)
					.FirstOrDefault();
				return author;
			}
		}
	}
}
