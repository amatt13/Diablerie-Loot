namespace DiablerieLoot
{
    public class Component
    {
        public string Description { get; set; } = string.Empty;
        public string Effect { get; set; } = string.Empty;
        public float Worth { get; set; } = 0.0f;

        public Component() { }

        public Component(string description, string effect, float worth)
        {
            Description = description;
            Effect = effect;
            Worth = worth;
        }

        public override string ToString()
        {
            return $"{Description}   {Effect}  {Worth}";
        }
    }
}
