namespace Algorithm.FindAlgorithms
{
    public static class AlgorithmsFactory
    {
        public static IBirthdayDiffComparer GetBiggestBirthdayDifference () => new BirthdayDiffMaxComparer();
        public static IBirthdayDiffComparer GetSmallestBirthdayDifference () => new BirthdayDiffMinComparer();

    }
}
