using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            var articles = _context.Articles
                .Include(a => a.Author)
                .ToList();

            return View(articles);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(500);
            }

            var article = _context.Articles
                .Include(a => a.Author)
                .First(x => x.Id == id);

            if (article == null)
            {
                return StatusCode(500);
            }



            return View(article);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                var authorId = _context.Users
                    .Where(x => x.UserName == this.User.Identity.Name)
                    .First()
                    .Id;

                article.AuthorId = authorId;

                _context.Articles.Add(article);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(article);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _context.Articles
                .Include(a => a.Author)
                .First(x => x.Id == id);

            if (!IsAuthorizedToEdit(article))
            {
                return Forbid();
            }

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var article = _context.Articles
                .Include(a=>a.Author)
                .First(m => m.Id == id);

            if (article==null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

       [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _context.Articles
                .Include(a=>a.Author)
                .Where(m => m.Id == id)
                .First();

            if (!IsAuthorizedToEdit(article))
            {
                return Forbid();
            }

            if (article == null)
            {
                return NotFound();
            }

            var model = new ArticleViewModel();

            model.Id = article.Id;
            model.Title = article.Title;
            model.Content = article.Content;

            return View(model);
        }

       
        [HttpPost]
        [Authorize]
        public IActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var artcilce = _context.Articles
                    .FirstOrDefault(x => x.Id == model.Id);

                artcilce.Title = model.Title;
                artcilce.Content = model.Content;

                _context.Update(artcilce);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public bool IsAuthorizedToEdit(Article article)
        {
            var isAdmin = this.User.IsInRole("Admin");
            var isAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }
    }
}
