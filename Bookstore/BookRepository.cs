using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    public class BookRepository
    {
		public static void CreateBook(Book book)
		{
			try
			{
				using (var db = new Se407BookStoreContext())
				{
					db.Books.Add(book);
					db.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void EditBook(Book book)
		{
			try
			{
				using (var db = new Se407BookStoreContext())
				{
					db.Books.Update(book);
					db.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void DeleteBook(int id)
		{
			try
			{
				using (var db = new Se407BookStoreContext())
				{
					var bookToDelete = db.Books.Find(id);
					db.Books.Remove(bookToDelete!);
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
