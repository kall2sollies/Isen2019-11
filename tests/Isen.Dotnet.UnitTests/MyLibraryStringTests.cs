using System;
using Isen.Dotnet.Library;
using Xunit;

namespace Isen.Dotnet.UnitTests
{
    public class MyLibraryStringTests
    {
        private static string [] TestArray => 
            new string[] { "Hello", "world", "of", "useless", "arrays" };
        private static MyCollection BuildTestList()
        {
            var myCollection = new MyCollection();
            foreach (var item in TestArray) myCollection.Add(item);
            return myCollection;
        }
        [Fact]
        public void CountTest()
        {
            var myCollection = BuildTestList();
            Assert.Equal(TestArray.Length, myCollection.Count);
        }
        [Fact]
        public void AddTest() => 
            Assert.Equal(TestArray, BuildTestList().Values);
        [Fact]
        public void IndexOfTest()
        {
            var myCollection = BuildTestList();
            Assert.Equal(0, myCollection.IndexOf("Hello"));
            Assert.Equal(4, myCollection.IndexOf("arrays"));
            Assert.Equal(2, myCollection.IndexOf("of"));
            Assert.True(myCollection.IndexOf("dfghj") < 0);
        }
        [Fact]
        public void IndexorTest()
        {
            var myCollection = BuildTestList();
            Assert.Equal("Hello", myCollection[0]);
            Assert.Equal("arrays", myCollection[4]);
            Assert.Equal("of", myCollection[2]);
        }
        [Fact]
        public void RemoveAtTest()
        {
            var myCollection = BuildTestList();
            // Remove 3 => Hello world of arrays
            myCollection.RemoveAt(3);
            Assert.Equal(TestArray.Length - 1, myCollection.Count);
            var targetArray =  new string [] {"Hello", "world", "of", "arrays"}; 
            Assert.Equal(targetArray, myCollection.Values);

            // Remove 0 => world of arrays
            myCollection.RemoveAt(0);
            Assert.Equal(TestArray.Length - 2, myCollection.Count);
            targetArray =  new string [] {"world", "of", "arrays"}; 
            Assert.Equal(targetArray, myCollection.Values);

            // Remove 2 => world of
            myCollection.RemoveAt(2);
            Assert.Equal(TestArray.Length - 3, myCollection.Count);
            targetArray =  new string [] {"world", "of"}; 
            Assert.Equal(targetArray, myCollection.Values);
        }
    }
}
