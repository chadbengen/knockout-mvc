using System.Web.Mvc;

namespace PerpetuumSoft.Knockout
{
    public class KnockoutIfContext<TModel> : KnockoutCommonRegionContext<TModel>
    {
        public KnockoutIfContext(ViewContext viewContext, string expression, bool cc)
            : base(viewContext, expression)
        {
            CamelCase = cc;
        }

        protected override string Keyword
        {
            get
            {
                return "if";
            }
        }
    }
}