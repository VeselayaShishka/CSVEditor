namespace CSVEditor.Services;
using System.Text.RegularExpressions;

public class DataValidator
{ 
    public static bool bdValidation(string input, out string? error) {
        error = null;
        if(!Regex.IsMatch(input, @"^(0[1-9]|[12]\d|3[01])-(0[1-9]|1[0-2])-\d{4}$")) {
            error = $"Invalid Birthday: '{input}'. Use dd-MM-yyyy.";
            return false;
        }
        return true;
    }

    public static bool marriedValidation(string input, out string? error) {
        error = null;
        string val = input.Trim().ToLower();
        if (val != "true" && val != "false") {
            error = $"Invalid Married status: '{input}'. Use 'true' or 'false'.";
            return false;
        }
        return true;
    }

    public static bool salaryValidation(string input, out string? error) {
        error = null;
        if (!Regex.IsMatch(input.Trim(), @"^\d+([.,]\d+)?$")) {
            error = $"Invalid Salary: '{input}'. Numbers only.";
            return false;
        }
        return true;
    }
}