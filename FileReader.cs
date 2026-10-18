namespace NumberChainSimple
{
    public static class FileReader
    {
        public static List<string> ReadNumbers(string path)
        {
            string text = File.ReadAllText(path);
            string[] parts = text.Split([' ', '\t', '\r', '\n', ',', ';'], StringSplitOptions.RemoveEmptyEntries);

            var numbers = new List<string>();
            foreach (string part in parts)
            {
                if (part.Length >= 4 && part.All(char.IsAsciiDigit))
                {
                    numbers.Add(part);
                }
            }

            return numbers;
        }
    }
}