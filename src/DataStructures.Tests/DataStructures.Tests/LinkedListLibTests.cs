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
            Assert.Equal("Debian", linkedList.Last.Value);
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

        [Fact(DisplayName = "Add Last with non-empty list")]
        public void LinkedListLib_AddLast_AddAtTheEndWhenTheLinkedListIsNotEmpty()
        {
            LinkedListLib<string> linkedList = new LinkedListLib<string>();

            linkedList.AddLast("Fedora");
            linkedList.AddLast("Slackware");

            Assert.True(linkedList.Count == 2);
            Assert.Equal("Fedora", linkedList.First.Value);
            Assert.Equal("Slackware", linkedList.Last.Value);
        }

        [Fact(DisplayName = "Add Last and Add First with non-empty list")]
        public void LinkedListLib_AddLast_AddAtTheEndAndTheBeginningWhenTheLinkedListIsNotEmpty()
        {
            LinkedListLib<string> linkedList = new LinkedListLib<string>();

            linkedList.AddLast("Fedora");
            linkedList.AddLast("Slackware");
            linkedList.AddFirst("Arch");

            Assert.True(linkedList.Count == 3);
            Assert.Equal("Arch", linkedList.First.Value);
            Assert.Equal("Slackware", linkedList.Last.Value);
        }

        [Fact(DisplayName = "Add Last with empty list")]
        public void LinkedListLib_AddLast_AddAtTheEndWhenTheLinkedListIsEmpty()
        {
            LinkedListLib<string> linkedList = new LinkedListLib<string>();

            linkedList.AddLast("Pop!_OS");

            Assert.True(linkedList.Count == 1);
            Assert.Equal("Pop!_OS", linkedList.First.Value);
            Assert.Equal("Pop!_OS", linkedList.Last.Value);
        }
    }
}