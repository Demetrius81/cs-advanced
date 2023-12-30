using Lesson1;

namespace Lesson1;

internal class Program
{
    protected Program()
    {

    }

    static void Main(string[] args)
    {
        FamilyMember fother = new FamilyMember("John", "Silva", DateTime.Now, Gender.Male);
        FamilyMember mother = new FamilyMember("Jamm", "Silva", DateTime.Now, Gender.Female);
        fother.Spouse = mother;
        mother.Spouse = fother;
        FamilyMember children = new FamilyMember("Suzi", "Silva", DateTime.Now, Gender.Female);
        children.Father = fother;
        children.Mother = mother;
        fother.AddChild(children);
        mother.AddChild(children);
        children = new FamilyMember("Sam", "Silva", DateTime.Now, Gender.Male);
        children.Father = fother;
        children.Mother = mother;
        fother.AddChild(children);
        mother.AddChild(children);

        var fother2 = new FamilyMember("Ferdinand", "Silva", DateTime.Now, Gender.Male);
        var mother2 = new FamilyMember("Marry", "Silva", DateTime.Now, Gender.Female);
        mother2.Spouse = fother2;
        fother2.Spouse = mother2;
        fother.Father = fother2;
        fother.Mother = mother2;
        mother2.AddChild(fother);
        fother2.AddChild(fother);

        fother = children;
        mother = new FamilyMember("Roxana", "Silva", DateTime.Now, Gender.Female);
        fother.Spouse = mother;
        mother.Spouse = fother;

        children = new FamilyMember("Max", "Silva", DateTime.Now, Gender.Male);
        children.Father = fother;
        children.Mother = mother;
        fother.AddChild(children);
        mother.AddChild(children);
        children = new FamilyMember("Alexander", "Silva", DateTime.Now, Gender.Male);
        children.Father = fother;
        children.Mother = mother;
        fother.AddChild(children);
        mother.AddChild(children);

        FamilyMember.PrintTree(fother2);

        Console.ReadKey(true);

    }
}
