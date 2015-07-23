using System;

public class UUnitAssert
{
    public static double DEFAULT_DOUBLE_PRECISION = 0.000001;

    private UUnitAssert()
    {
    }

    public static void Fail()
    {
        throw new UUnitAssertException("fail");
    }

    public static void True(bool boolean, string message)
    {
        if (boolean)
        {
            return;
        }
        throw new UUnitAssertException(true, false, message);
    }

    public static void True(bool boolean)
    {
        if (boolean)
        {
            return;
        }
        throw new UUnitAssertException(true, false);
    }

    public static void False(bool boolean, string message)
    {
        if (!boolean)
        {
            return;
        }
        throw new UUnitAssertException(false, true, message);
    }

    public static void False(bool boolean)
    {
        if (!boolean)
        {
            return;
        }
        throw new UUnitAssertException(false, true);
    }

    public static void NotNull(object something)
    {
        if (something != null)
        {
            return;
        }
        throw new UUnitAssertException("Null object");
    }

    public static void Null(object something)
    {
        if (something == null)
        {
            return;
        }
        throw new UUnitAssertException("Not null object");
    }

    public static void Equals(string wanted, string got, string message)
    {
        if (wanted == got)
        {
            return;
        }
        throw new UUnitAssertException(wanted, got, message);
    }

    public static void Equals(string wanted, string got)
    {
        if (wanted == got)
            return;
        throw new UUnitAssertException(wanted, got);
    }

    public static void Equals(int wanted, int got, string message)
    {
        if (wanted == got)
        {
            return;
        }
        throw new UUnitAssertException(wanted, got, message);
    }

    public static void Equals(int wanted, int got)
    {
        if (wanted == got)
        {
            return;
        }
        throw new UUnitAssertException(wanted, got);
    }

    public static void Equals(double wanted, double got, double precision)
    {
        if (Math.Abs(wanted - got) < precision)
        {
            return;
        }
        throw new UUnitAssertException(wanted, got);
    }

    public static void Equals(double wanted, double got)
    {
        Equals(wanted, got, DEFAULT_DOUBLE_PRECISION);
    }

    public static void Equals(char wanted, char got)
    {
        if (wanted == got)
        {
            return;
        }
        throw new UUnitAssertException(wanted, got);
    }

    public static void Equals(object wanted, object got, string message)
    {
        if (wanted == got)
        {
            return;
        }
        throw new UUnitAssertException(wanted, got, message);
    }

    public new static void Equals(object wanted, object got)
    {
        if (wanted == got)
        {
            return;
        }
        throw new UUnitAssertException(wanted, got);
    }

}
