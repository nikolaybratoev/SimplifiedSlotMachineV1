namespace SimplifiedSlotMachineV1.Domain.Helpers;

public static class Formatter
{
    public static string Format(decimal item)
    {
        return item.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
    }
}