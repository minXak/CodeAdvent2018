using System;
using System.Collections.Generic;

namespace Advent2018._1
{
    public class Day1Part2
    {
        private const int MaxDepth = 10000;
        private readonly HashSet<int> _foundFrequencies;
        private List<int> _data;

        public Day1Part2()
        {
            _foundFrequencies = new HashSet<int> { 0 };
            _data = new List<int>();
        }

        public int FindFrequencyReachedTwice(string filename)
        {
            GetData(filename);

            var initialFrequency = 0;
            var initialDepth = 0;

            var iterationResult = MainLoop(initialFrequency, initialDepth);

            if (iterationResult.IsMatch)
            {
                return iterationResult.Value;
            }

            throw new Exception($"Max depth of {MaxDepth} has been reached");
        }

        private void GetData(string filename)
        {
            var fileReader = new FileReader();
            _data = fileReader.GetData(filename);
        }

        private IterationResult MainLoop(int frequency, int depth)
        {
            var iterationResult = FindFrequencyIteration(frequency);

            while (!iterationResult.IsMatch && depth < MaxDepth)
            {
                iterationResult = FindFrequencyIteration(iterationResult.Value);
                depth++;
            }

            return iterationResult;
        }

        private IterationResult FindFrequencyIteration(int frequency)
        {
            foreach (var value in _data)
            {
                frequency += value;
                if (_foundFrequencies.Contains(frequency))
                {
                    return new IterationResult { IsMatch = true, Value = frequency };
                }

                _foundFrequencies.Add(frequency);
            }

            return new IterationResult { IsMatch = false, Value = frequency};
        }

        public struct IterationResult
        {
            public bool IsMatch;
            public int Value;
        }
    }
}