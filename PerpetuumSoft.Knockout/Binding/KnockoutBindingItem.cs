using System;
using System.Linq;
using System.Linq.Expressions;

namespace PerpetuumSoft.Knockout
{
    public abstract class KnockoutBindingItem
    {
        public string Name { get; set; }

        public abstract string GetKnockoutExpression(KnockoutExpressionData data, bool cc);

        public virtual bool IsValid()
        {
            return true;
        }
    }
    public class KnockoutBindingItem<TModel, TResult> : KnockoutBindingItem
    {
        public Expression<Func<TModel, TResult>> Expression { get; set; }

        public override string GetKnockoutExpression(KnockoutExpressionData data, bool cc)
        {
            string value = KnockoutExpressionConverter.Convert(Expression, data);

            if (string.IsNullOrWhiteSpace(value))
            {
                value = "$data";
            }
            if (cc)
            {
                value = value.ExpressionToCamelCase();
            }

            return $"{Name}: {value}";
        }
    }
    public class KnockoutBindingStringValueItem : KnockoutBindingItem
    {
        public string Value { get; set; }

        public override string GetKnockoutExpression(KnockoutExpressionData data, bool cc)
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                Value = "$data";
            }

            return $"{Name}: '{Value}'";
        }
    }
}
