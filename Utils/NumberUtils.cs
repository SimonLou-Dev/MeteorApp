namespace MeteorApp.Utils;

public class NumberUtils
{

    public static string doubleToString(double value)
    {
        return value.ToString("0.00").Replace(",", ".");
    }


}