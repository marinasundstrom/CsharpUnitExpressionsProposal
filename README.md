# Unit expressions using PrefixBind and PostfixBind methods

This proposals is about implementing syntactic support for unit expressions - like SI and Imperial units of measurements.

The purpose is to give the infrastructure and syntax that allows for third-party libraries for scientific calculations to tap into.

Based on Manifold's [proposal for adding unit expressions](https://github.com/manifold-systems/manifold/tree/master/manifold-deps-parent/manifold-ext#unit-expressions) to Java.

Check [discussion](https://github.com/dotnet/csharplang/discussions/7031) in dotnet/csharp repository.

By structurally adding a ```PostfixBind``` method to the type of variable that acts as a prefix you could implement syntax for dealing with units.

The compiler would detect that there is a ```PostfixBind``` (or ```PrefixBind```) defined on the the unit.

Syntax proposal:

```csharp
using static MassUnit;

Mass m = 20 kg;
```

The lowered code:

```csharp
Mass m = MassUnit.kg.PostfixBind(20);
```

Whereas ```kg``` is a static readonly field in ```MassUnit```;

In essence, the unit acts as a decorator, in the form of a method taking the preceding value as an argument, and then wraps or transforms it into another form.

This is (roughly) how it would be implemented:

```csharp
public sealed class MassUnit
{
    public static readonly MassUnit kg = new MassUnit("kilograms", "kg");

    protected MassUnit(string name, string symbol) 
    {
        // Implementation omitted
    }

    public Mass PostfixBind(double magnitude)
    {
        // Create the Mass with the current unit that this type represents.

        return new Mass(magnitude, this);
    }
}

public struct Mass 
    : IComparable<Mass>, IConvertible, IEquatable<Mass>, IParsable<Mass>, System.Numerics.IAdditionOperators<Mass,Mass,Mass>
{
    public Mass(double magnitude, MassUnit unit) 
    {
        // Implementation omitted
    }

    public Mass ToPounds()  
    {
        if(Unit == MassUnit.lb) return Magnitude;

        var pounds = Magnitude * 2.20462262185

        return new Mass(pounds, MassUnit.lb);
    }
}
```

The ```Mass``` type would deal with conversion between values of different ```MassUnit```s. And other Units would do the same. 

In addition to ```PostfixBind``` methods, there would be support for ```PrefixBind``` which might be self-explanatory.

## More on expressions

Since units are part of expressions you can do arithmetic operations on units - thanks to the good old operator overloading.

```csharp
using static LengthUnit;
using static TimeUnit;

Speed s = 15 m/s;
```

The lowered code:

```csharp
Speed s = (LengthUnit.m / TimeUnit.s).PostfixBind(15);
```