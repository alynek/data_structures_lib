using System;
using DataStructuresLib;
using Xunit;

namespace DataStructures.Tests;

public class ListLibTests
{
    public ListLib<string> listLib;
    public ListLibTests()
    {
        listLib = new ListLib<string>();
    }

    [Fact(DisplayName = "Instantiate an empty list")]
    public void ListLib_ShouldReturnEmptyWhenToInstantiateEmpty()
    {
        Assert.Empty(listLib);
    }

    [Fact(DisplayName = "Add itens to list")]
    public void ListLib_Add_ShouldReturnCorrectValuesWhenAddingAnItem()
    {
        listLib.Add("Tyrion");
        listLib.Add("John");

        Assert.Equal("Tyrion", listLib[0]);
        Assert.Equal("John", listLib[1]);
        Assert.Equal(2, listLib.Count);
    }

    [Fact(DisplayName = "Resize list when adding items")]
    public void ListLib_Add_MustGuaranteeSpaceWhenAddingManyItems()
    {
        listLib.Add("Cersei");
        listLib.Add("Daenerys");
        listLib.Add("Tyrion");
        listLib.Add("John");

        Assert.Equal("Cersei", listLib[0]);
        Assert.Equal("John", listLib[3]);
        Assert.Equal(4, listLib.Count);
    }

    [Fact(DisplayName = "Ensure insert at the beginning of the list")]
    public void ListLib_Insert_ShouldReturnCorrectValueWhenInsertAnItemWithAIndex()
    {
        listLib.Add("Jaime");
        listLib.Insert(0, "Brienne");
        listLib.Insert(2, "Hodor");

        Assert.Equal("Brienne", listLib[0]);
        Assert.Equal("Jaime", listLib[1]);
        Assert.Equal("Hodor", listLib[2]);
        Assert.True(listLib.Count.Equals(3));
    }

    [Fact(DisplayName = "Clear a non-empty list")]
    public void ListLib_Clear_ShouldReturnAnEmptyList()
    {
        listLib.Insert(0, "Jaime");
        Assert.NotEmpty(listLib);

        listLib.Clear();
        Assert.Empty(listLib);
    }

    [Fact (DisplayName = "Find an item in the list")]
    public void ListLib_Contains_ShouldReturnTrueWhenFindsTheItemInTheList()
    {
        listLib.Add("Arya");
        listLib.Add("Bran");

        Assert.True(listLib.Contains("Bran"));
    }

    [Fact(DisplayName = "Not find an item in the list")]
    public void ListLib_Contains_ShouldReturnFalseWhenItDoesntFindTheItemInTheList()
    {
        listLib.Add("Arya");

        Assert.False(listLib.Contains("Bran"));
    }    

    [Fact(DisplayName = "Return an index of an item")]
    public void LisLib_IndexOf_ShouldReturnAnIndexOfAnItem()
    {
        listLib.Add("Sansa");

        Assert.Equal(listLib.IndexOf("Sansa"), 0);
    }

    [Fact(DisplayName = "Return -1 because the item doesn't exists in the list")]
    public void LisLib_IndexOf_ShouldReturnMinusOneWhenItDoesntFindTheItem()
    {
        Assert.Equal(listLib.IndexOf("Sansa"), -1);
    }

    [Fact(DisplayName = "AddRange add a list inside another list")]
    public void ListLib_AddRange_MustJoinTheTwoLists()
    {
        var hobbits = new ListLib<string>{"Bilbo", "Sam", "Frodo"};

        listLib.Add("Tyrion");
        listLib.Add("John");

        listLib.AddRange(hobbits);

        Assert.Equal(listLib.Count, 5);
    }

    [Fact(DisplayName = "AddRange return an ArgumentNullException")]
    public void ListLib_AddRange_ShouldReturnExceptionWhenListIsNull()
    {
        ListLib<string> hobbits = null;

        listLib.Add("Tyrion");
        listLib.Add("John");
        
        Assert.Throws<ArgumentNullException>(() => listLib.AddRange(hobbits));
    }

    [Fact(DisplayName = "Remove an item of the list")]
    public void ListLib_RemoveAt_ShouldRemoveAnItem()
    {
        listLib.Add("Tyrion");

        listLib.RemoveAt(0);

        Assert.True(listLib.Count == 0);
    }

    [Fact(DisplayName = "RemoveAt return an ArgumentOutOfRangeException")]
    public void ListLib_RemoveAt_ShouldReturnAnExceptionWhenIsAnInvalidIndex()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => listLib.RemoveAt(0));
    }

    [Fact(DisplayName = "Remove an item")]
    public void ListLib_Remove_ShouldReturnTrueWhenRemoveAnItem()
    {
        listLib.Add("Gandalf");
        
        Assert.True(listLib.Remove("Gandalf"));
    }

    [Fact(DisplayName = "Does not remove when it does not find an item")]
    public void ListLib_Remove_ShouldReturnFalseWhenNotRemovingAnItem()
    {        
        Assert.False(listLib.Remove("Gandalf"));
    }

    [Fact(DisplayName = "Remove two items starting from index 2")]
    public void ListLib_RemoveRange_ShouldRemoveTwoItemsFromTheIndexTwo()
    {        
        listLib.Add("Sauron");
        listLib.Add("Arwen");
        listLib.Add("Galadriel");
        listLib.Add("Gollum");

        listLib.RemoveRange(2, 2);

        Assert.True(listLib.Count == 2);
        Assert.True(listLib[0] == "Sauron");
        Assert.True(listLib[1] == "Arwen");
    }

    [Fact(DisplayName = "Remove an item from the last index")]
    public void ListLib_RemoveRange_ShouldRemoveTwoItensFromTheLastIndex()
    {        
        listLib.Add("Sauron");
        listLib.Add("Arwen");
        listLib.Add("Galadriel");
        listLib.Add("Gollum");

        listLib.RemoveRange(3, 1);

        Assert.True(listLib.Count == 3);
        Assert.True(listLib[0] == "Sauron");
        Assert.True(listLib[1] == "Arwen");
        Assert.True(listLib[2] == "Galadriel");
    }

    [Fact(DisplayName = "Remove two items from the first index")]
    public void ListLib_RemoveRange_ShouldRemoveTwoItensFromTheFirstIndex()
    {        
        listLib.Add("Sauron");
        listLib.Add("Arwen");
        listLib.Add("Galadriel");
        listLib.Add("Gollum");

        listLib.RemoveRange(0, 2);

        Assert.True(listLib.Count == 2);
        Assert.True(listLib[0] == "Galadriel");
        Assert.True(listLib[1] == "Gollum");
    }

    [Fact(DisplayName = "Return an ArgumentOutOfRangeException when count is invalid")]
    public void ListLib_RemoveRange_ShouldReturnAnExceptionWhenCountIsGreaterThanListCount()
    {        
        listLib.Add("Sauron");
        listLib.Add("Arwen");
        listLib.Add("Galadriel");
        listLib.Add("Gollum");

        Assert.Throws<ArgumentOutOfRangeException>(() => listLib.RemoveRange(2, 4));
    }

    [Fact(DisplayName = "Return an ArgumentOutOfRangeException when index is invalid")]
    public void ListLib_RemoveRange_ShouldReturnAnExceptionWhenIndexIsInvalid()
    {        
        listLib.Add("Sauron");
        listLib.Add("Arwen");
        listLib.Add("Galadriel");
        listLib.Add("Gollum");

        Assert.Throws<ArgumentOutOfRangeException>(() => listLib.RemoveRange(4, 2));
    }

    [Fact(DisplayName = "Return a Reverse list of strings")]
    public void ListLib_Reverse_ShouldReturnAReverseListOfStrings()
    {        
        listLib.Add("Sauron");
        listLib.Add("Arwen");
        listLib.Add("Galadriel");
        listLib.Add("Gollum");

        var expectedList = new ListLib<string>{"Gollum", "Galadriel",
        "Arwen", "Sauron"};

        listLib.Reverse();

        Assert.True(listLib.Count == 4);
        Assert.Equal(expectedList, listLib);
    }

    [Fact(DisplayName = "Return a Reverse list of integers")]
    public void ListLib_Reverse_ShouldReturnAReverseListOfIntegers()
    {      
        var listLib = new ListLib<uint>{1, 2, 3, 4, 5}; 

        var expectedList = new ListLib<uint>{5, 4, 3, 2, 1};

        listLib.Reverse();

        Assert.True(listLib.Count == 5);
        Assert.Equal(expectedList, listLib);
    }
}