using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_NoiThat.Models
{
    public class ProductToDisplay
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public double? price { get; set; }
        public DateTime created_at { get; set; }
        public string status { get; set; }
        public string category { get; set; }
        public string supplier { get; set; }

        public ProductToDisplay()
        {

        }

        Products dbproduct = new Products();
        Categories dbcategories = new Categories();
        Products dbsupplier = new Products();

        public string get_Categories(int id)
        {
            var item = dbproduct.categories.Include("Products").Where(e => e.cat_id == id).Select(e => e.cat_name).First();
            return item;
        }

        public string get_Supplier(int id)
        {
            var name = dbsupplier.supplier.Where(s => s.supplier_id.Equals(id)).First();
            return name.supplier_name;
        }



        public bool remove_Product(int id)
        {
            try
            {
                var product=dbproduct.Product.Where(s=>s.product_id==id).First();
                dbproduct.Product.Remove(product);
                dbproduct.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}