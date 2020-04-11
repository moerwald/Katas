namespace Algorithm.FindAlgorithms
{
    public static class AlgorithmsFactory
    {
        public static IBirthdayDiffComparer GetMaxComparer () => new BirthdayDiffMaxComparer();
        public static IBirthdayDiffComparer GetMinComparer () => new BirthdayDiffMinComparer();

    }
}
