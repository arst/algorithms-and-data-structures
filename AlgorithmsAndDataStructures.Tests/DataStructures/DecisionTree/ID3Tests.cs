using AlgorithmsAndDataStructures.DataStructures.DecisionTree;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.DecisionTree
{
    public class ID3Tests
    {
        [Fact]
        public void Base()
        {
            var sut = new ID3();

            var example1 = new Dictionary<string, string>()
            {
                { "outlook", "sunny" },
                { "humidity", "high" },
                { "windy", "false" },
                { "class", "N" }
            };
            var example2 = new Dictionary<string, string>()
            {
                { "outlook", "overcast" },
                { "humidity", "high" },
                { "windy", "false" },
                { "class", "P" }
            };
            var example3 = new Dictionary<string, string>()
            {
                { "outlook", "rain" },
                { "humidity", "high" },
                { "windy", "false" },
                { "class", "P" }
            };
            var example4 = new Dictionary<string, string>()
            {
                { "outlook", "sunny" },
                { "humidity", "normal" },
                { "windy", "false" },
                { "class", "P" }
            };
            var example5 = new Dictionary<string, string>()
            {
                { "outlook", "rain" },
                { "humidity", "high" },
                { "windy", "true" },
                { "class", "N" }
            };
            var example6 = new Dictionary<string, string>()
            {
                { "outlook", "rain" },
                { "humidity", "normal" },
                { "windy", "true" },
                { "class", "N" }
            };
            var examples = new Dictionary<string, string>[] { example1, example2, example3, example4, example5, example6 };
            var attributes = new Dictionary<string, List<string>>();
            attributes.Add("outlook", new List<string>() { "sunny", "rain", "overcast" });
            attributes.Add("humidity", new List<string>() { "high", "normal" });
            attributes.Add("windy", new List<string>() { "true", "false" });

            var decisionTree = sut.CreateDecisionTree(examples, "class", attributes);


        }
    }
}
