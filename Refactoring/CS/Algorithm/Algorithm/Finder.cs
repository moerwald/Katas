using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly IEnumerable<Person> _persons;
        private readonly IBirthdayDifferenceRepository _repository;

        public Finder(IEnumerable<Person> persons, IBirthdayDifferenceRepository repository)
        {
            _persons = persons;
            _repository = repository;
        }

        public BirthdayDifference Find(eBirthDiff eBirthDiff)
            => _repository.GetRepository()
                              .ToList()
                              .Aggregate( (current, next) => 
                                  eBirthDiff == eBirthDiff.Minimum ? Min(next, current) : Max(next, current)); 

        private static BirthdayDifference Min(BirthdayDifference val1, BirthdayDifference val2)
            => val1.Difference < val2.Difference ? val1 : val2;

        private static BirthdayDifference Max(BirthdayDifference val1, BirthdayDifference val2)
            => val1.Difference > val2.Difference ? val1 : val2;
    }
}