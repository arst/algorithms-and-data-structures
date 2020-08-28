[![Build Status](https://travis-ci.com/arst/AandDS.svg?token=QTqu8xkSrAFMgyb3eyEW&branch=master)](https://travis-ci.com/arst/AandDS)
[![Known Vulnerabilities](https://snyk.io/test/github/arst/AandDS/badge.svg?targetFile=AlgorithmsAndDataStructures/AlgorithmsAndDataStructures.csproj)](https://snyk.io/test/github/arst/AandDS?targetFile=AlgorithmsAndDataStructures/AlgorithmsAndDataStructures.csproj)

:warning: The source code in this repository doesn't contain ready-to-use code. Though, I've wrote some tests and benchmarks, and even though some of them are quite extensive, I haven't spent too much time on optimizations and general usages(exception handling, generic interfaces etc.), not to mention code styles.
# Data Structures

- Queues:
    - Array based Queue ([code](../master/AlgorithmsAndDataStructures/DataStructures/Queue/ArrayQueue.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Queue/ArrayQueueTests.cs))
    - Circular Queue ([code](../master/AlgorithmsAndDataStructures/DataStructures/Queue/CircularQueue.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Queue/CircularQueueTests.cs))
    - Linked List based Queue ([code](../master/AlgorithmsAndDataStructures/DataStructures/Queue/LinkedListQueue.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Queue/LinkedListQueueTests.cs))
    - Binary Queue based Priority Queue ([code](../master/AlgorithmsAndDataStructures/DataStructures/BinaryHeaps/MinBinaryHeapBasedPriorityQueue.cs))
- Stacks:
    - Array based Stack ([code](../master/AlgorithmsAndDataStructures/DataStructures/Stack/ArrayStack.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Stack/ArrayStackTests.cs))
    - Linked List Stack ([code](../master/AlgorithmsAndDataStructures/DataStructures/Stack/LinkedListStack.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Stack/LinkedListStackTests.cs))
    - Queue based Stack ([code](../master/AlgorithmsAndDataStructures/DataStructures/Stack/QueueStack.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Stack/QueueStackTests.cs))
- Unrolled Linked List ([code](../master/AlgorithmsAndDataStructures/DataStructures/UnrolledLinkedLists/UnrolledLinkedList.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/UnrolledLinkedList/UnrolledLinkedListTests.cs))
- Linked Lists:
    - Singly Linked List ([code](../master/AlgorithmsAndDataStructures.Tests/DataStructures/LinkedList/SinglyLinkedList.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/LinkedList/SinglyLinkedListTests.cs))
    - Doubly Linked List ([code](../master/AlgorithmsAndDataStructures.Tests/DataStructures/LinkedList/DoublyLinkedList.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/LinkedList/DoublyLinkedListTests.cs))
    - Singly Circular Linked List ([code](../master/AlgorithmsAndDataStructures.Tests/DataStructures/LinkedList/SinglyCircularLinkedList.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/LinkedList/SingleCircularLinkedListTests.cs))
    - Skip List ([code](../master/AlgorithmsAndDataStructures.Tests/DataStructures/LinkedList/SkipList.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/LinkedList/SkipListTests.cs))
- Self-organizing Lists:
    - Count based Self-organizing List ([code](../master/AlgorithmsAndDataStructures/DataStructures/SelfOrganizingList/CountBasedSelfOrganizingList.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/SelfOrginizingList/CountBasedSelfOrganizingListTests.cs))
    - Move to forward Self-organizing List ([code](../master/AlgorithmsAndDataStructures/DataStructures/SelfOrganizingList/MoveToForwardSelfOrganizingList.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/SelfOrginizingList/MoveToForwardSelfOrganizingListTests.cs))
    - Transpose Self-organizing List ([code](../master/AlgorithmsAndDataStructures/DataStructures/SelfOrganizingList/TransposeSelfOrginizingList.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/SelfOrginizingList/TransposeSelfOrginizingListTests.cs))
- Hash Tables: 
    - Separate chaining ([code](../master/AlgorithmsAndDataStructures/DataStructures/HashTable/SeparateChainingHashTable.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/SelfOrginizingList/SeparateChainingHashTableTests.cs))
    - Open address hasing ([code](../master/AlgorithmsAndDataStructures/DataStructures/HashTable/OpenAddressHasingHashTable.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/SelfOrginizingList/OpenAddressHashingHashTableTests.cs))
- Graphs: 
    - Adjacency matrix representation ([code](../master/AlgorithmsAndDataStructures/DataStructures/Graph/AdjacencyMatrixGraph.cs))
    - Adjacency list representation ([code](../master/AlgorithmsAndDataStructures/DataStructures/Graph/AdjacencyListGraph.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Graph/AdjacencyListGraphTests.cs))
- Binary Trees:
    - Binary Tree ([code](../master/AlgorithmsAndDataStructures/DataStructures/BinaryTrees/BinaryTree.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/BinaryTree/BinaryTreeTests.cs))
    - Array Binary Tree ([code](../master/AlgorithmsAndDataStructures/DataStructures/BinaryTrees/ArrayBinaryTree.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/BinaryTree/ArrayBinaryTreeTests.cs))
- Binary Search Tree ([code](../master/AlgorithmsAndDataStructures/DataStructures/BinarySearchTrees/BinarySearchTree.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/BinarySearchTrees/BinarySearchTreeTests.cs))
- Binary Indexed Tree ([code](../master/AlgorithmsAndDataStructures/DataStructures/BinaryIndexedTrees/BinaryIndexedTree.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/BinaryIndexedTree/BinaryIndexedTreeTests.cs))
- Binary Heaps:
    - Binary Heap ([code](../master/AlgorithmsAndDataStructures/DataStructures/BinaryHeaps/BinaryHeap.cs))
    - Max Binary Heap ([code](../master/AlgorithmsAndDataStructures/DataStructures/BinaryHeaps/MaxBinaryHeap.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/BinaryHeap/MaxBinaryHeapTests.cs))
    - Min Binary Heap ([code](../master/AlgorithmsAndDataStructures/DataStructures/BinaryHeaps/MinBinaryHeap.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/BinaryHeap/MinBinaryHeapTests.cs))
- AVL Tree ([code](../master/AlgorithmsAndDataStructures/DataStructures/AdelsonVelskyLandisTree/AvlTree.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/AvlTree/AvlTreeTests.cs))
- Red-Black Tree ([code](../master/AlgorithmsAndDataStructures/DataStructures/RbTree/RedBlackTree.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/RedBlackTree/RedBlackTreeTests.cs))
- Segment Trees:
    - Abstract Segment Tree ([code](../master/AlgorithmsAndDataStructures/DataStructures/SegmentTree/AbstractSegmentTree.cs))
    - Min Segment Tree ([code](../master/AlgorithmsAndDataStructures/DataStructures/SegmentTree/MinSegmentTree.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/SegmentTree/MinSegmentTreeTests.cs))
    - Sum Segment Tree ([code](../master/AlgorithmsAndDataStructures/DataStructures/SegmentTree/SumSegmentTree.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/SegmentTree/SumSegmentTreeTests.cs))
- Tries:
    - Trie(Alphabet Trie)  ([code](../master/AlgorithmsAndDataStructures/DataStructures/Trie/AlphabetTrie.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Trie/AlphabetTrieTests.cs))
    - Ternary Trie ([code](../master/AlgorithmsAndDataStructures/DataStructures/Trie/TernaryTrie.cs), [tests](../master/AlgorithmsAndDataStructures/DataStructures/Trie/TernaryTrieTests.cs))
- Suffix Arrays:
    - Naive ([code](../master/AlgorithmsAndDataStructures/DataStructures/SuffixArray/NaiveSuffixArray.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/SuffixArray/NaiveSuffixArrayTests.cs))
    - n*logN ([code](../master/AlgorithmsAndDataStructures/DataStructures/SuffixArray/EfficientSuffixArray.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/SuffixArray/nLognSuffixArrayTests.cs))
- Decision Trees:
    - ID3 ([code](../master/AlgorithmsAndDataStructures/DataStructures/DecisionTree/ID3.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/DecisionTree/ID3Tests.cs))
- Disjoin Sets:
    - Greedy Disjoin Set  ([code](../master/AlgorithmsAndDataStructures/DataStructures/DisjointSet/GreedyDisjointSet.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/DisjointSet/GreedyDisjointSetTests.cs))
    - Tree Disjoin Set  ([code](../master/AlgorithmsAndDataStructures/DataStructures/DisjointSet/TreeDisjointSet.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/DisjointSet/TreeDisjointSetTests.cs))
    - Weighted Tree Disjoin Set  ([code](../master/AlgorithmsAndDataStructures/DataStructures/DisjointSet/WeightedTreeDisjointSet.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/DisjointSet/WeightedTreeDisjointSetTests.cs))
    - Weighted Tree Disjoin Set with Compressed Path  ([code](../master/AlgorithmsAndDataStructures/DataStructures/DisjointSet/WeightedTreeCoompressedPathDisjoinSet.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/DisjointSet/WeightedTreeCoompressedPathDisjoinSetTests.cs))
- State Machines:
    - Simplest Finite State Machine ([code](../master/AlgorithmsAndDataStructures/DataStructures/StateMachine/FiniteStateMachine.cs))
    - Stack State Machine ([code](../master/AlgorithmsAndDataStructures/DataStructures/StateMachine/StackFiniteStateMachine.cs))
- Caches:
    - LFU ([code](../master/AlgorithmsAndDataStructures/DataStructures/Cache/LFU.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Cache/LFUTests.cs))
    - LFU(min heap based) ([code](../master/AlgorithmsAndDataStructures/DataStructures/Cache/LFUMeanHeapBased.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Cache/LFUMeanHeapBasedTests.cs))
    - LRU ([code](../master/AlgorithmsAndDataStructures/DataStructures/Cache/LRU.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Cache/LRUTests.cs))
- Buckets:
    - Simple token bucket ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/SimpleTokenBucket.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Concurrency/SimpleTokenBucketTests.cs))
    - Simple leaky bucket ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/SimpleLeakyBucket.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Concurrency/SimpleLeakyBucketTests.cs))
    
# Algorithms
- Compression:
    - Huffman Code ([code](../master/AlgorithmsAndDataStructures/Algorithms/Compression/HuffmanCodeCompression.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/HuffmanCodeCompressionTests.cs))
    - LZW - Huffman Code ([code](../master/AlgorithmsAndDataStructures/Algorithms/Compression/LzwCompression.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/LZWCompressionTests.cs))
- Cryptography:
    - Cesar Cipher ([code](../master/AlgorithmsAndDataStructures/Algorithms/Cryptography/CesarCipher.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/CesarCipherTests.cs))
    - One Time Pad ([code](../master/AlgorithmsAndDataStructures/Algorithms/Cryptography/OneTimePad.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/OneTimePadTests.cs))
- Dynamic Programming:
    - Digit DP ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/DigitDynamicProgramming.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/DigitDynamicProgrammingTests.cs))
    - 0/1 Knapsack ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/ZeroOneKnapsack.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/ZeroOneKnapsackTests.cs))
    - Undounded Knapsack ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/UnboundedKnapsack.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/UnboundedKnapsackTests.cs))
    - Fibonacci numbers Knapsack ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/FibonacciNumber.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/FibonacciNumberTests.cs))
    - Change making ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/ChangeMakingProblem.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/ChangeMakingProblemTests.cs))
    - Unique Change making ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/UniqueChangeMakingProblem.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/UniqueChangeMakingProblemTests.cs))  
    - Longest Common Subsequence ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/LongestCommonSubsequence.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/LongestCommonSubsequenceTests.cs))
    - Wine cellar ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/WineCellarProblem.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/WineCellarProblemTests.cs))
    - Caps assignment ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/CapsAssignment.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/CapsAssignmentTests.cs))
    - Represent N as sum of 1,3,4 ([code](../master/AlgorithmsAndDataStructures/Algorithms/DynamicProgramming/RepresentNasSumOf134.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Compression/RepresentNasSumOf134Tests.cs))
- Graphs:
    - Backtracking:
        - Path of more than K length ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Backtracking/PathOfMoreThanKLength.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/Backtracking/PathOfMoreThanKLengthTests.cs))
        - Hamilton's path ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Backtracking/HamiltonPath.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/Backtracking/HamiltonianCycle.cs))
        - m-coloring Problem ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Backtracking/MColoringProblem.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/Backtracking/MColoringProblemTests.cs))
    - Coloring:
        - Greedy ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Coloring/GreedyColoring.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/Coloring/GreedyColoringTests.cs))
    - K-Centers:
        - Greedy ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/KCenters/KCentersGreedyApproximation.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/KCenters/KCentersGreedyApproximationTests.cs))
    - Longest Path:
        - Critical Path ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/LongestPath/CriticalPath.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/LongestPath/CriticalPathTests.cs))
        - Longest Path In a DAG ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/LongestPath/LongestPathInADirectedAcyclicGraph.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/LongestPath/LongestPathInADirectedAcyclicGraphTests.cs))
    - Maximum Flow and Bipartite matching:
        - Dinic's algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MaximumFlow/DinicsMaximumFlow.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/DinicsMaximumFlowTests.cs))
        - Edge-Disjoint Path ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MaximumFlow/EdgeDisjointPath.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/EdgeDisjointPathTests.cs))
        - Ford-Fulkerson ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MaximumFlow/FordFulkerson.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/FordFulkersonTests.cs))
        - Ford-Fulkerson With Capacity Heuristic ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MaximumFlow/FordFulkersonWithCapacityHeuristic.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/FordFulkersonWithCapacityHeuristicTests.cs))
        - Hopcroft-Karp ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MaximumFlow/HopcroftKarp.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/HopcroftKarpTests.cs))
        - Maximum Bipartite Matching DFS-Based ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MaximumFlow/MaximumBiPartiteMatchingDfsBased.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/MaximumBiPartiteMatchingDfsBasedTests.cs))
        - Maximum Bipartite Matching Ford-Fulkerson-Based ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MaximumFlow/MaximumBiPartiteMatchingFordFulkersonBased.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/MaximumBiPartiteMatchingFordFulkersonBasedTests.cs))
        - Push-relabel ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MaximumFlow/PushRelabel.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/PushRelabelTests.cs))
    - Min Cut:
        - ST-Cut Ford-Fulkerson based ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MaximumFlow/STCutFordFulkersonBased.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/STCutFordFulkersonBasedTests.cs))
        - ST-Cut naive ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MinCut/MinSTCutNaive.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/MaxFlow/MinSTCutNaiveTests.cs))
        - Karger's algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MinCut/KargersAlgorithmForMinimumCut.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/KargersAlgorithmForMinimumCutTests.cs))
    - Minimum Spanning Tree:
        - Kruskal's algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MinimumSpanningTree/KruskalMinimumSpanningTree.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/KruskalMinimumSpanningTreeTests.cs))  
        - Kruskal's algorithm with disjoint set ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MinimumSpanningTree/KruskalMinimumSpanningTreeWithDisjointSet.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/KruskalMinimumSpanningTreeWithDisjointSetTests.cs))
        - Prim's algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/MinimumSpanningTree/PrimsAlgorithm.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/PrimsAlgorithmTests.cs))
    - Search:
        - Breadth-First-Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Search/BreadthFirstSearch.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/BreadthFirstSearchTests.cs))
        - Depth-First-Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Search/DepthFirstSearch.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/DepthFirstSearchTests.cs))
    - Shortest path:
        - Bellman-Ford Algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/ShortestPath/BellmanFord.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/BellmanFordTests.cs))
        - Dijkstra's Algorithm with heap ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/ShortestPath/DijkstraHeapified.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/DijkstraHeapifiedTests.cs))
        - Dijkstra's Algorithm naive ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/ShortestPath/DijkstraNaive.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/DijkstraNaiveTests.cs))
        - Floyd-Warshall ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/ShortestPath/FloydWarshall.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/FloydWarshallTests.cs))
    - Traveling Salesman
        - Naive ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/TravelingSalesman/NaiveTravelingSalesman.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/TravelingSalesman/NaiveTravelingSalesmanTests.cs))
        - Greedy ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/TravelingSalesman/GreedyTravelingSalesman.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/TravelingSalesman/GreedyTravelingSalesmanTests.cs))
        - Min Spanning Tree ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/TravelingSalesman/MinSpanningTreeTravelingSalesman.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/TravelingSalesman/MinSpanningTreeTravelingSalesmanTests.cs))
        - Dynamic Programming ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/TravelingSalesman/DynamicProgrammingTravelingSalesman.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/TravelingSalesman/DynamicProgrammingTravelingSalesmanTests.cs))
    - Vertex Cover:
        - Simple Approximation ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/VertexCover/VertexCoverSimpleApproximation.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/VertexCover/VertexCoverSimpleApproximationTests.cs))
    - Voting:
        - Schulze Method ([code](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/Voting/SchulzeMethodTests.cs), [tests](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Voting/SchulzeMethod.cs))
    - Misc:
        - Biconnected Graph check using Tarjan's Algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/BiconnectedGraph.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/BiconnectedGraphTests.cs))
        - Bipartite Graph check using DFS ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/BipartiteGraphDfsBased.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/BipartiteGraphDfsBasedTests.cs))
        - Bipartite Graph check using BFS ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/BipartiteGraphBfsBased.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/BipartiteGraphBfsBasedTests.cs))
        - Bridges in Graph check using Tarjan's Algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/BridgesInGraph.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/BridgesInGraphTests.cs))
        - Cycles in Graph check using DFS ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/CycleDetector.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/CycleDetectionTests.cs))
        - Eulerian Path ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/EulerianPath.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/EulerianPathTests.cs))
        - Fleury's algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/FleurysAlgorithm.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/FleurysAlgorithmеtTests.cs))
        - Kosaraju's Algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/KosarajusAlgorithm.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/KosarajusAlgorithmTests.cs))
        - Negative Cycle Detection using Bellman-Ford ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/NegativeCycleDetectionBellmanFordBased.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/NegativeCycleDetectionBellmanFordBasedTests.cs))
        - Tarjan's Algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/TarjansAlgorithm.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/TarjansAlgorithmTests.cs))
        - Biconnected Components using Tarjan's algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/TarjansAlgorithmForBiconnectedComponents.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/TarjansAlgorithmForBiconnectedComponentsTests.cs))
        - Topological Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/TopologicalSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/TopologicalSortTests.cs))
        - Transitive Closure using Floyd-Warshall algorithm ([code](../master/AlgorithmsAndDataStructures/Algorithms/Graph/Misc/TransitiveClosureFloydWarshall.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Graph/TransitiveClosureFloydWarshallTests.cs))
- Hashing:
    - Alder32 ([code](../master/AlgorithmsAndDataStructures/Algorithms/Hashing/Alder32.cs))
    - FowlerNollVo1aBasedHash ([code](../master/AlgorithmsAndDataStructures/Algorithms/Hashing/FowlerNollVo1aBasedHash.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Hashing/FowlerNollVo1aBasedHashTests.cs))
- Numbers:
    - Euclidian Common Denominator ([code](../master/AlgorithmsAndDataStructures/Algorithms/Numbers/EuclidianAlgorithmForCommonDenominator.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Numbers/EuclidianAlgorithmForCommonDenominatorTests.cs))
    - Sieve of Eratosthenes ([code](..//master/AlgorithmsAndDataStructures/Algorithms/Numbers/SieveOfEratosthenes.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Numbers/SieveOfEratosthenesTests.cs))
- Pseudorandom Number Generators:
    - Linear Congruential Random Number Generator ([code](../master/AlgorithmsAndDataStructures/Algorithms/PseudorandomNumberGenerators/LinearCongruentialRandomNumberGenerator.cs))
    - XOR Shift 1024 Star ([code](../master/AlgorithmsAndDataStructures/Algorithms/PseudorandomNumberGenerators/XORShift1024Star.cs))
    - XOR Shift 64 Star ([code](../master/AlgorithmsAndDataStructures/Algorithms/PseudorandomNumberGenerators/XORShift64Star.cs))
- Sampling:
    - Reservoir Sampling ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sampling/ReservoirSampling.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sampling/ReservoirSamplingTests.cs))
    - Selection Sampling ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sampling/SelectionSampling.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sampling/SelectionSamplingTests.cs))
- Search:
    - Binary Search Recursive ([code](../master/AlgorithmsAndDataStructures/Algorithms/Search/BinaryRecursive.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Search/BinaryRecursiveTests.cs))
    - Binary Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Search/BinarySearch.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Search/BinarySearchTests.cs))
    - Exponential Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Search/Exponential.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Search/ExponentialSearchTests.cs))
    - Fibonacci Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Search/Fibonacci.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Search/Fibonacci.cs))
    - Interpolation Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Search/Interpolation.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Search/InterpolationSortTests.cs))
    - Jump Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Search/Jump.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Search/JumpSearchTests.cs))
    - Linear Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Search/Linear.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Search/LinearSearchTests.cs))
    - Quick Select ([code](../master/AlgorithmsAndDataStructures/Algorithms/Search/QuickSelect.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Search/QuickSelectTests.cs))
    - Sublist ([code](../master/AlgorithmsAndDataStructures/Algorithms/Search/SublistSearch.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Search/SublistSearchTests.cs))
- Sorting:
    - Bubble Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/BubbleSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/BubbleSortTests.cs))
    - Comb Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/CombSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/CombSortTests.cs))
    - Count Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/CountSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/CountSortTests.cs))
    - Heap Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/HeapSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/HeapSortTests.cs))
    - Insertion Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/InsertionSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/InsertionSortTests.cs))
    - Merge Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/MergeSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/MergeSortTests.cs))
    - Partitioned Merge Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/PartitionedMergeSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/PartitionedMergeSortTests.cs))
    - Quick Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/QuickSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/QuickSortTests.cs))
    - Radix Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/RadixSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/RadixSortTests.cs))
    - Selection Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/SelectionSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/SelectionSortTests.cs))
    - Shell Sort ([code](../master/AlgorithmsAndDataStructures/Algorithms/Sorting/ShellSort.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Sorting/ShellSortTests.cs))
- Strings:
    - Levenstine Distance ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/LevenstineDistance/LevenstineDistanceDynamicProgramming.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/LevenstineDistance/LevenstineDistanceDynamicProgrammingTests.cs))
    - Booyer-Moore Combined Heuristic ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/Search/BooyerMooreCombinedHeuristic.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/Search/BooyerMooreCombinedHeuristicTests.cs))
    - Booyer-Moore Bad Character Heuristic ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/Search/BoyerMooreBadCharacterHeuristic.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/Search/BoyerMooreBadCharacterHeuristicTests.cs))
    - Booyer-Moore Good Suffix Heuristic ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/Search/BoyerMooreGoodSuffixHeuristic.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/Search/BoyerMooreGoodSuffixHeuristicTests.cs))
    - Knuth-Morris-Pratt ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/Search/KnuthMorrisPratt.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/Search/KnuthMorrisPrattTests.cs))
    - Naive pattern Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/Search/NaivePatternSearch.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/Search/NaivePatternSearchTests.cs))
    - Recursive pattern Search ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/Search/RecursivePatternSearch.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/Search/RecursivePatternSearchTests.cs))
    - Rabin-Karp ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/Search/RabinKarp.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/Search/RabinKarpTests.cs))
    - Least Significant Digit sorting ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/Sorting/LSD.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/Sorting/LSDTests.cs))
    - Most Significant Digit sorting ([code](../master/AlgorithmsAndDataStructures/Algorithms/Strings/Sorting/MSD.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Strings/Sorting/MSDTests.cs))
- Bitwise stuff: ([code](../master/AlgorithmsAndDataStructures/Algorithms/Bitwise/), [tests](../master/AlgorithmsAndDataStructures.Tests/Algorithm/Bitwise)

# Misc concurrent problems

- Asynchronous to Synchronous ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/AsynchronousToSynchronous.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Concurrency/AsynchronousToSynchronousTests.cs))
- Dining Philosophers ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/DiningPhilosophers.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Concurrency/DiningPhilosophersTests.cs))
- Reader Writer Lock ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/ReaderWriterLock.cs))
- Simple Barrier ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/SimpleBarrier.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Concurrency/SimpleBarrierTests.cs))
- Simple Blocking Queue ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/SimpleBlockingQueue.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Concurrency/SimpleBlockingQueueTests.cs))
- Simple Non Blocking Queue ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/SimpleNonBlockingQueue.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Concurrency/SimpleNonBlockingQueueTests.cs))
- Sleeping Barber ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/SleepingBarber.cs))
- Uber Ride ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/UberRide.cs), [tests](../master/AlgorithmsAndDataStructures.Tests/DataStructures/Concurrency/UberRideProblemTests.cs))
- Unisex Bathroom ([code](../master/AlgorithmsAndDataStructures/DataStructures/Concurrency/UnisexBathroom.cs))
