using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_NoiThat.Models;
namespace Web_NoiThat.Controllers
{
    public class DetailController : Controller
    {
        Products dbproduct = new Products();
        // GET: Detail
        public ActionResult Index(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ListProduct = Get_List_Product(id);
                var product = Get_Product(id);
                return View(product);
            }
        }

        
        public Product Get_Product(int id)
        {
            var query = dbproduct.Product.SingleOrDefault(e=>e.product_id.Equals(id));
            return query;
        }

        public List<Product> Get_List_Product(int id)
        {
            int id_c = dbproduct.Product.Include("Categories").Where(e => e.product_id == id).Select(e => e.id_cat).First();
            var query = dbproduct.Product.Where(s=>s.id_cat==id_c&&s.product_id!=id).ToList();
            
            return query;
        }
    }
}