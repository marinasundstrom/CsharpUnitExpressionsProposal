namespace UnitExpressionsProposal;

public struct Length
{
    public Length(double magnitude, LengthUnit unit)
    {
        Magnitude = magnitude;
        Unit = unit;
    }

    public double Magnitude { get; }

    public LengthUnit Unit { get; }

    public override string ToString()
    {
        return $"{Magnitude} {Unit}";
    }

    public static Speed operator / (Length length, Time time)
    {
        return new Speed(length.Magnitude / time.Magnitude, length.Unit / time.Unit);
    }
}

public sealed class LengthUnit
{
    /// <summary>
    /// Metre
    /// </summary>
    public static readonly LengthUnit m = new LengthUnit("metre", "m", UnitSystem.SI);

    /// <summary>
    /// Foot
    /// </summary>
    public static readonly LengthUnit ft = new LengthUnit("foot", "ft", UnitSystem.Imperial);

    private LengthUnit(string name, string symbol, UnitSystem unitSystem)
    {
        Name = name;
        Symbol = symbol;
        UnitSystem = unitSystem;
    }

    public string Name { get; }

    public string Symbol { get; }

    public UnitSystem UnitSystem { get; }

    public Length PostfixBind(double magnitude)
    {
        return new Length(magnitude, this);
    }

    public override string ToString()
    {
        return Symbol;
    }

    public static SpeedUnit operator / (LengthUnit lengthUnit, TimeUnit timeUnit)
    {
        return new SpeedUnit(lengthUnit, timeUnit);
    }
}