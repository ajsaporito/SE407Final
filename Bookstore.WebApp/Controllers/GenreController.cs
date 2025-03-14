using Bookstore.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.WebApp.Controllers
{
    public class GenreController : Controller
    {
        // GET: GenreController
        public ActionResult Index()
        {
            var genres = ModelFunctions.GetAllGenres();
			return View(genres);
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            var genre = ModelFunctions.GetGenreById(id);
			return View(genre);
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genreToCreate)
        {
            try
            {
                GenreRepository.CreateGenre(genreToCreate);
				return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            var genre = ModelFunctions.GetGenreById(id);
			return View(genre);
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genreToEdit)
        {
            try
            {
                GenreRepository.EditGenre(genreToEdit);
                return RedirectToAction("Details", "Genre", new { id = genreToEdit.GenreId });
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            var genre = ModelFunctions.GetGenreById(id);
			return View(genre);
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Genre genre)
        {
            try
            {
                GenreRepository.DeleteGenre(genre.GenreId);
				return RedirectToAction("Index", "Genre");
            }
            catch (DbUpdateException)
            {
				TempData["ErrorMessage"] = "Cannot delete this genre because it is associated with one or more books.";
				return RedirectToAction("Index", "Genre");
			}
            catch
            {
				return View();
			}
        }
    }
}
