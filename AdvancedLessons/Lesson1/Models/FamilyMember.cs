using Lesson3.Models;
using System;

namespace Lesson3;

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
                throw new ArgumentException("Однополые браки не разрешены законодательством и осуждаются обществом.");
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

        Console.WriteLine("Brothers:");

        if (Childs is not null && Childs.Count > 1)
        {
            foreach (FamilyMember child in Childs)
            {
                if (child.Gender == Gender.Male)
                {
                    Console.WriteLine(child.ToString());
                }
            }

            Console.WriteLine("Sisters:");

            foreach (FamilyMember child in Childs)
            {
                if (child.Gender == Gender.Female)
                {
                    Console.WriteLine(child.ToString());
                }
            }
        }
        else
        {
            Console.WriteLine("None");
        }

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

    public static void PrintTree(FamilyMember person)
    {
        Console.WriteLine($"{person.LastName}`s family tree:");
        PrintPerson(person);
    }

    private static void PrintPerson(FamilyMember person)
    {
        string wife = person.Spouse is null ? "" : $" and wife {person.Spouse}";

        Console.WriteLine($"{person}{wife}");

        if (person.Childs.Count > 0)
        {
            Console.Write("Kids: ");

            foreach (var child in person.Childs)
            {
                Console.Write($"{child} ");
            }

        }


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

}
