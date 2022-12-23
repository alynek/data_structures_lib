using DataStructuresLib;
using Xunit;

namespace DataStructures.Tests
{
    public class LinkedListLibTests
    {
        [Fact]
        public void Test1()
        {
            LinkedListLib<string> linkedList = new LinkedListLib<string>();

            linkedList.AddFirst("Debian");

            Assert.True(linkedList.Count == 1);
            Assert.Equal("Debian", linkedList.First.Value);
        }
    }
}