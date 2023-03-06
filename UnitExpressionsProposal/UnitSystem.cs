namespace UnitExpressionsProposal;

public sealed class UnitSystem
{
    public static readonly UnitSystem SI = new UnitSystem("International System of Units", "SI");

    public static readonly UnitSystem Imperial = new UnitSystem("Imperial", "Imperial");

    private UnitSystem(string name, string shortName)
    {
        Name = name;
        ShortName = shortName;
    }

    public string Name { get; }

    public string ShortName { get; }

    public override string ToString()
    {
        return ShortName;
    }
}