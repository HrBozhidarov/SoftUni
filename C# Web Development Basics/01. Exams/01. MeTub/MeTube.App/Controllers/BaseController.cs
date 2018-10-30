using MeTube.App.Data;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeTube.App.Controllers
{
    public class BaseController : Controller
    {
        protected MeTubeContext db;

        public BaseController()
        {
            this.db = new MeTubeContext();
        }
    }
}
