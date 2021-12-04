using System;
using System.Collections.Generic;
using System.Linq;
using OOT1.Enums;
using OOT1.Models;

namespace OOT1.Services
{
    public class FamilyServices
    {
        public static Person CreatePerson(string name, DateTime birthdate, Genders gender, Person mother = null!,
            Person father = null!, Person partner = null!)
        {
            var person = new Person(name, birthdate, gender, mother, father, null!);
            mother?.AddChild(person);
            father?.AddChild(person);
            AddMarriage(person, partner);
            return person;
        }

        public static void AddMarriage(Person person, Person partner = null!)
        {
            if (partner is not null && person.Partner is null && partner.Partner is null)
            {
                partner.Partner = person;
                person.Partner = partner;
            }
        }
        
        public static List<Person> GetParentsList(Person person)
            => new List<Person>
            {
                person.Father, person.Mother
            };
        
        public static List<Person> GetUnclesAndAuntsList(Person person)
        {
            var parents = GetParentsList(person);
            
            return GetParentsList(person)
                .SelectMany(GetParentsList)
                .Where(p => p is not null)
                .SelectMany(p => p.GetChildren())
                .Where(p => !parents.Contains(p))
                .ToHashSet()
                .ToList();
        }

        public static List<Person> GetCousinsList(Person person) =>
            GetUnclesAndAuntsList(person)
                .SelectMany(p => p.GetChildren())
                .ToHashSet()
                .ToList();

        public static List<Person> GetInLawsList(Person person)
            => person.Partner is null 
                ? new List<Person>() 
                : GetParentsList(person.Partner);
    }
}