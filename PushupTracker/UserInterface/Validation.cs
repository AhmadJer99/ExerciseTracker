using System.Globalization;

namespace ExerciseTracker.UserInterface;

public class Validation
{
    private  const string _correctDateTimeFormat = "MM-dd-yyyy HH:mm";
    internal static DateTime ValidateDateInput(string? dateInput)
    {
        DateTime tempObject;
        if (string.IsNullOrWhiteSpace(dateInput))
        {
            throw new ArgumentException("Date input cannot be null or empty.");
        }
        if (!DateTime.TryParseExact(dateInput, _correctDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempObject))
        {
            throw new ArgumentException($"Invalid date/time format. Please use: {_correctDateTimeFormat} (e.g., 04-10-2024 04:30)");
        }
        if (DateTime.TryParse(dateInput, out tempObject) && tempObject > DateTime.Now)
        {
            throw new ArgumentException("Date cannot be in the future.");
        }
        tempObject = DateTime.ParseExact(dateInput, _correctDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);
        return tempObject;
    }

    internal static int ValidateIntInput(string? v)
    {
        throw new NotImplementedException();
    }

    internal static string? ValidateStringInput(string? v)
    {
        throw new NotImplementedException();
    }
}
