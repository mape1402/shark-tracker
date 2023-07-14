namespace ChangeTracker.Tests.TestObjects
{
    public class TestMixedObject
    {
        public string StringValue { get; set; }

        public int? NulleableIntValue { get; set; }

        public NestedObject NestedObject { get; set; }

        public TestCollectionObject TestCollectionObject { get; set; }

        public ICollection<TestPrimitivesObject> PrimitivesObjects { get; set; }

        public NestedObject[] NestedObjectArrays { get; set; }
    }
}
