namespace finSuite.InputClasses
{
    public class CreatedProperties
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public int? MinLength{ get; set; }
        public int? MaxLength{ get; set; }

        public bool Nullable { get; set; } = false;

        public string? Regex { get; set; }
    }
}
