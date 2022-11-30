public class Cat : Animal
{
    public string FurType;
    public Cat(string furType, string diet) : base("Cat",diet,true)
    {
        FurType = furType;
    }

// method override
// before the return type include "override"
// to inherit from the parent use base.FuncName(); then include new info.
    public override void ShowInfo()
    {   
        base.ShowInfo();
        Console.WriteLine($"Fur Type: {FurType}");
    }
}