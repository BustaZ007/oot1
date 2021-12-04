// See https://aka.ms/new-console-template for more information

using System;
using OOT1.Enums;
using OOT1.Services;

var grandMotherM = FamilyServices.CreatePerson("Бабушка м", DateTime.Now, Genders.Female);
var grandFatherM = FamilyServices.CreatePerson("Дедушка м", DateTime.Now, Genders.Male, partner:grandMotherM);
var grandMotherF = FamilyServices.CreatePerson("Бабушка п", DateTime.Now, Genders.Female);
var grandFatherF = FamilyServices.CreatePerson("Дедушка п", DateTime.Now, Genders.Male, partner:grandMotherF);
var mother = FamilyServices.CreatePerson("Мама", DateTime.Now, Genders.Female,
    grandMotherM, grandMotherM);
var father = FamilyServices.CreatePerson("Папа", DateTime.Now, Genders.Male,
    grandMotherF, grandFatherF, mother);
var uncleF = FamilyServices.CreatePerson("Дядя п", DateTime.Now, Genders.Male,
    grandMotherF, grandFatherF);
var auntF = FamilyServices.CreatePerson("Тетя П", DateTime.Now, Genders.Female,
    grandMotherF, grandFatherF);
var auntM = FamilyServices.CreatePerson("Тетя M", DateTime.Now, Genders.Female,
    grandMotherM, grandFatherM);

//Create cousins
FamilyServices.CreatePerson("кузин 1", DateTime.Now, Genders.Male,
    auntM);
FamilyServices.CreatePerson("кузина 2", DateTime.Now, Genders.Female,
    auntF);
FamilyServices.CreatePerson("кузин 3 ", DateTime.Now, Genders.Male, father:uncleF);
            
            
var person = FamilyServices.CreatePerson("Тот самый", DateTime.Now, Genders.Male, mother, father);

Console.WriteLine("Parents: ");
FamilyServices.GetParentsList(person)
    .ForEach(p => Console.WriteLine(p.Name));

Console.WriteLine("Uncles and Aunts: ");
FamilyServices.GetUnclesAndAuntsList(person)
    .ForEach(p => Console.WriteLine(p.Name));

Console.WriteLine("Cousins: ");
FamilyServices.GetCousinsList(person)
    .ForEach(p => Console.WriteLine(p.Name));

Console.WriteLine("Parent-in-law and mother-in-law: ");
FamilyServices.GetInLawsList(person)
    .ForEach(p => Console.WriteLine(p.Gender + p.Name));
