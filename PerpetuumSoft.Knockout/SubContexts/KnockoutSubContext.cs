using System.Collections.Generic;

namespace PerpetuumSoft.Knockout
{
    public abstract class KnockoutSubContext<TModel>
    {
        public KnockoutContext<TModel> Context { get; set; }
        public string[] InstanceNames { get; set; }
        public Dictionary<string, string> Aliases { get; set; }

        protected KnockoutSubContext(KnockoutContext<TModel> context, string[] instanceNames = null, Dictionary<string, string> aliases = null)
        {
            Context = context;
            InstanceNames = instanceNames;
            Aliases = aliases;
        }

        protected KnockoutExpressionData CreateData()
        {
            var data = new KnockoutExpressionData();
            if (InstanceNames != null)
                data.InstanceNames = InstanceNames;
            if (Aliases != null)
                data.Aliases = Aliases;
            return data.Clone();
        }
    }
}
