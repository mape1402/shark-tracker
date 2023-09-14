using SharkTracker.Exceptions;
using SharkTracker.Metadata;
using SharkTracker.Tests.TestObjects;

namespace SharkTracker.Tests.Metadata
{
    public sealed class MetadataRegistryTest
    {
        [Fact(DisplayName = "Check AddType only with primitive properties.")]
        public void AddTypeOnlyPrimitiveProperties()
        {
            //Arrange
            var type = typeof(TestPrimitivesObject);
            var registry = new MetadataRegistry();

            //Act
            var metadata = registry.AddType(type);

            //Assert
            Assert.NotNull(metadata);
            Assert.True(metadata.Properties.All(x => x.InternalType == InternalPropertyType.Primitive));
        }

        [Fact(DisplayName = "Check AddType<T> only with primitive properties.")]
        public void AddTypeGenericOnlyPrimitiveProperties()
        {
            //Arrange
            var registry = new MetadataRegistry();

            //Act
            var metadata = registry.AddType<TestPrimitivesObject>();

            //Assert
            Assert.NotNull(metadata);
            Assert.True(metadata.Properties.All(x => x.InternalType == InternalPropertyType.Primitive));
        }

        [Fact(DisplayName = "Check AddType only with complex properties.")]
        public void AddTypeOnlyComplexProperties()
        {
            //Arrange
            var type = typeof(TestComplexObject);
            var registry = new MetadataRegistry();

            //Act
            var metadata = registry.AddType(type);

            //Assert
            Assert.NotNull(metadata);
            Assert.True(metadata.Properties.All(x => x.InternalType == InternalPropertyType.Complex));
        }

        [Fact(DisplayName = "Check AddType<T> only with complex properties.")]
        public void AddTypeGenericOnlyComplexProperties()
        {
            //Arrange
            var registry = new MetadataRegistry();

            //Act
            var metadata = registry.AddType<TestComplexObject>();

            //Assert
            Assert.NotNull(metadata);
            Assert.True(metadata.Properties.All(x => x.InternalType == InternalPropertyType.Complex));
        }

        [Fact(DisplayName = "Check AddType only with collection properties.")]
        public void AddTypeOnlyCollectionProperties()
        {
            //Arrange
            var type = typeof(TestCollectionObject);
            var registry = new MetadataRegistry();

            //Act
            var metadata = registry.AddType(type);

            //Assert
            Assert.NotNull(metadata);
            Assert.True(metadata.Properties.All(x => x.InternalType == InternalPropertyType.Collection));
        }


        [Fact(DisplayName = "Check AddType<T> only with collection properties.")]
        public void AddTypeGenericOnlyCollectionProperties()
        {
            //Arrange
            var registry = new MetadataRegistry();

            //Act
            var metadata = registry.AddType<TestCollectionObject>();

            //Assert
            Assert.NotNull(metadata);
            Assert.True(metadata.Properties.All(x => x.InternalType == InternalPropertyType.Collection));
        }

        [Fact(DisplayName = "Check AddType only with mixed properties.")]
        public void AddTypeWithMixedProperties()
        {
            //Arrange
            var type = typeof(TestMixedObject);
            var registry = new MetadataRegistry();
            var mixedProperties = 2;

            //Act
            var metadata = registry.AddType(type);

            //Assert
            Assert.NotNull(metadata);
            Assert.Equal(metadata.Properties.Count(x => x.InternalType == InternalPropertyType.Primitive), mixedProperties);
            Assert.Equal(metadata.Properties.Count(x => x.InternalType == InternalPropertyType.Complex), mixedProperties);
            Assert.Equal(metadata.Properties.Count(x => x.InternalType == InternalPropertyType.Collection), mixedProperties);
        }

        [Fact(DisplayName = "Check AddType<T> only with mixed properties.")]
        public void AddTypeGenericWithMixedProperties()
        {
            //Arrange
            var registry = new MetadataRegistry();
            var mixedProperties = 2;

            //Act
            var metadata = registry.AddType<TestMixedObject>();

            //Assert
            Assert.NotNull(metadata);
            Assert.Equal(metadata.Properties.Count(x => x.InternalType == InternalPropertyType.Primitive), mixedProperties);
            Assert.Equal(metadata.Properties.Count(x => x.InternalType == InternalPropertyType.Complex), mixedProperties);
            Assert.Equal(metadata.Properties.Count(x => x.InternalType == InternalPropertyType.Collection), mixedProperties);
        }

        [Fact(DisplayName = "Check AddType with invalid types.")]
        public void AddTypeInvalidType()
        {
            //Arrange
            var abstractClass = typeof(TestAbstractClass);
            var interfaceType = typeof(ITestInterface);
            var primitiveType = typeof(int);

            var exceptionType = typeof(ArgumentException);

            var registry = new MetadataRegistry();

            //Act 
            var exAbstract = Record.Exception(() =>
            {
                registry.AddType(abstractClass);
            });

            var exInterface = Record.Exception(() =>
            {
                registry.AddType(interfaceType);
            });

            var exPrimitive = Record.Exception(() =>
            {
                registry.AddType(primitiveType);
            });

            //Assert
            Assert.NotNull(exAbstract);
            Assert.IsType(exceptionType, exAbstract);

            Assert.NotNull(exInterface);
            Assert.IsType(exceptionType, exInterface);

            Assert.NotNull(exPrimitive);
            Assert.IsType(exceptionType, exPrimitive);
        }

        [Fact(DisplayName = "Check Get a object metadata that exists.")]
        public void GetMetadataThatExists()
        {
            //Arrange 
            var registry = GetMetadataRegistry();

            //Act
            var metadata = registry.Get<TestComplexObject>();

            //Assert
            Assert.NotNull(metadata);
            Assert.Equal(metadata.Name, typeof(TestComplexObject).Name);
        }

        [Fact(DisplayName = "Check Get a object metadata that doesnt exist.")]
        public void GetMetadataThatDoesntExist()
        {
            //Arrange 
            var registry = GetMetadataRegistry();
            var exceptionType = typeof(ObjectTypeMetadataIsNotRegisteredException);

            //Act
            var ex = Record.Exception(() =>
            {
                registry.Get<TestMixedObject>();
            });

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
        }

        private MetadataRegistry GetMetadataRegistry()
        {
            var registry = new MetadataRegistry();

            registry.AddType<TestComplexObject>();
            registry.AddType<TestPrimitivesObject>();

            return registry;
        }
    }
}
