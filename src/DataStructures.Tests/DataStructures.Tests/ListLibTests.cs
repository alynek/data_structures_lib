using DataStructuresLib;
using Xunit;

namespace DataStructures.Tests;

public class ListLibTests
{
    [Fact(DisplayName = "Instantiate an empty list")]
    public void ListLib_ShouldReturnEmptyWhenToInstantiateEmpty()
    {
        ListLib<string> listLib = new ListLib<string>();
        Assert.Empty(listLib);
    }

    [Fact(DisplayName = "Add itens to list")]
    public void ListLib_Add_ShouldReturnCorrectValuesWhenAddingAnItem()
    {
        ListLib<string> listLib = new ListLib<string>();

        listLib.Add("Tyrion");
        listLib.Add("John");

        Assert.Equal("Tyrion", listLib[0]);
        Assert.Equal("John", listLib[1]);
        Assert.Equal(2, listLib.Count);
    }

    [Fact(DisplayName = "Resize list when adding items")]
    public void ListLib_Add_MustGuaranteeSpaceWhenAddingManyItems()
    {
        ListLib<string> listLib = new ListLib<string>();

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
        ListLib<string> listLib = new ListLib<string>();

        listLib.Add("James");
        listLib.Insert(0, "Brienne");

        Assert.Equal("Brienne", listLib[0]);
        Assert.Equal("James", listLib[1]);
        Assert.True(listLib.Count.Equals(2));
    }

    [Fact(DisplayName = "Clear a non-empty list")]
    public void ListLib_Clear_ShouldReturnAnEmptyList()
    {
        ListLib<string> listLib = new ListLib<string>() { "James" };

        listLib.Clear();

        Assert.Empty(listLib);
    }

    [Fact (DisplayName = "Find an item in the list")]
    public void ListLib_Contains_ShouldReturnTrueWhenFindsTheItemInTheList()
    {
        ListLib<string> listLib = new ListLib<string>() { "Arya", "Bran"};

        Assert.True(listLib.Contains("Bran"));
    }

    [Fact(DisplayName= "Not find an item in the list")]
    public void ListLib_Contains_ShouldReturnFalseWhenItDoesntFindTheItemInTheList()
    {
        ListLib<string> listLib = new ListLib<string>() { "Arya"};

        Assert.False(listLib.Contains("Bran"));
    }
}