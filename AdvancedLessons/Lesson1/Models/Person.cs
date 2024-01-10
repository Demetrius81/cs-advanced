namespace Lesson1;

internal class Person
{
    public string Name { get; init; }
    public string LastName { get; init; }
    public DateTime BirthDay { get; init; }
    public Gender Gender { get; init; }

    public Person(string name, string lastName, DateTime birthDay, Gender gender)
    {
        Name = name;
        LastName = lastName;
        BirthDay = birthDay;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"{Name} {LastName}, {Gender} - {BirthDay}";
    }
}
