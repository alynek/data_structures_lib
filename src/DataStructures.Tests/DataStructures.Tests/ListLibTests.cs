using DataStructuresLib;
using Xunit;

namespace DataStructures.Tests;

public class ListLibTests
{
    [Fact]
    public void ListLib_Print_ShouldPrintEmptyWhenNothingIsAdded()
    {
        ListLib<string> listLib = new ListLib<string>();
        Assert.Equal(listLib.Print(), "");
    }

    [Fact]
    public void ListLib_Add_ShouldReturnCorrectValuesWhenAddingAnItemToTheList()
    {
        ListLib<string> listLib = new ListLib<string>();

        listLib.Add("Tyrion");
        listLib.Add("John");

        var quantityListLib = listLib.Count;

        Assert.Contains("[Tyrion, John]", listLib.Print());
        Assert.Equal(2, quantityListLib);
    }
}