using System.Xml;

try
{
    if (!args.Any())
    {
        Console.WriteLine("No file specified");
        return;
    }

    XmlDocument doc = new XmlDocument();
    doc.Load(args[0]);

    var coverage = doc.SelectSingleNode("/coverage/@line-rate")!.Value;
    if (decimal.TryParse(coverage, out var dCoverage))
    {
        var format = args.Length > 1 ? args[1] : "total_coverage={0}";
        Console.WriteLine(string.Format(format, dCoverage * 100));
    }
    else
    {
        Console.WriteLine("Value could not be extracted");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}