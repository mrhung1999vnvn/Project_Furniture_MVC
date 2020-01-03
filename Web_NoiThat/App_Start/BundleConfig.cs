using System.Web;
using System.Web.Optimization;

namespace Web_NoiThat
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                       "~/Scripts/jquery.validate.min.js",
                       "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Scripts/scripts").Include(
                       "~/Scripts/jquery-3.3.1.slim.js",
                       "~/Scripts/popper.min.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/SmoothScroll").Include(
                      "~/Scripts/smoothscroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/Carousel").Include(
                      "~/Scripts/Animation/Carousel.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Main.css",
                      "~/Content/imagehover.min.css",
                      "~/Content/bootstrap-Custom.css"
                      ));
            bundles.Add(new StyleBundle("~/OtherPage/css").Include(
                      "~/Content/OtherPage/ConfirmMail.css"
                      ));

            //Admin
            bundles.Add(new StyleBundle("~/Admin/admin").Include(
                      "~/Content/Admin/now-ui-dashboard.css",
                      "~/Content/Admin/now-ui-dashboard.css.map",
                      "~/Content/Admin/now-ui-dashboard.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/Chart").Include(
                     "~/Scripts/plugin/chartjs.min.js"));
        }
    }
}
