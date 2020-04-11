namespace Algorithm.FindAlgorithms
{
    public sealed class BirthdayDiffMinComparer : IBirthdayDiffComparer
    {
        public BirthdayDifference Compare(BirthdayDifference val1, BirthdayDifference val2)
            => val1.Difference < val2.Difference ? val1 : val2;
    }
}