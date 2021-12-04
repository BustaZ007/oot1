using System;
using System.Collections.Generic;
using OOT1.Enums;

namespace OOT1.Models
{
    public class Person
    {
        public Person(string name, DateTime birthdate, Genders gender, Person mother, Person father, Person partner)
        {
            Name = name;
            Birthdate = birthdate;
            Gender = gender;
            Mother = mother;
            Father = father;
            Partner = partner;
            _children = new List<Person>();
        }

        public string Name { get; }
        public DateTime Birthdate { get; }
        public Genders Gender { get; }

        private readonly List<Person> _children;

        public Person Mother { get; }

        public Person Father { get; }

        public Person Partner { get; set; }

        public void AddChild(Person child)
        {
            if (child?.Mother == this || child?.Father == this)
                _children.Add(child);
        }

        public IEnumerable<Person> GetChildren() => _children;
    }
}