using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    public class GenreRepository
    {
		public static void CreateGenre(Genre genre)
		{
			try
			{
				using (var db = new Se407BookStoreContext())
				{
					db.Genres.Add(genre);
					db.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void EditGenre(Genre genre)
		{
			try
			{
				using (var db = new Se407BookStoreContext())
				{
					db.Genres.Update(genre);
					db.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void DeleteGenre(int id)
		{
			try
			{
				using (var db = new Se407BookStoreContext())
				{
					var genreToDelete = db.Genres.Find(id);
					db.Genres.Remove(genreToDelete!);
					db.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
