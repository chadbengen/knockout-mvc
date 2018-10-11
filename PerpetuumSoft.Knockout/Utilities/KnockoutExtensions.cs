using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace PerpetuumSoft.Knockout
{
    public static class KnockoutExtensions
    {
        public static KnockoutContext<TModel> CreateKnockoutContext<TModel>(this HtmlHelper<TModel> helper)
        {
            return new KnockoutContext<TModel>(helper.ViewContext);
        }

        public static KnockoutContext<TModel> CreateKnockoutContext<TModel>(this HtmlHelper<TModel> helper, string viewModelName)
        {
            var context = helper.CreateKnockoutContext();
            context.ViewModelName = viewModelName;
            return context;
        }

        public static string ExpressionToCamelCase2(this string str)
        {
            var sb = new StringBuilder();
            var matches = Regex.Matches(str, @"[^a-zA-Z\d\s:]");
            var splitters = matches.Cast<Match>().Select(match => match.Value).Distinct().ToList();
            foreach (var splitter in splitters)
            {
                var results = new List<string>();
                var values = str.Split(new[] { splitter }, StringSplitOptions.None);
                foreach (var value in values)
                {
                    var result = string.IsNullOrWhiteSpace(value)
                        ? null
                        : char.ToLowerInvariant(value[0]) + (value.Length > 1 ? value.Substring(1) : null);
                    results.Add(result);
                }
                str = string.Join(splitter, results);
            }

            return char.ToLowerInvariant(str[0]) + (str.Length > 1 ? str.Substring(1) : null);
        }
    }

    public static class HtmlHelpers
    {
        public static HtmlHelper<TModel> For<TModel>(this HtmlHelper helper) where TModel : class, new()
        {
            return For<TModel>(helper.ViewContext, helper.ViewDataContainer.ViewData, helper.RouteCollection);
        }

        public static HtmlHelper<TModel> For<TModel>(this HtmlHelper helper, TModel model)
        {
            return For<TModel>(helper.ViewContext, helper.ViewDataContainer.ViewData, helper.RouteCollection, model);
        }

        public static HtmlHelper<TModel> For<TModel>(ViewContext viewContext, ViewDataDictionary viewData, RouteCollection routeCollection) where TModel : class, new()
        {
            TModel model = new TModel();
            return For<TModel>(viewContext, viewData, routeCollection, model);
        }

        public static HtmlHelper<TModel> For<TModel>(ViewContext viewContext, ViewDataDictionary viewData, RouteCollection routeCollection, TModel model)
        {
            var newViewData = new ViewDataDictionary(viewData) { Model = model };
            ViewContext newViewContext = new ViewContext(
                viewContext.Controller.ControllerContext,
                viewContext.View,
                newViewData,
                viewContext.TempData,
                viewContext.Writer);
            var viewDataContainer = new ViewDataContainer(newViewContext.ViewData);
            return new HtmlHelper<TModel>(newViewContext, viewDataContainer, routeCollection);
        }

        private class ViewDataContainer : System.Web.Mvc.IViewDataContainer
        {
            public System.Web.Mvc.ViewDataDictionary ViewData { get; set; }

            public ViewDataContainer(System.Web.Mvc.ViewDataDictionary viewData)
            {
                ViewData = viewData;
            }
        }
    }
}
