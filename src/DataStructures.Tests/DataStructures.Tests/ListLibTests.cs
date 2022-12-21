using DataStructuresLib;
using Xunit;

namespace DataStructures.Tests;

public class ListLibTests
{
    [Fact]
    public void ListLib_ShouldReturnZeroSizeWhenNothingIsAdded()
    {
        ListLib<string> listLib = new ListLib<string>();
        Assert.True(listLib.Count.Equals(0));
    }

    [Fact]
    public void ListLib_Add_ShouldReturnCorrectValuesWhenAddingAnItem()
    {
        ListLib<string> listLib = new ListLib<string>();

        listLib.Add("Tyrion");
        listLib.Add("John");

        var quantityListLib = listLib.Count;

        Assert.Equal("Tyrion", listLib[0]);
        Assert.Equal("John", listLib[1]);
        Assert.Equal(2, quantityListLib);
    }

    [Fact]
    public void ListLib_Add_MustGuaranteeSpaceWhenAddingManyItens()
    {
        ListLib<string> listLib = new ListLib<string>();

        listLib.Add("Cersei");
        listLib.Add("Daenerys");
        listLib.Add("Tyrion");
        listLib.Add("John");

        var quantityListLib = listLib.Count;

        Assert.Equal("Cersei", listLib[0]);
        Assert.Equal("John", listLib[3]);
        Assert.Equal(4, quantityListLib);
    }
}