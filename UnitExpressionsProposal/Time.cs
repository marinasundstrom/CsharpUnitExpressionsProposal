namespace UnitExpressionsProposal;

public struct Time
{
    public Time(double magnitude, TimeUnit unit)
    {
        Magnitude = magnitude;
        Unit = unit;
    }

    public double Magnitude { get; }

    public TimeUnit Unit { get; }

    public override string ToString()
    {
        return $"{Magnitude} {Unit}";
    }
}

public sealed class TimeUnit
{
    /// <summary>
    /// Second
    /// </summary>
    public static readonly TimeUnit s = new TimeUnit("Second", "s", UnitSystem.SI);

    private TimeUnit(string name, string symbol, UnitSystem unitSystem)
    {
        Name = name;
        Symbol = symbol;
        UnitSystem = unitSystem;
    }

    public string Name { get; }

    public string Symbol { get; }

    public UnitSystem UnitSystem { get; }

    public Time PostfixBind(double magnitude)
    {
        return new Time(magnitude, this);
    }

    public override string ToString()
    {
        return Symbol;
    }
}