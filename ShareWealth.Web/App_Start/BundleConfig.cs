using System.Web;
using System.Web.Optimization;

namespace ShareWealth.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/vendor-css").Include(
                "~/app/vendors/bower_components/animate.css/animate.min.css",
                "~/app/vendors/bower_components/material-design-iconic-font/css/material-design-iconic-font.min.css",
                "~/app/vendors/bower_components/sweetalert/dist/sweetalert-override.min.css",
                "~/app/vendors/bower_components/angular-loading-bar/src/loading-bar.css",
                "~/app/vendors/kendo-ui/styles/kendo.common.min.css",
                "~/app/vendors/kendo-ui/styles/kendo.common-material.min.css"));

            BundleTable.EnableOptimizations = false;

        }
    }
}
