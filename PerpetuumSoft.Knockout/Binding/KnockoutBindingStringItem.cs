﻿using System.Text;

namespace PerpetuumSoft.Knockout
{
    public class KnockoutBindingStringItem : KnockoutBindingItem
    {
        public KnockoutBindingStringItem()
        {
            NeedQuotes = true;
        }

        public KnockoutBindingStringItem(string name, string value)
            : this()
        {
            Name = name;
            Value = value;
        }

        public KnockoutBindingStringItem(string name, string value, bool needQuotes = true)
            : this(name, value)
        {
            NeedQuotes = needQuotes;
        }

        public string Value { get; set; }
        public bool NeedQuotes { get; set; }

        public override string GetKnockoutExpression(KnockoutExpressionData data, bool cc)
        {
            var builder = new StringBuilder();

            builder.Append(Name);
            builder.Append(" : ");
            if (NeedQuotes)
                builder.Append('\'');

            Value = cc ? char.ToLowerInvariant(Value[0]) + Value.Substring(1) : Value;

            builder.Append(Value);
            if (NeedQuotes)
                builder.Append('\'');

            return builder.ToString();
        }
    }
}
