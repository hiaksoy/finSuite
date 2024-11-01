namespace finSuite.InputClasses
{
    public class ClassDatas
    {
        public Dictionary<string, string> Properties { get; set; }
        public Dictionary<string, string> NavigationProperties { get; set; }
        public List<string> InheritanceList { get; set; }
        public string ClassName { get; set; }
        public string NamespaceName { get; set; }
    }
}
