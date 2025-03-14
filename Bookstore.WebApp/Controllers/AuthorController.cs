using Bookstore.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.WebApp.Controllers
{
    public class AuthorController : Controller
    {
        // GET: AuthorController
        public ActionResult Index()
        {
            var authors = ModelFunctions.GetAllAuthors();
			return View(authors);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var author = ModelFunctions.GetAuthorById(id);
			return View(author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author authorToCreate) 
        {
            try
            {
                AuthorRepository.CreateAuthor(authorToCreate);
				return RedirectToAction("Index", "Author");
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = ModelFunctions.GetAuthorById(id);
			return View(author);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author authorToEdit)
        {
            try
            {
                AuthorRepository.EditAuthor(authorToEdit);
				return RedirectToAction("Details", "Author", new { id = authorToEdit.AuthorId });
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = ModelFunctions.GetAuthorById(id);
			return View(author);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Author author)
        {
            try
            {
				AuthorRepository.DeleteAuthor(author.AuthorId);
				return RedirectToAction("Index", "Author");
            }
			catch (DbUpdateException)
			{
				TempData["ErrorMessage"] = "Cannot delete this author because it is associated with one or more books.";
				return RedirectToAction("Index", "Author");
			}
			catch
            {
                return View();
            }
        }
    }
}
