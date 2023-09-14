namespace SharkTracker.Tests.TestObjects
{
    public class TestCollectionObject
    {
        public ICollection<string> StringColletion { get; set; }

        public ICollection<NestedObject> NestedObjectCollection { get; set; }

        public IList<string> StringList { get; set; }

        public IList<NestedObject> NestedObjectList { get; set; }

        public IEnumerable<string> StringValues { get; set; }

        public IEnumerable<NestedObject> NestedObjectValues { get; set; }

        public string[] StringArray { get; set; }

        public NestedObject[] NestedObjectArray { get; set; }
    }
}
