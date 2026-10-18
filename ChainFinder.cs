namespace NumberChainSimple
{
    public static class ChainFinder
    {
        public static List<SplitNumber> FindLongestChain(List<SplitNumber> numbers)
        {
            var best = new List<SplitNumber>();
            var current = new List<SplitNumber>();
            var used = new bool[numbers.Count];

            for (int i = 0; i < numbers.Count; i++)
            {
                used[i] = true;
                current.Add(numbers[i]);

                Continue(numbers, used, current, ref best);

                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }

            return best;
        }

        private static void Continue(List<SplitNumber> numbers, bool[] used, List<SplitNumber> current, ref List<SplitNumber> best)
        {
            if (current.Count > best.Count)
            {
                best = [.. current];
            }

            SplitNumber last = current[^1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!used[i] && last.Last == numbers[i].First)
                {
                    used[i] = true;
                    current.Add(numbers[i]);

                    Continue(numbers, used, current, ref best);

                    current.RemoveAt(current.Count - 1);
                    used[i] = false;
                }
            }
        }

        public static string Glue(List<SplitNumber> chain)
        {
            if (chain.Count == 0)
            {
                return "";
            }

            string result = chain[0].Original;
            for (int i = 1; i < chain.Count; i++)
            {
                result += chain[i].Middle + chain[i].Last;
            }

            return result;
        }
    }
}