namespace Lesson6;

[AttributeUsage(AttributeTargets.Property)]
class CustomNameAttribute : Attribute
{
    public string Name { get; }
    public CustomNameAttribute(string name) => Name = name;
}
