using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.DecisionTree
{
    public class Id3
    {
        public DecisionTreeNode CreateDecisionTree(
            Dictionary<string, string>[] examples,
            string targetAttributeName,
            Dictionary<string, List<string>> attributes)
        {
            var dt = new DecisionTreeNode();

            if (examples is null)
            {
                return dt;
            }

            if (attributes is null)
            {
                throw new ArgumentNullException(nameof(attributes));
            }

            dt.Examples.AddRange(examples);
            
            if (CheckAllExamplesHaveTheSameAttributeValue(examples, targetAttributeName))
            {
                var example = examples.First();
                var attributeValue = example[targetAttributeName];
                dt.TargetAttribute = new KeyValuePair<string, string>(targetAttributeName, attributeValue);

                return dt;
            }

            if (attributes.Count == 0)
            {
                var attributeValue = FindMostCommonAttributeValue(examples, targetAttributeName);
                dt.TargetAttribute = new KeyValuePair<string, string>(targetAttributeName, attributeValue);
                return dt;
            }

            var attributeName = GetBestClassifier(examples, targetAttributeName, attributes);
            dt.TestAttributeName = attributeName;

            foreach (var attributeValue in attributes[attributeName])
            {
                var filteredExamples = FilterExamples(examples, attributeName, attributeValue);

                if (filteredExamples.Length == 0)
                {
                    var mostCommonAttributeValue = FindMostCommonAttributeValue(examples, targetAttributeName);
                    var branch = new DecisionTreeNode();
                    branch.TargetAttribute = new KeyValuePair<string, string>(targetAttributeName, mostCommonAttributeValue);
                    branch.BranchForValue = attributeValue;
                    dt.Children.Add(branch);
                }
                else
                {
                    attributes.Remove(attributeName);
                    var branch = CreateDecisionTree(filteredExamples, targetAttributeName, attributes);
                    branch.BranchForValue = attributeValue;
                    dt.Children.Add(branch);
                }
            }

            return dt;
        }

        private static bool CheckAllExamplesHaveTheSameAttributeValue(Dictionary<string, string>[] examples, string targetAttribute)
        {
            if (examples.Length == 0)
            {
                return true;
            }

            var attributeValue = examples.First()[targetAttribute];

#pragma warning disable HAA0401 // Possible allocation of reference type enumerator
            foreach (var example in examples.Skip(1))
#pragma warning restore HAA0401 // Possible allocation of reference type enumerator
            {
                if (example[targetAttribute] != attributeValue)
                {
                    return false;
                }
            }

            return true;
        }

        private static string FindMostCommonAttributeValue(Dictionary<string, string>[] examples, string targetAttribute)
        {
            var score = new Dictionary<string, int>();

            foreach (var example in examples)
            {
                var attributeValue = example[targetAttribute];

                if (!score.ContainsKey(attributeValue))
                {
                    score[attributeValue] = 0;
                }

                score[attributeValue]++;
            }

            return score
                .OrderByDescending(arg => arg.Value)
                .First()
                .Key;
        }

        private static Dictionary<string, string>[] FilterExamples(Dictionary<string, string>[] examples, string targetAttribute, string targetAttributeValue)
        {
            var filtered = new List<Dictionary<string, string>>();

            foreach (var example in examples)
            {
                if (example[targetAttribute] == targetAttributeValue)
                {
                    filtered.Add(example);
                }
            }

            return filtered.ToArray();
        }

        private static float CalculateEntrophy(Dictionary<string, string>[] examples, string targetAttribute)
        {
            var scores = new Dictionary<string, int>();

            foreach (var example in examples)
            {
                var attributeValue = example[targetAttribute];

                if (!scores.ContainsKey(attributeValue))
                {
                    scores[attributeValue] = 0;
                }

                scores[attributeValue] = scores[attributeValue] + 1;
            }

            float entropy = 0;

            foreach (var score in scores)
            {
                var p = (float)score.Value / examples.Length;

                entropy = entropy - p * (float)Math.Log(p, 2);
            }

            return entropy;
        }

        private static float CalculateInformationGane(Dictionary<string, string>[] examples, string testAttribute, string targetAttribute)
        {
            var groups = new Dictionary<string, List<Dictionary<string, string>>>();

            foreach (var example in examples)
            {
                var attributeValue = example[testAttribute];

                if (!groups.ContainsKey(attributeValue))
                {
                    groups[attributeValue] = new List<Dictionary<string, string>>();
                }
                groups[attributeValue].Add(example);
            }

            var informationGain = CalculateEntrophy(examples, targetAttribute);

            foreach (var group in groups)
            {
                var p = (float)group.Value.Count / examples.Length;
                var entropy = CalculateEntrophy(group.Value.ToArray(), targetAttribute);

                informationGain -= p * entropy;
            }

            return informationGain;
        }

        private static string GetBestClassifier(
            Dictionary<string, string>[] examples,
            string targetAttributeName,
            Dictionary<string, List<string>> attributes)
        {
            double maxInformationGain = 0;
            string result = null;

            foreach (var attribute in attributes)
            {
                var informationGain = CalculateInformationGane(examples, attribute.Key, targetAttributeName);

                if (informationGain >= maxInformationGain)
                {
                    maxInformationGain = informationGain;
                    result = attribute.Key;
                }
            }

            return result;
        }
    }
}
