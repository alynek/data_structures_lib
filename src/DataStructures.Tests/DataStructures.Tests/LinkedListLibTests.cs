using System;
using DataStructuresLib;
using Xunit;

namespace DataStructures.Tests
{
    public class LinkedListLibTests
    {
        public LinkedListLib<string> linkedList;
        public LinkedListLibTests()
        {
            linkedList = new LinkedListLib<string>();
        }

        [Fact(DisplayName = "Add first with empty list")]
        public void LinkedListLib_AddFirst_AddAtBeginningWhenTheLinkedListIsEmpty()
        {
            linkedList.AddFirst("Debian");

            Assert.True(linkedList.Count == 1);
            Assert.Equal("Debian", linkedList.First.Value);
            Assert.Equal("Debian", linkedList.Last.Value);
        }

        [Fact(DisplayName = "Add first with non-empty list")]
        public void LinkedListLib_AddFirst_AddAtBeginningWhenTheLinkedListIsNotEmpty()
        {
            linkedList.AddFirst("Linux Mint");
            linkedList.AddFirst("Arch");

            Assert.True(linkedList.Count == 2);
            Assert.Equal("Arch", linkedList.First.Value);
            Assert.Equal("Linux Mint", linkedList.Last.Value);
        }

        [Fact(DisplayName = "Add Last with non-empty list")]
        public void LinkedListLib_AddLast_AddAtTheEndWhenTheLinkedListIsNotEmpty()
        {
            linkedList.AddLast("Fedora");
            linkedList.AddLast("Slackware");

            Assert.True(linkedList.Count == 2);
            Assert.Equal("Fedora", linkedList.First.Value);
            Assert.Equal("Slackware", linkedList.Last.Value);
        }

        [Fact(DisplayName = "Add Last and Add First with non-empty list")]
        public void LinkedListLib_AddLast_AddAtTheEndAndTheBeginningWhenTheLinkedListIsNotEmpty()
        {
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
            linkedList.AddLast("Pop!_OS");

            Assert.True(linkedList.Count == 1);
            Assert.Equal("Pop!_OS", linkedList.First.Value);
            Assert.Equal("Pop!_OS", linkedList.Last.Value);
        }

        [Fact(DisplayName = "Contains with empty list")]
        public void LinkedListLib_Contains_ShouldReturnFalseWhenTheLinkedListIsEmpty()
        {
            Assert.False(linkedList.Contains("Ubuntu"));
        }

        [Fact(DisplayName = "Contains with non-empty list")]
        public void LinkedListLib_Contains_ShouldReturnTrueWhenTheLinkedListIsNotEmpty()
        {
            linkedList.AddFirst("Ubuntu");

            Assert.True(linkedList.Contains("Ubuntu"));
        }

        [Fact(DisplayName = "Contains does not match with non-empty list")]
        public void LinkedListLib_Contains_ShouldReturnFalseWhenNotFoundAnItem()
        {
            linkedList.AddFirst("Debian");

            Assert.False(linkedList.Contains("Ubuntu"));
        }

        [Fact(DisplayName = "Find method return a valid Node")]
        public void LinkedListLib_Find_ShouldReturnAnExistingNode()
        {
            linkedList.AddFirst("RedHat");

            var element = linkedList.Find("RedHat");

            Assert.NotNull(element.Value);
        }

        [Fact(DisplayName = "Find method return a null Node")]
        public void LinkedListLib_Find_ShouldReturnNullWhenNotFindTheElement()
        {
            var element = linkedList.Find("RedHat");

            Assert.Null(element?.Value);
        }

        [Fact(DisplayName = "Remove from the beginning and make the list empty")]
        public void LinkedListLib_RemoveFirst_ShouldRemoveElementWhenListHasOneElement()
        {
            linkedList.AddFirst("Kurumin");
            linkedList.RemoveFirst();

            Assert.Null(linkedList.First);
            Assert.True(linkedList.Count.Equals(0));
        }

        [Fact(DisplayName = "Remove from the beginning")]
        public void LinkedListLib_RemoveFirst_ShouldRemoveElementWhenListHasMoreThanOneElement()
        {
            linkedList.AddFirst("Kali linux");
            linkedList.AddFirst("Alpine");
            linkedList.RemoveFirst();

            Assert.True(linkedList.First.Value == "Kali linux");
            Assert.True(linkedList.Count.Equals(1));
        }

        [Fact(DisplayName = "Remove from the Last and make the list empty")]
        public void LinkedListLib_RemoveLast_ShouldRemoveElementWhenListHasOneElement()
        {
            linkedList.AddFirst("Mandriva linux");
            linkedList.RemoveLast();

            Assert.Null(linkedList.First);
            Assert.True(linkedList.Count.Equals(0));
        }

        [Fact(DisplayName = "Remove from the Last")]
        public void LinkedListLib_RemoveLast_ShouldRemoveElementWhenListHasMoreThanOneElement()
        {
            linkedList.AddFirst("Mandriva linux");
            linkedList.AddFirst("OpenSUSE");
            linkedList.AddFirst("Mageia");
            linkedList.RemoveLast();

            Assert.True(linkedList.First.Value == "Mageia");
            Assert.True(linkedList.Last.Value == "OpenSUSE");
            Assert.True(linkedList.Count.Equals(2));
        }

        [Fact(DisplayName = "Removing from the end causes an InvalidOperationException")]
        public void LinkedListLib_RemoveLast_ShouldReturnAnExceptionWhenListIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => linkedList.RemoveLast());
        }

        [Fact(DisplayName = "Remove return false when list is empty")]
        public void LinkedListLib_Remove_ShouldReturnFalseWhenListIsEmpty()
        {

            var isRemoved = linkedList.Remove("Minix");
            Assert.False(isRemoved);
            Assert.True(linkedList.Count == 0);
        }

        [Fact(DisplayName = "Remove return false when not found an item")]
        public void LinkedListLib_Remove_ShouldReturnFalseWhenNotFindAnItem()
        {
            linkedList.AddFirst("Gentoo");
            var isRemoved = linkedList.Remove("Minix");
            Assert.False(isRemoved);
            Assert.True(linkedList.Count == 1);
        }

        [Fact(DisplayName = "Remove return true and clears list")]
        public void LinkedListLib_Remove_ShouldReturnTrueWhenFindAnItemAndClearsTheList()
        {
            linkedList.AddFirst("Gentoo");
            var isRemoved = linkedList.Remove("Gentoo");
            Assert.True(isRemoved);
            Assert.True(linkedList.Count == 0);
        }

        [Fact(DisplayName = "Remove return true when find an item in the middle")]
        public void LinkedListLib_Remove_ShouldReturnTrueWhenFindAnItemInTheMiddle()
        {
            linkedList.AddFirst("Gentoo");
            linkedList.AddLast("Ubuntu");
            linkedList.AddLast("Linux Mint");

            var isRemoved = linkedList.Remove("Ubuntu");

            Assert.True(isRemoved);
            Assert.True(linkedList.Count == 2);
        }

        [Fact(DisplayName = "Remove return true when find an item at the beginning")]
        public void LinkedListLib_Remove_ShouldReturnTrueWhenFindAnItemAtTheBeginning()
        {
            linkedList.AddFirst("Gentoo");
            linkedList.AddLast("Ubuntu");
            linkedList.AddLast("Linux Mint");

            var isRemoved = linkedList.Remove("Gentoo");

            Assert.True(isRemoved);
            Assert.True(linkedList.Count == 2);
        }

        [Fact(DisplayName = "Remove return true when find an item at the end")]
        public void LinkedListLib_Remove_ShouldReturnTrueWhenFindAnItemAtTheEnd()
        {
            linkedList.AddFirst("Gentoo");
            linkedList.AddLast("Ubuntu");
            linkedList.AddLast("Linux Mint");

            var isRemoved = linkedList.Remove("Linux Mint");

            Assert.True(isRemoved);
            Assert.True(linkedList.Count == 2);
        }
    }
}