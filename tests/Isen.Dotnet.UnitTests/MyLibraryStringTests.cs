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
            Assert.Equal(BuildTestList().Values, TestArray);
    }
}
