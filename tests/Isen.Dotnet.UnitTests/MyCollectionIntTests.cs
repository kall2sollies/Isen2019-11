using Isen.Dotnet.Library;
using Xunit;

namespace Isen.Dotnet.UnitTests
{
    public class MyCollectionIntTests
    {
        private static int [] TestArray => 
            new int[] { 10, 20, 30, 40, 50 };
        private static MyCollection<int> BuildTestList()
        {
            var myCollection = new MyCollection<int>();
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
            Assert.Equal(0, myCollection.IndexOf(10));
            Assert.Equal(1, myCollection.IndexOf(20));
            Assert.Equal(2, myCollection.IndexOf(30));
            Assert.True(myCollection.IndexOf(42) < 0);
        }

        [Fact]
        public void IndexorTest()
        {
            var myCollection = BuildTestList();
            Assert.Equal(10, myCollection[0]);
            Assert.Equal(20, myCollection[1]);
            Assert.Equal(30, myCollection[2]);
        }

        [Fact]
        public void RemoveAtTest()
        {
            // 10 20 30 40 50
            var myCollection = BuildTestList();
            // Remove 3 => 10 20 40 50
            myCollection.RemoveAt(2);
            Assert.Equal(TestArray.Length - 1, myCollection.Count);
            var targetArray =  new int [] {
                10, 20, 40, 50}; 
            Assert.Equal(targetArray, myCollection.Values);

            // Remove 0 => 20 40 50
            myCollection.RemoveAt(0);
            Assert.Equal(TestArray.Length - 2, myCollection.Count);
            targetArray =  new int [] {
                20, 40, 50}; 
            Assert.Equal(targetArray, myCollection.Values);

            // Remove 2 => 20 40
            myCollection.RemoveAt(2);
            Assert.Equal(TestArray.Length - 3, myCollection.Count);
            targetArray =  new int [] {20, 40}; 
            Assert.Equal(targetArray, myCollection.Values);
        }

        [Fact]
        public void RemoveTest()
        {
            // Créer des jeux de test avec mot en double
            var testArray = new int[] {
                 10, 20, 30, 30, 40, 50 };
            var myCollection = new MyCollection<int>();
            foreach (var item in testArray) myCollection.Add(item);

            // Remove à la fin
            { // bloc de scope
                var removeRes = myCollection.Remove(50);
                var expected = new int[] {
                 10, 20, 30, 30, 40 };
                Assert.True(removeRes);
                Assert.Equal(expected, myCollection.Values);
            }
            { // bloc de scope
                var removeRes = myCollection.Remove(30);
                var expected = new int[] {
                 10, 20, 30, 40 };
                Assert.True(removeRes);
                Assert.Equal(expected, myCollection.Values);
            }
            { // bloc de scope
                var removeRes = myCollection.Remove(10);
                var expected = new int[] {
                  20, 30, 40 };
                Assert.True(removeRes);
                Assert.Equal(expected, myCollection.Values);
            }
            { // bloc de scope
                var removeRes = myCollection.Remove(42);
                var expected = new int[] {
                  20, 30, 40 };
                Assert.False(removeRes);
                Assert.Equal(expected, myCollection.Values);
            }
        }

        [Fact]
        public void ClearTest()
        {
            var myCollection = BuildTestList();
            myCollection.Clear();
            Assert.Empty(myCollection);
        }

        [Fact]
        public void InsertTest()
        {
            var myCollection = BuildTestList();
            // 10, 20, 30, 40, 50
            // insert au milieu
            myCollection.Insert(3, 35);
            var expected = new int[] { 
                10, 20, 30, 35, 40, 50 };
            Assert.Equal(expected, myCollection.Values);
            // Insert à la fin
            myCollection.Insert(6, 60);
            expected = new int[] { 
                10, 20, 30, 35, 40, 50, 60 };
            Assert.Equal(expected, myCollection.Values);
            // Insert au début
            myCollection.Insert(0, 0);
            expected = new int[] { 
                0, 10, 20, 30, 35, 40, 50, 60 };
            Assert.Equal(expected, myCollection.Values);
        }
    
        [Fact]
        public void EnumerableTest()
        {
            var myCollection = BuildTestList();
            var loops = 0;
            var lastItem = int.MaxValue;
            foreach(var item in myCollection)
            {
                lastItem = item;
                loops++;
            }
            Assert.Equal(myCollection.Count, loops);
            Assert.Equal(50, lastItem);
        }
    }
}