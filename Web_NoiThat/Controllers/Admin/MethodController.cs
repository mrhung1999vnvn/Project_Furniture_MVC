using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_NoiThat.Models;
using System.Data.Entity.Migrations;

namespace Web_NoiThat.Controllers.Admin
{
    public class MethodController : Controller
    {

        Products dbproduct = new Products();
        Categories dbcategories = new Categories();
        ProductToDisplay contructorPro = new ProductToDisplay();

        // GET: Method
        public ActionResult UpdateProduct(int id)
        {
            try
            {
                var product = dbproduct.Product.First(s => s.product_id.Equals(id));
                return View(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Update(Product proItem, int category, int status,int quanti)
        {

            //Tìm sản phẩm theo id
            var product = dbproduct.Product.Where(s => s.product_id.Equals(proItem.product_id)).First<Product>();
            try
            {
                //Cập nhật sản phẩm
                product.created_at = proItem.created_at;
                product.description = proItem.description;
                product.id_cat = category;
                product.price = Convert.ToDouble(proItem.price);
                product.product_name = proItem.product_name;
                product.product_quantities = quanti;
                product.status = status == 1 ? "còn hàng" : "hết hàng";

                dbproduct.SaveChanges();

                var data = Get_List_Product();

                return View("~/Views/Admin/Product.cshtml", data);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public void Delete(int id)
        {
            //Tìm kiếm sản phẩm theo mã
            var std = dbproduct.Product.Where(s=>s.product_id.Equals(id)).First<Product>();
            //Xóa
            dbproduct.Product.Remove(std);
            dbproduct.SaveChanges();
        }


        //For demo Ajax
        [HttpPost]
        public JsonResult AjaxMethod(int id)
        {
            Product pro = new Product
            {
                product_id = id,
            };
            return Json(pro);
        }


        //Lấy lại dữ liệu
        [NonAction]
        public List<ProductToDisplay> Get_List_Product()
        {
            List<ProductToDisplay> lstProduct = new List<ProductToDisplay>();
            var product = dbproduct.Product.ToList();
            foreach (var item in product)
            {
                ProductToDisplay pro = new ProductToDisplay
                {
                    category = contructorPro.get_Categories(item.id_cat),
                    description = item.description,
                    price = item.price,
                    product_id = item.product_id,
                    status = item.status,
                    product_name = item.product_name,
                    supplier = contructorPro.get_Supplier(item.id_supplier),
                };
                lstProduct.Add(pro);
            }
            return lstProduct;
        }
    }
}