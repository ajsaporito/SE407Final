using Bookstore.Models;
using Bookstore.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.WebApp.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        public ActionResult Index()
        {
			return RedirectToAction("Index", "Home");
		}

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = ModelFunctions.GetBookById(id);
			return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
			ViewBag.AuthorId = DropDownFormatter.FormatAuthors();
			return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book bookToCreate)
        {
            try
            {
				BookRepository.CreateBook(bookToCreate);
				return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = ModelFunctions.GetBookById(id);
			ViewBag.GenreId = DropDownFormatter.FormatGenres();
			ViewBag.AuthorId = DropDownFormatter.FormatAuthors();
			return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book bookToEdit)
        {
            try
            {
                BookRepository.EditBook(bookToEdit);
				return RedirectToAction("Details", "Book", new { id = bookToEdit.BookId });
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = ModelFunctions.GetBookById(id);
			return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            try
            {
                BookRepository.DeleteBook(book.BookId);
				return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
