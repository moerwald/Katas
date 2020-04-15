namespace Algorithm.FindAlgorithms
{
    public sealed class BirthdayDiffMaxComparer : IBirthdayDiffComparer
    {
        public BirthdayDifference.Model.BirthdayDifference Compare(BirthdayDifference.Model.BirthdayDifference val1, BirthdayDifference.Model.BirthdayDifference val2)
            => val1.Difference > val2.Difference ? val1 : val2;
    }
}