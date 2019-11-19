using System;
using Isen.Dotnet.Library;
using Xunit;

namespace Isen.Dotnet.UnitTests
{
    public class MyCollectionStringTests
    {
        private static string [] TestArray => 
            new string[] { "Hello", "world", "of", "useless", "arrays" };
        private static MyCollection<string> BuildTestList()
        {
            var myCollection = new MyCollection<string>();
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
        [Fact]
        public void RemoveTest()
        {
            // Créer des jeux de test avec mot en double
            var testArray = new string[] {
                 "Hello", "world", "of", "of", 
                 "useless", "arrays" };
            var myCollection = new MyCollection<string>();
            foreach (var item in testArray) myCollection.Add(item);

            // Remove à la fin
            { // bloc de scope
                var removeRes = myCollection.Remove("arrays");
                var expected = new string[] {
                    "Hello", "world", "of", "of", 
                    "useless" };
                Assert.True(removeRes);
                Assert.Equal(expected, myCollection.Values);
            }
            { // bloc de scope
                var removeRes = myCollection.Remove("of");
                var expected = new string[] {
                    "Hello", "world", "of", 
                    "useless" };
                Assert.True(removeRes);
                Assert.Equal(expected, myCollection.Values);
            }
            { // bloc de scope
                var removeRes = myCollection.Remove("Hello");
                var expected = new string[] {
                    "world", "of", 
                    "useless" };
                Assert.True(removeRes);
                Assert.Equal(expected, myCollection.Values);
            }
            { // bloc de scope
                var removeRes = myCollection.Remove("fdsd");
                var expected = new string[] {
                    "world", "of", 
                    "useless" };
                Assert.False(removeRes);
                Assert.Equal(expected, myCollection.Values);
            }
        }

        [Fact]
        public void InsertTest()
        {
            var myCollection = BuildTestList();
            // insert au milieu
            myCollection.Insert(3, "very");
            var expected = new string[] { 
                "Hello", "world", "of", "very", 
                "useless", "arrays" };
            Assert.Equal(expected, myCollection.Values);
            // Insert à la fin
            myCollection.Insert(6, "!");
            expected = new string[] { 
                "Hello", "world", "of", 
                "very", "useless", "arrays", "!" };
            Assert.Equal(expected, myCollection.Values);
            // Insert au début
            myCollection.Insert(0, "");
            expected = new string[] { 
                "", "Hello", "world", "of", 
                "very", "useless", "arrays", "!" };
            Assert.Equal(expected, myCollection.Values);
        }

        [Fact]
        public void ClearTest()
        {
            var myCollection = BuildTestList();
            myCollection.Clear();
            Assert.Empty(myCollection);
        }

        [Fact]
        public void EnumerableTest()
        {
            var myCollection = BuildTestList();
            var loops = 0;
            var lastItem = "";
            foreach(var item in myCollection)
            {
                lastItem = item;
                loops++;
            }
            Assert.Equal(myCollection.Count, loops);
            Assert.Equal("arrays", lastItem);
        }
    }
}
