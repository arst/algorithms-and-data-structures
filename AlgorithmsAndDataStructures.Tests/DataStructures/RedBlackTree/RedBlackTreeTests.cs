﻿using System;
using AlgorithmsAndDataStructures.DataStructures.RbTree;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.RedBlackTree;

public class RedBlackTreeTests
{
    private readonly ITestOutputHelper helper;

    public RedBlackTreeTests(ITestOutputHelper output)
    {
        helper = output;
    }

    [Fact]
    public void EmptyTreeIsBalanced()
    {
        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree();

        sut.CheckTreeValidity();
    }

    [Fact]
    public void EmptyTreeHasZeroHeight()
    {
        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree();

        Assert.Equal(0, sut.Height);
        sut.CheckTreeValidity();
    }

    [Fact]
    public void CanInsertRootNode()
    {
        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree();
        sut.Insert(3);

        Assert.Equal(0, sut.Height);
        sut.CheckTreeValidity();
    }

    [Fact]
    public void TreeIsBalancedWhenLeftSideUnbalanced()
    {
        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree();
        sut.Insert(5);
        sut.Insert(4);
        sut.Insert(3);

        Assert.Equal(1, sut.Height);
        sut.CheckTreeValidity();
    }

    [Fact]
    public void TreeIsBalancedWhenRightSideUnbalanced()
    {
        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree();
        sut.Insert(5);
        sut.Insert(6);
        sut.Insert(7);

        Assert.Equal(1, sut.Height);
        sut.CheckTreeValidity();
    }

    [Fact]
    public void TreeIsBalancedWhenLeftRightSideUnbalanced()
    {
        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree();
        sut.Insert(5);
        sut.Insert(3);
        sut.Insert(4);

        Assert.Equal(1, sut.Height);
        sut.CheckTreeValidity();
    }

    [Fact]
    public void TreeIsBalancedWhenRightLeftSideUnbalanced()
    {
        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree();
        sut.Insert(3);
        sut.Insert(5);
        sut.Insert(4);

        Assert.Equal(1, sut.Height);
        sut.CheckTreeValidity();
    }

    [Fact]
    public void TreeIsBalancedWhenCase2Deletion()
    {
        var root = new RedBlackTreeNode();
        root.IsRed = false;
        root.Value = 10;

        root.Left = new RedBlackTreeNode
        {
            Parent = root,
            IsRed = false,
            Value = -10
        };
        root.Left.Left = new RedBlackTreeNode
        {
            Parent = root.Left,
            IsRed = false,
            Value = -20
        };
        root.Left.Right = new RedBlackTreeNode
        {
            Parent = root.Left,
            IsRed = false,
            Value = -5
        };

        root.Right = new RedBlackTreeNode
        {
            Parent = root,
            IsRed = false,
            Value = 40
        };
        root.Right.Left = new RedBlackTreeNode
        {
            Parent = root.Right,
            IsRed = false,
            Value = 20
        };
        root.Right.Right = new RedBlackTreeNode
        {
            Parent = root.Right,
            IsRed = true,
            Value = 60
        };
        root.Right.Right.Left = new RedBlackTreeNode
        {
            Parent = root.Right.Right,
            IsRed = false,
            Value = 50
        };
        root.Right.Right.Right = new RedBlackTreeNode
        {
            Parent = root.Right.Right,
            IsRed = false,
            Value = 80
        };

        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree(root);
        sut.Delete(10);

        sut.CheckTreeValidity();
    }

    [Fact]
    public void TreeIsBalancedWhenCase3Deletion()
    {
        var root = new RedBlackTreeNode();
        root.IsRed = false;
        root.Value = 10;
        root.Left = new RedBlackTreeNode
        {
            Parent = root,
            IsRed = false,
            Value = -10
        };
        root.Right = new RedBlackTreeNode
        {
            Parent = root,
            IsRed = false,
            Value = 30
        };

        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree(root);
        sut.Delete(-10);

        sut.CheckTreeValidity();
    }

    [Fact]
    public void TreeIsBalancedWhenCase4Deletion()
    {
        var root = new RedBlackTreeNode();
        root.IsRed = false;
        root.Value = 10;
        root.Left = new RedBlackTreeNode
        {
            Parent = root,
            IsRed = false,
            Value = -10
        };
        root.Right = new RedBlackTreeNode
        {
            Parent = root,
            IsRed = true,
            Value = 30
        };
        root.Right.Left = new RedBlackTreeNode
        {
            Parent = root.Right,
            IsRed = false,
            Value = 20
        };
        root.Right.Right = new RedBlackTreeNode
        {
            Parent = root.Right,
            IsRed = false,
            Value = 38
        };

        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree(root);
        sut.Delete(20);

        sut.CheckTreeValidity();
    }

    [Fact]
    public void TreeIsBalancedWhenCase6Deletion()
    {
        var root = new RedBlackTreeNode();
        root.IsRed = false;
        root.Value = 10;
        root.Left = new RedBlackTreeNode
        {
            Parent = root,
            IsRed = false,
            Value = -10
        };
        root.Right = new RedBlackTreeNode
        {
            Parent = root,
            IsRed = false,
            Value = 30
        };
        root.Right.Left = new RedBlackTreeNode
        {
            Parent = root.Right,
            IsRed = true,
            Value = 25
        };
        root.Right.Right = new RedBlackTreeNode
        {
            Parent = root.Right,
            IsRed = true,
            Value = 40
        };

        var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree(root);
        sut.Delete(-10);

        sut.CheckTreeValidity();
    }

    [Fact]
    public void TreeIsRebalanacedAfterDelete()
    {
        for (var i = 0; i < 100; i++)
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.RbTree.RedBlackTree();
            var random = new Random();
            var seed = new int[1000];

            for (var j = 0; j < seed.Length; j++)
            {
                seed[j] = random.Next(seed.Length * 10);
                sut.Insert(seed[j]);
                sut.CheckTreeValidity();
            }

            for (var z = 0; z < seed.Length; z++)
            {
                sut.Delete(seed[z]);
                sut.CheckTreeValidity();
            }
        }
    }
}