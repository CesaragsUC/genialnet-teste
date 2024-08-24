using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public class Validations
{
    public static void ValidateIfEqual(object object1, object object2, string message)
    {
        if (object1.Equals(object2))
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfDifferent(object object1, object object2, string message)
    {
        if (!object1.Equals(object2))
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfDifferent(string pattern, string value, string message)
    {
        var regex = new Regex(pattern);

        if (!regex.IsMatch(value))
        {
            throw new Exception(message);
        }
    }

    public static void ValidateLength(string value, int max, string message)
    {
        var length = value.Trim().Length;
        if (length > max)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateLength(string value, int min, int max, string message)
    {
        var length = value.Trim().Length;
        if (length < min || length > max)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfEmpty(string value, string message)
    {
        if (value == null || value.Trim().Length == 0)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfNull(object object1, string message)
    {
        if (object1 == null)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateMinMax(double value, double min, double max, string message)
    {
        if (value < min || value > max)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateMinMax(float value, float min, float max, string message)
    {
        if (value < min || value > max)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateMinMax(int value, int min, int max, string message)
    {
        if (value < min || value > max)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateMinMax(long value, long min, long max, string message)
    {
        if (value < min || value > max)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateMinMax(decimal value, decimal min, decimal max, string message)
    {
        if (value < min || value > max)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfLessThan(long value, long min, string message)
    {
        if (value < min)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfLessThan(double value, double min, string message)
    {
        if (value < min)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfLessThan(decimal value, decimal min, string message)
    {
        if (value < min)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfLessThan(int value, int min, string message)
    {
        if (value < min)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfFalse(bool boolValue, string message)
    {
        if (!boolValue)
        {
            throw new Exception(message);
        }
    }

    public static void ValidateIfTrue(bool boolValue, string message)
    {
        if (boolValue)
        {
            throw new Exception(message);
        }
    }
}
