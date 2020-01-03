using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_NoiThat.Models;

namespace Web_NoiThat.Controllers.Admin
{
    public class AdminController : Controller
    {
        Products dbproduct = new Products();
        Categories dbcategories = new Categories();
        ProductToDisplay contructorPro = new ProductToDisplay();


        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.til = "Dashboard";
            return View();
        }
        public ActionResult Product()
        {
            ViewBag.til = "Product";
            var data = Get_List_Product();
            ViewBag.SizeData = data.Count;
            return View(data);
        }

        public static HttpPostedFileBase file;

        [HttpPost]
        public ActionResult Add_Product(Product productItem, int category)
        {
            //Thêm sản phẩm mới
            try
            {
                var path="";
                var image = "";
                //Kiểm tra file hình ảnh
                if ( file!= null && file.ContentLength > 0)
                {
                    var filename = Path.GetFileName(file.FileName);
                    path = Path.Combine(Server.MapPath(@"/Images/Products"), filename);
                    image = "/Images/Products/" + filename;
                    file.SaveAs(path);
                }

                //Lưu object vao database
                Product pro = new Product
                {
                    description = productItem.description,
                    id_cat = category,
                    price = Convert.ToDouble(productItem.price),
                    product_img = image,
                    product_name = productItem.product_name,
                    product_quantities = productItem.product_quantities,
                    product_id = productItem.product_id,
                    id_supplier = 1,
                    status="Còn hàng"
                };


                dbproduct.Product.Add(pro);
                dbproduct.SaveChanges();


                var data = Get_List_Product();          //Lấy lại dữ liệu
                return View("Product",data);
            }
            catch
            {
                throw;
            }
        }

        
        public HttpPostedFileBase Get_File()
        {
            try
            {
                var count = Request.Files.Count;
                if (count > 0)
                {
                    file = Request.Files[0];
                    return file;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }


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


        [NonAction]
        public void Remove(int id)
        {
            contructorPro.remove_Product(id);
        }
    }
}