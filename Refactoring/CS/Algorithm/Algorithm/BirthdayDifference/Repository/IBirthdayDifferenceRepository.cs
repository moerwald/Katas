using System.Collections.Generic;

namespace Algorithm.BirthdayDifference.Repository
{
    public interface IBirthdayDifferenceRepository
    {
        IEnumerable<BirthdayDifference.Model.BirthdayDifference> GetAll();
    }
}