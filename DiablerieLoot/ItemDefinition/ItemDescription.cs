using System;


namespace DiablerieLoot
{
    public class ItemDescription
    {
        private Component _item;
        public Component Item 
        {
            get { if (_item == null) _item = new Component(); return _item; }
            set { _item = value; }
        }

        private Component _prefix;
        public Component Prefix
        {
            get { if (_prefix == null) _prefix = new Component(); return _prefix; } 
            set { _prefix = value; }
        }

        private Component _suffix;
        public Component Suffix
        {
            get { if (_suffix == null) _suffix = new Component(); return _suffix; }
            set { _suffix = value; }
        }

        public ItemDescription() { }

        public ItemDescription(Component item, Component prefix, Component suffix)
        {
            Item = item;
            Prefix = prefix;
            Suffix = suffix;
        }

        public override string ToString()
        {
            // Description
            var description = Item.Description;

            if (!String.IsNullOrEmpty(Prefix.Description))
                description = $"{Prefix.Description} {description}";

            if (!String.IsNullOrEmpty(Suffix.Description))
                description = $"{description} {Suffix.Description}";

            // Worth
            var totalWorth = Prefix.Worth + Item.Worth + Suffix.Worth;
            var totalWorthString = totalWorth > 0.0f ? totalWorth.ToString() + "gp" : String.Empty;

            if (!String.IsNullOrEmpty(description) && !String.IsNullOrEmpty(totalWorthString))
                description += " - ";

            // Effect
            var effect = Item.Effect;
            if (!String.IsNullOrEmpty(Prefix.Effect))
                effect = $"{ Prefix.Effect } | { effect }";

            if (!String.IsNullOrEmpty(Suffix.Effect))
                effect = $"{ effect } | { Suffix.Effect }";

            if (!String.IsNullOrEmpty(effect))
                effect = $"\n{ effect }";

            return $"{ description }{ totalWorthString }{ effect }";
        }
    }
}
