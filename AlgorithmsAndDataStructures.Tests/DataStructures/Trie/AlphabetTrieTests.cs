using AlgorithmsAndDataStructures.DataStructures.Trie;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Trie;

public class AlphabetTrieTests
{
    [Fact]
    public void CanConstructTree()
    {
        var sut = new AlphabetTrie();
        sut.Insert("abba");
        sut.Insert("abca");
        sut.Insert("bbca");
        sut.Insert("bbcz");
    }

    [Fact]
    public void CanSearchInTree()
    {
        var sut = new AlphabetTrie();
        sut.Insert("there");
        sut.Insert("answer");
        sut.Insert("bye");
        sut.Insert("any");

        Assert.True(sut.Search("any"));
        Assert.False(sut.Search("anz"));
    }

    [Fact]
    public void CanDelete()
    {
        var sut = new AlphabetTrie();
        //sut.Insert("there");
        sut.Insert("answer");
        sut.Insert("bye");
        sut.Insert("any");

        Assert.True(sut.Search("any"));
        Assert.True(sut.Search("answer"));

        sut.Delete("any");
        sut.Delete("bye");

        Assert.False(sut.Search("any"));
        Assert.True(sut.Search("answer"));
        Assert.False(sut.Search("bye"));
    }

    [Fact]
    public void CanDeleteRoot()
    {
        var sut = new AlphabetTrie();
        sut.Insert("any");

        Assert.True(sut.Search("any"));

        sut.Delete("any");

        Assert.False(sut.Search("any"));
    }
}