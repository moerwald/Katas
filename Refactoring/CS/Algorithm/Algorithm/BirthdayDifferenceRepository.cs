using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public sealed class BirthdayDifferenceRepository : IBirthdayDifferenceRepository
    {
        private readonly IEnumerable<BirthdayDifference> _birthdayDifferences;
        private readonly Person[] _persons;

        public BirthdayDifferenceRepository(IEnumerable<Person> persons)
        {
            _persons = persons?.ToArray() ?? throw new ArgumentNullException(nameof(persons));
            _birthdayDifferences = CreateRepository();
        }

        private IEnumerable<BirthdayDifference> CreateRepository()
        {
#if false
            return _persons.SelectMany(p1 => _persons.Select(p2 => new BirthdayDifference(p1, p2)))
                           .Distinct()
                           .DefaultIfEmpty(NullBirthdayDifference.Instance);
#else

            var length = _persons.Length;
            var diffs = new List<BirthdayDifference>();
            for (var i = 0; i < length - 1; i++)
            {
                for (var j = i + 1; j < length; j++)
                {
                    diffs.Add(new BirthdayDifference(_persons[i], _persons[j]));
                }
            }

            return diffs.DefaultIfEmpty(NullBirthdayDifference.Instance);
#endif
        }

        /// <summary>
        /// Returns a flat copy of the list object.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BirthdayDifference> GetRepository() => _birthdayDifferences.ToList();
    }
}