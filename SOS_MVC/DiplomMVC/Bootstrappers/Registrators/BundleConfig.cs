using System.Web.Optimization;
using DiplomMVC.Constants;

namespace DiplomMVC.Bootstrappers.Registrators
{
    public class BundlesRegistrator
    {

        public static void Register(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(ScriptBundles.JQuery).Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle(ScriptBundles.Bootstrap).Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle(ScriptBundles.Modernizr).Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle(StyleBundles.Default).Include("~/Content/site.css"));

            bundles.Add(new StyleBundle(StyleBundles.Bootstrap).Include(
                "~/Content/Bootstrap/bootstrap-theme.css",
                "~/Content/Bootstrap/bootstrap.css"));
        }
    }
}