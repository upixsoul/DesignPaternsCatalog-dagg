using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Iterator
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class People : IEnumerable
    {
        private readonly List<Person> _collection = new List<Person>();
        public void Add(Person person)
        {
            _collection.Add(person);
        }
        public IEnumerator GetEnumerator()
        {
            return new PersonIterator(_collection);
        }
    }
    public class PersonIterator: IEnumerator
    {
        private readonly List<Person> _collection;
        private int _position;
        public PersonIterator(List<Person> collection)
        {
            _collection = collection;
        }
        public bool MoveNext()
        {
            _position++;
            return (_position < _collection.Count);
        }
        public void Reset()
        {
            _position = 0;
        }
        public object? Current => _collection[_position -1];
    }
}
