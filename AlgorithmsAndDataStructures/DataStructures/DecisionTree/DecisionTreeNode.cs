using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.DecisionTree
{
    public class DecisionTreeNode
    {
        public KeyValuePair<string, string> TargetAttribute { get; set; }

        public string TestAttributeName { get; set; }

        public string BranchForValue { get; set; }

        public List<Dictionary<string, string>> Examples { get; } = new List<Dictionary<string, string>>();

        public List<DecisionTreeNode> Children { get; } = new List<DecisionTreeNode>();
    }
}
