namespace UnitExpressionsProposal;

public class Speed
{
	public Speed(double magnitude, SpeedUnit unit)
    {
        Magnitude = magnitude;
        Unit = unit;
    }

    public double Magnitude { get; }

    public SpeedUnit Unit { get; }

    public override string ToString()
    {
        return $"{Magnitude} {Unit}";
    }
}


public sealed class SpeedUnit
{
    public SpeedUnit(LengthUnit lengthUnit, TimeUnit timeUnit)
    {
        LengthUnit = lengthUnit;
        TimeUnit = timeUnit;
    }

    public LengthUnit LengthUnit { get; }

    public TimeUnit TimeUnit { get; }

    public Speed PostfixBind(double magnitude)
    {
        return new Speed(magnitude, this);
    }

    public override string ToString()
    {
        return $"{LengthUnit.Symbol}/{TimeUnit.Symbol}";
    }
}

public static class SpeedImperialExtension
{
    public static Speed ToImperial(this Speed speed, LengthUnit? desiredLengthUnit = null)
    {
        if (speed.Unit.LengthUnit.UnitSystem == UnitSystem.Imperial)
            return speed;

        var mpf = 20;

        return new Speed(mpf, new SpeedUnit(desiredLengthUnit ?? LengthUnit.ft, speed.Unit.TimeUnit));
    }
}