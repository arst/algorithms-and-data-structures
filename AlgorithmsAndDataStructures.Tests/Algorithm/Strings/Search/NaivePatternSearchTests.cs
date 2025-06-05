﻿using AlgorithmsAndDataStructures.Algorithms.Strings.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Strings.Search;

public class NaivePatternSearchTests : StringSearchAlgorithmBaseTests
{
    protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
    {
        return new NaivePatternSearch();
    }
}