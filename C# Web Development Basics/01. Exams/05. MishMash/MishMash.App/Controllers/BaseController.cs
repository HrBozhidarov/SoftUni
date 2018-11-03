using MishMash.App.Data;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishMash.App.Controllers
{
    public class BaseController : Controller
    {
        protected MishMashContext db;

        public BaseController()
        {
            this.db = new MishMashContext();
        }
    }
}
