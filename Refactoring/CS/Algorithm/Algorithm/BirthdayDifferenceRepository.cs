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
            => _persons.SelectMany( CreateBirthdayDifferenceWithOtherPersons )
                           .Distinct( )
                           .DefaultIfEmpty(NullBirthdayDifference.Instance);

        private IEnumerable<BirthdayDifference> CreateBirthdayDifferenceWithOtherPersons(Person person)
            => _persons.Where(PersonIsNotTheSame(person))
                       .Select(p => new BirthdayDifference(person, p));

        private static Func<Person, bool> PersonIsNotTheSame(Person person) => p => p != person;


        /// <summary>
        /// Returns a flat copy of the list object.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BirthdayDifference> GetAll() => _birthdayDifferences.ToList();
    }
}