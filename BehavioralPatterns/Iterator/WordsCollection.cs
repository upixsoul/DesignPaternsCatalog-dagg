using System.Collections;

namespace BehavioralPatterns.Iterator
{
    public class CustomCollection
    {
        public string[] Words { get; }

        public CustomCollection(string[] words)
        {
            Words = words;
        }
    }

    public class WordsCollection : IEnumerable
    {
        private readonly string[] _words;

        public WordsCollection(string[] words)
        {
            _words = words;
        }

        public IEnumerator GetEnumerator()
        {
            return new WordsEnumerator(_words);
        }
    }

    public class WordsEnumerator : IEnumerator
    {
        private readonly string[] _words;
        private int _position = -1;

        public WordsEnumerator(string[] words)
        {
            _words = words;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _words[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException("Collection end reached");
                }
            }
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _words.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
