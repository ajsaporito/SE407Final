using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    public class AuthorRepository
    {
		public static void CreateAuthor(Author author)
		{
			try
			{
				using (var db = new Se407BookStoreContext())
				{
					db.Authors.Add(author);
					db.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void EditAuthor(Author author)
		{
			try
			{
				using (var db = new Se407BookStoreContext())
				{
					db.Authors.Update(author);
					db.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void DeleteAuthor(int id)
		{
			try
			{
				using (var db = new Se407BookStoreContext())
				{
					var authorToDelete = db.Authors.Find(id);
					db.Authors.Remove(authorToDelete!);
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
