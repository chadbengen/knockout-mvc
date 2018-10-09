using System.Web.Mvc;

namespace PerpetuumSoft.Knockout
{
    public class KnockoutForeachContext<TModel> : KnockoutCommonRegionContext<TModel>
    {
        public KnockoutForeachContext(ViewContext viewContext, string expression, bool cc)
            : base(viewContext, expression)
        {
            this.CamelCase = cc;
        }

        protected override string Keyword
        {
            get
            {
                return "foreach";
            }
        }
    }
}
