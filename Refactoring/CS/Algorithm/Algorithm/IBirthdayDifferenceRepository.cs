using System.Collections.Generic;

namespace Algorithm
{
    public interface IBirthdayDifferenceRepository
    {
        IEnumerable<BirthdayDifference> GetAll();
    }
}