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
}