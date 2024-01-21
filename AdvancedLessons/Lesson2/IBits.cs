namespace Lesson2;
internal interface IBits
{
    long Value { get; set; }

    public void SetBit(bool value, int index);

    public bool GetBit(int index);

}
