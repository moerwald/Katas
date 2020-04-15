using System;
using System.Collections.Generic;
using System.Linq;
using Algorithm.BirthdayDifference.Model;

namespace Algorithm.BirthdayDifference.Repository
{
    public sealed class BirthdayDifferenceRepository : IBirthdayDifferenceRepository
    {
        private readonly IEnumerable<BirthdayDifference.Model.BirthdayDifference> _birthdayDifferences;
        private readonly Person.Person[] _persons;

        public BirthdayDifferenceRepository(IEnumerable<Person.Person> persons)
        {
            _persons = persons?.ToArray() ?? throw new ArgumentNullException(nameof(persons));
            _birthdayDifferences = CreateRepository();
        }

        private IEnumerable<BirthdayDifference.Model.BirthdayDifference> CreateRepository()
            => CreateCartisianProduct()
                .Distinct()
                .DefaultIfEmpty(NullBirthdayDifference.Instance);

        private IEnumerable<BirthdayDifference.Model.BirthdayDifference> CreateCartisianProduct()
            => _persons.SelectMany(CreateBirthdayDifferenceWithOtherPersons);

        private IEnumerable<BirthdayDifference.Model.BirthdayDifference> CreateBirthdayDifferenceWithOtherPersons(Person.Person person)
            => _persons.Where(PersonIsNotTheSame(person))
                       .Select(p => new BirthdayDifference.Model.BirthdayDifference(person, p));

        private static Func<Person.Person, bool> PersonIsNotTheSame(Person.Person person) => p => p != person;

        /// <summary>
        /// Returns a flat copy of the list object.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BirthdayDifference.Model.BirthdayDifference> GetAll() => _birthdayDifferences.ToList();
    }
}