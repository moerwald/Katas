namespace Algorithm.BirthdayDifference.Model
{
    public sealed class NullBirthdayDifference : BirthdayDifference
    {
        private static NullBirthdayDifference _nullBirthdayDifference;

        public static BirthdayDifference Instance 
            => _nullBirthdayDifference ?? (_nullBirthdayDifference = new NullBirthdayDifference());

        private NullBirthdayDifference() { }

    }
}