using System.Web;
using System.Web.Optimization;

namespace AkzonobelScript
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/resources/jquery/jquery-1.9.1.js",
                        "~/resources/jquery/ui/jquery.ui.widget.js",
                        "~/resources/jquery/ui/jquery.ui.core.js",
                        "~/resources/jquery/ui/jquery.ui.accordion.js",
                        "~/resources/jquery/ui/jquery.ui.datepicker.js",
                        "~/resources/jquery/ui/jquery.ui.datepicker-ru.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/jquery/css").Include(
                      "~/resources/jquery/themes/base/jquery.ui.core.css",
                      "~/resources/jquery/themes/base/jquery.ui.accordion.css",
                      "~/resources/jquery/themes/base/jquery.ui.datepicker.css",
                      "~/resources/jquery/themes/base/jquery.ui.theme.css"));


            bundles.Add(new StyleBundle("~/base/css").Include(
                      "~/resources/css/pattern.css",
                      "~/resources/css/style.css",
                      "~/Content/Custom/style.css",
                      "~/resources/dhtmlgoodies_calendar/dhtmlgoodies_calendar.css",
                      "~/resources/ajax/subModal.css"));

            bundles.Add(new ScriptBundle("~/base/js").Include(
                      "~/resources/js/pattern.js",
                      "~/resources/dhtmlgoodies_calendar/dhtmlgoodies_calendar.js",
                      "~/resources/ajax/common.js",
                      "~/resources/ajax/subModal.js"));

        }
    }
}
