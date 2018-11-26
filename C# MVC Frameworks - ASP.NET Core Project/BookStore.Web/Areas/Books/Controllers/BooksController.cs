using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Areas.Book.Controllers
{
    public class BooksController : BaseController
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public IActionResult Create()
        //{

        //}
    }
}
