using Lesson1.Models;
using System;
using System.Linq;

namespace Lesson1;

internal class FamilyMember : Person, IMarried
{
    private FamilyMember spouse = null!;
    public FamilyMember Mother { get; set; } = null!;
    public FamilyMember Father { get; set; } = null!;
    public List<FamilyMember> Childs { get; set; }
    public FamilyMember Spouse
    {
        get => spouse;
        set
        {

            if (value.Gender == this.Gender)
            {
                throw new ArgumentException("Same-sex marriage is not permitted by law and is condemned by society.");
            }
            else
            {
                spouse = value;
            }
        }
    }

    public FamilyMember(string name, string lastName, DateTime birthDay, Gender gender) : base(name, lastName, birthDay, gender)
    {
        Childs = new List<FamilyMember>();
    }

    public void SetParents(FamilyMember father, FamilyMember mother)
    {
        this.Father = father;
        this.Mother = mother;
    }

    public void AddChild(FamilyMember child)
    {
        Childs.Add(child);
    }

    public void RemoveChild(FamilyMember child)
    {
        Childs.Remove(child);
    }

    public void PrintFamily()
    {
        Console.WriteLine(this.ToString());

        Console.WriteLine("Mother:");
        Console.WriteLine(Mother is null ? "None" : Mother.ToString());

        Console.WriteLine("Father:");
        Console.WriteLine(Father is null ? "None" : Father.ToString());

        PrintSibling(Childs);

        Console.WriteLine("Grandmothers and grandfathers:");

        if (Father is not null)
        {
            Console.WriteLine(Father.Mother is not null ? Father.Mother.ToString() : "None");
            Console.WriteLine(Father.Father is not null ? Father.Father.ToString() : "None");
        }

        if (Mother is not null)
        {
            Console.WriteLine(Mother.Mother is not null ? Mother.Mother.ToString() : "None");
            Console.WriteLine(Mother.Father is not null ? Mother.Father.ToString() : "None");
        }
    }

    public override string ToString()
    {
        return $"{Name}";
    }

    /// <summary>Метод выводит на экран генеологическое древо</summary>
    public static void PrintTree(FamilyMember person)
    {
        Console.WriteLine($"{person.LastName}`s family tree:");
        PrintPerson(person);
    }

    private static void PrintPerson(FamilyMember person)
    {
        PrintSpouse(person);
        PrintChilds(person.Childs);
        Console.WriteLine();

        if (person.Childs.Count > 0)
        {
            foreach (FamilyMember child in person.Childs)
            {
                if (child.Gender == Gender.Male && child.Childs.Count > 0)
                {
                    PrintPerson(child);
                }
            }
        }
    }

    private static void PrintSibling(List<FamilyMember> persons, FamilyMember excludePerson = null!)
    {
        Console.WriteLine("Brothers:");

        if (persons is not null && persons.Count > 0)
        {
            foreach (FamilyMember child in persons)
            {
                if (child.Gender == Gender.Male && child != excludePerson)
                {
                    Console.WriteLine(child.ToString());
                }
            }

            Console.WriteLine("Sisters:");

            foreach (FamilyMember child in persons)
            {
                if (child.Gender == Gender.Female && child != excludePerson)
                {
                    Console.WriteLine(child.ToString());
                }
            }
        }
        else
        {
            Console.WriteLine("None");
        }

    }

    private static void PrintChilds(List<FamilyMember> childs)
    {
        if (childs.Count > 0)
        {
            Console.Write("Kids: ");

            foreach (var child in childs)
            {
                Console.Write($"{child} ");
            }

        }
    }

    private static void PrintSpouse(FamilyMember person)
    {
        string partner;

        if (person.Spouse is not null)
        {
            partner = person.Spouse.Gender == Gender.Male ? $" and husband {person.Spouse}" : $" and wife {person.Spouse}";

        }
        else
        {
            partner = "";
        }

        Console.WriteLine($"{person}{partner}");
    }

    // Доработайте приложение генеалогического дерева таким образом чтобы программа
    // выводила на экран близких родственников(жену/мужа) и братьев/сестёр определённого человека.
    // Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек.

    public static void PrintCloseRelatives(FamilyMember person)
    {
        Console.WriteLine($"{person}'s close relatives:");
        PrintSpouse(person);
        List<FamilyMember> sibling = [];

        if (person.Mother is not null)
        {
            sibling.AddRange(person.Mother.Childs);
        }

        if (person.Father is not null)
        {
            sibling = sibling.Union(person.Father.Childs).ToList();
        }

        if (sibling.Count > 0)
        {
            PrintSibling(sibling, person);
        }
        else
        {
            Console.WriteLine($"{person} do not has brothers and systers.");
        }
    }
}
