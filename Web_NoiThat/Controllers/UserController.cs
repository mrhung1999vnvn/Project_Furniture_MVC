using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NoiThat.Models;
using System.Net.Mail;
using System.Net;
using System.Data.Entity.Validation;

namespace Web_NoiThat.Controllers
{
    public class UserController : Controller
    {
        private Data db = new Data();

        
        public ActionResult Index()
        {
            return View();
        }
    }
}