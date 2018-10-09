using System.Web.Mvc;

namespace PerpetuumSoft.Knockout
{
    public class KnockoutWithContext<TModel> : KnockoutCommonRegionContext<TModel>
    {
        public KnockoutWithContext(ViewContext viewContext, string expression, bool cc)
            : base(viewContext, expression)
        {
            CamelCase = cc;
        }

        protected override string Keyword
        {
            get
            {
                return "with";
            }
        }
    }
}