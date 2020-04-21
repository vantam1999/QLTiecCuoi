using System.Web;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace qlTiecCuoi
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/assets/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/assets/jquery/jquery.validate*"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Content/scripts/dropdownHeader.js",
                        "~/Content/scripts/social.js",
                        "~/Content/scripts/partnerCarousel.js",
                        "~/Content/scripts/animateScroll.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(               
                      "~/Content/site.css"));
        }
    }
}
