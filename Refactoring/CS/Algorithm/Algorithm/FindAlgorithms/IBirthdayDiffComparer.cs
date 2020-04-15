namespace Algorithm.FindAlgorithms
{
    public interface IBirthdayDiffComparer
    {
        BirthdayDifference.Model.BirthdayDifference Compare(BirthdayDifference.Model.BirthdayDifference val1, BirthdayDifference.Model.BirthdayDifference val2);
    }
}