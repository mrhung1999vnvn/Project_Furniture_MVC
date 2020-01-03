using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NoiThat.Models;

namespace Web_NoiThat.Controllers
{
    public class CartController : Controller
    {
        double? total = 0;
        Products dbpro = new Products();
        Categories dbcat = new Categories();
        Carts dbCart = new Carts();


        // GET: Cart
        [Authorize(Roles = "User,Admin,Customer")]
        public ActionResult Index()
        {
            ViewBag.Modal = Session["modal"];
            ViewBag.Product = Session["cart"];
            ViewBag.totalPrice = Session["orderPrice"];
            ViewBag.total = Session["total"];
            return View("Index");
        }



        [Authorize(Roles = "User,Admin")]
        public ActionResult Add_Cart(string id)
        {
            var pro = getProduct(Convert.ToInt32(id));


            List<ProductForCart> pfc;

            //Kiểm tra chưa có session['cart']
            if (Session["cart"] == null)
            {
                pfc = new List<ProductForCart>();

                //Add vào danh sách hiển thị
                pfc.Add(new ProductForCart
                {
                    Id = pro.product_id,
                    name = pro.product_name,
                    categories = GetCategory(pro.product_id),
                    picture = pro.product_img,
                    price = pro.price,
                    quantity = 1
                });
                Session["cart"] = pfc;
            }
            else
            {
                pfc = (List<ProductForCart>)Session["cart"];
                int index = isExisted(id);
                if (index != -1)
                {
                    pfc[index].quantity++;
                }
                else
                {
                    pfc.Add(new ProductForCart
                    {
                        Id = pro.product_id,
                        name = pro.product_name,
                        categories = GetCategory(pro.product_id),
                        picture = pro.product_img,
                        price = pro.price,
                        quantity = 1,
                    });
                }
                Session["cart"] = pfc;
               
            }

            Session["orderPrice"] = Total_Price(pfc);
            Session["total"] = Total_Price(pfc) + 10;

            // Add to list display
            Session["cart"] = pfc;
            var k = pfc.Count;

            return RedirectToAction("Index","Home");
        }


        //Remove Item In Cart
        [HttpGet]
        public ActionResult Remove_Item_Cart(int id)
        {
            try
            {
                List<ProductForCart> pfc = (List<ProductForCart>)Session["cart"];
                pfc.RemoveAt(id);
                Session["orderPrice"] = Total_Price(pfc);
                Session["total"] = Total_Price(pfc) + 10;
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index", "Cart");
        }

        Cart carts = new Cart();
        Checkout checks = new Checkout();
        //Xuất ra hóa đơn
        [HttpPost]
        public ActionResult Checkout(int[] quanti, double totalCheckout)
        {
            List<ProductForCart> cartItem = (List<ProductForCart>)Session["cart"];
            try
            {
                var idUser = Session["idUser"];
                //Lấy lại dữ liệu trong 
                for (int i = 0; i < quanti.Length; i++)
                {
                    cartItem[i].quantity = quanti[i];
                }

                foreach (var item in cartItem)
                {
                    Cart c = new Cart
                    {
                        price = item.price,
                        quantity = item.quantity,
                        id_product = item.Id,
                        user_id = Convert.ToInt32(idUser),
                        created_at = DateTime.Now,
                    };
                    carts.Insert_Cart(c);
                }

                #region Checkout
                Checkout itemCheckout = new Checkout
                {
                    id_user = Convert.ToInt32(idUser.ToString()),
                    checkout_total = totalCheckout,
                    created_at = DateTime.Now,
                };
                checks.Add_Checkout(itemCheckout);
                #endregion
            }
            catch (Exception)
            {
                throw;
            }

            cartItem = new List<ProductForCart>();
            Session["cart"] = null;
            return Json(new { content = "" });
        }

        #region Total_Price 
        public double? Total_Price(List<ProductForCart> pfc)
        {
            double? total = 0;
            foreach (var item in pfc)
            {
                total += item.price * item.quantity;
            }
            return total;
        }
        #endregion



        public int isExisted(string id)
        {
            List<ProductForCart> cart = (List<ProductForCart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Id.Equals(Convert.ToInt32(id)))
                    return i;
            return -1;
        }


        public Product getProduct(int id)
        {
            var prodItem = dbpro.Product.Find(id);
            if (prodItem != null)
            {
                return prodItem;
            }
            return null;
        }

        public string GetCategory(int id)
        {
            var query = dbpro.Product.Include("Categories").Where(e => e.product_id == id).Select(e => e.id_cat).First();
            var item = dbpro.categories.Include("Products").Where(e => e.cat_id == query).Select(e => e.cat_name).First();
            return item;
        }

        //Get Address From Supplier
        public string GetAddress(int id)
        {
            var query = dbpro.Product.Include("Supplier").Where(e => e.product_id.Equals(id)).Select(e => e.id_supplier).First();
            var item = dbpro.supplier.Include("Product").Where(e => e.supplier_id.Equals(query)).Select(e => e.supplier_name).First();
            return item;
        }
    }



}