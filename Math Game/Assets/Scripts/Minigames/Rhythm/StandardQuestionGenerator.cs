using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Discovery.Minigames.Rhythm
{
    public class StandardQuestionGenerator : IQuestionGenerator
    {
        private readonly int _numberOne;
        private readonly int _numberTwo;
        private readonly string _currentOperation;
        private readonly List<string> _operations = new List<string>();
        private readonly Dictionary<string, Func<int, int, int>> _functions = new Dictionary<string, Func<int, int, int>>();

        public int Answer { get; }
        public string CurrentOperation => _currentOperation;

        public StandardQuestionGenerator(int numberOne, int numberTwo)
        {
            _numberOne = numberOne;
            _numberTwo = numberTwo;

            InitializeOperators();
            InitializeFunctions();

            _currentOperation = _operations[Random.Range(0, _operations.Count - 1)];

            Answer = _functions[_currentOperation](_numberOne, _numberTwo);
        }

        public StandardQuestionGenerator()
        {
            _numberOne = Random.Range(1, 10);
            _numberTwo = Random.Range(1, 10);

            InitializeOperators();
            InitializeFunctions();

            _currentOperation = _operations[Random.Range(0, _operations.Count - 1)];

            Answer = _functions[_currentOperation](_numberOne, _numberTwo);
        }

        private void InitializeOperators()
        {
            _operations.Add("x");
            _operations.Add("+");
            _operations.Add("/");
        }

        private void InitializeFunctions()
        {
            _functions.Add("+", (i, j) => i + j);
            _functions.Add("-", (i, j) => i - j);
            _functions.Add("x", (i, j) => i * j);
        }

        public string GetQuestion()
        {
            return $"{_numberOne} {_currentOperation} {_numberTwo}";
        }


    }
}