using NumberChainSimple;

string path;
if (args.Length > 0)
{
    path = args[0];
}
else
{
    Console.Write("Path to the numbers file: ");
    path = Console.ReadLine() ?? "";
}
path = path.Trim().Trim('"');

if (!File.Exists(path))
{
    Console.WriteLine("File not found: " + path);
    return;
}

List<string> numbers = FileReader.ReadNumbers(path);
Console.WriteLine("Loaded " + numbers.Count + " numbers.");

var splitNumbers = new List<SplitNumber>();
foreach (string number in numbers)
{
    splitNumbers.Add(NumberSplitter.Split(number));
}

Console.WriteLine("Searching for the longest chain, this can take a few minutes...");
List<SplitNumber> chain = ChainFinder.FindLongestChain(splitNumbers);

Console.WriteLine("Longest chain: " + chain.Count + " numbers");
foreach (SplitNumber number in chain)
{
    Console.WriteLine("  " + number.Original);
}

Console.WriteLine("Glued number: " + ChainFinder.Glue(chain));
