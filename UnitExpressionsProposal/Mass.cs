namespace UnitExpressionsProposal;

public struct Mass
{
    public Mass(double magnitude, MassUnit unit)
    {
        Magnitude = magnitude;
        Unit = unit;
    }

    public double Magnitude { get; }

    public MassUnit Unit { get; }

    public override string ToString()
    {
        return $"{Magnitude} {Unit}";
    }

    public static Mass operator + (Mass lhs, Mass rhs)
    {
        return new Mass(lhs.Magnitude + rhs.Magnitude, rhs.Unit);
    }
}

public sealed class MassUnit
{
    /// <summary>
    /// Kilogram
    /// </summary>
    public static readonly MassUnit kg = new MassUnit("Kilogram", "kg", UnitSystem.SI);

    /// <summary>
    /// Pound (lb)
    /// </summary>
    public static readonly MassUnit lb = new MassUnit("Pound", "lb", UnitSystem.Imperial);

    private MassUnit(string name, string symbol, UnitSystem unitSystem)
    {
        Name = name;
        Symbol = symbol;
        UnitSystem = unitSystem;
    }

    public string Name { get; }

    public string Symbol { get; }

    public UnitSystem UnitSystem { get; }

    public Mass PostfixBind(double magnitude)
    {
        return new Mass(magnitude, this);
    }

    public override string ToString()
    {
        return Symbol;
    }
}