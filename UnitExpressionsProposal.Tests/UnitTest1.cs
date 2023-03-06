namespace UnitExpressionsProposal.Tests;

using static MassUnit;
using static LengthUnit;
using static TimeUnit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Mass m = 20 kg;

        Mass m = kg.PostfixBind(20);
    }

    [Fact]
    public void Test2()
    {
        // Mass mass = 2 kg;
        // Mass totalMass = mass + 3 kg;

        Mass mass = kg.PostfixBind(2);
        Mass totalMass = mass + kg.PostfixBind(3);
    }

    [Fact]
    public void Test3()
    {
        // Speed speed = 15 m/s;

        Speed speed = (m / TimeUnit.s).PostfixBind(15);
    }

    [Fact]
    public void Test4()
    {
        // Length length = 20 m;
        // Time time = 2 s;
        // Speed speed = length / time;

        Length length = (m).PostfixBind(20);
        Time time = (TimeUnit.s).PostfixBind(2);

        Speed speed = length / time;
    }


    [Fact]
    public void Test5()
    {
        // Speed speed = 15 m/s;

        Speed speed = (m / TimeUnit.s).PostfixBind(15);

        var s = speed.ToImperial();
    }
}
