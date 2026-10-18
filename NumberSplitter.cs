// One number split into three parts, for example 123456 -> 12 | 34 | 56
namespace NumberChainSimple
{
    public record SplitNumber(string Original, string First, string Middle, string Last);

    public static class NumberSplitter
    {
        public static SplitNumber Split(string number)
        {
            string first = number[..2];
            string middle = number[2..^2];
            string last = number[^2..];

            return new SplitNumber(number, first, middle, last);
        }
    }
}