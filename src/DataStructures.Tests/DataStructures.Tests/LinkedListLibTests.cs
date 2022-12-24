using DataStructuresLib;
using Xunit;

namespace DataStructures.Tests
{
    public class LinkedListLibTests
    {
        [Fact(DisplayName = "Add first with empty list")]
        public void LinkedListLib_AddFirst_AddAtBeginningWhenTheLinkedListIsEmpty()
        {
            LinkedListLib<string> linkedList = new LinkedListLib<string>();

            linkedList.AddFirst("Debian");

            Assert.True(linkedList.Count == 1);
            Assert.Equal("Debian", linkedList.First.Value);
        }

        [Fact(DisplayName = "Add first with non-empty list")]
        public void LinkedListLib_AddFirst_AddAtBeginningWhenTheLinkedListIsNotEmpty()
        {
            LinkedListLib<string> linkedList = new LinkedListLib<string>();

            linkedList.AddFirst("Linux Mint");
            linkedList.AddFirst("Arch");

            Assert.True(linkedList.Count == 2);
            Assert.Equal("Arch", linkedList.First.Value);
            Assert.Equal("Linux Mint", linkedList.Last.Value);
        }
    }
}