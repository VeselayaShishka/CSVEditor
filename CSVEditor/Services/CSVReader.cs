namespace CSVEditor.Services;
using Models;

public static class CSVReader
{
    public static List<UserRecord> ReadCSV(Stream stream, out List<string> errors)
    {
        List<UserRecord> list = new List<UserRecord>();
        errors = new List<string>();
        using StreamReader reader = new StreamReader(stream);
        int lineNum = 0;

        while (!reader.EndOfStream)
        {
            lineNum++;
            string? line = reader.ReadLine();
            if(string.IsNullOrWhiteSpace(line)) continue;
        
            string[] p = line.Split(',');
            if (p.Length < 5) {
                errors.Add($"Line {lineNum}: Invalid column count.");
                continue;
            }

            List<string> rowErrors = new List<string>();
            
            if (!DataValidator.bdValidation(p[1], out var errDate)) rowErrors.Add(errDate!);
            if (!DataValidator.marriedValidation(p[2], out var errMar)) rowErrors.Add(errMar!);
            if (!DataValidator.salaryValidation(p[4], out var errSal)) rowErrors.Add(errSal!);

            if (rowErrors.Count > 0)
            {
                errors.Add($"Line {lineNum} errors: " + string.Join(" | ", rowErrors));
            }
            else
            {
                list.Add(new UserRecord {
                    FullName = p[0].Trim(),
                    Birthday = DateOnly.ParseExact(p[1], "dd-MM-yyyy"),
                    Married = bool.Parse(p[2].ToLower()),
                    Phone = p[3].Trim(),
                    Salary = decimal.Parse(p[4].Replace(',', '.'))
                });
            }
        }
        return list;
    }
}