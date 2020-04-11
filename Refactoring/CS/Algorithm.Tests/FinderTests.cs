using System;
using System.Collections.Generic;
using Xunit;
using Algorithm.FindAlgorithms;

namespace Algorithm.Tests
{
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var finder = new Finder(
                new BirthdayDifferenceRepository(new List<Person>()),
                AlgorithmsFactory.GetMinComparer()
            );

            var result = finder.Find();

            Assert.Null(result.YoungerPerson);
            Assert.Null(result.OlderPerson);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var finder = new Finder(
                 new BirthdayDifferenceRepository( new List<Person>() { _sue } ),
                 AlgorithmsFactory.GetMinComparer());

            var result = finder.Find();

            Assert.Null(result.YoungerPerson);
            Assert.Null(result.OlderPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var finder = new Finder(
                new BirthdayDifferenceRepository(new List<Person> { _sue, _greg }),
                AlgorithmsFactory.GetMinComparer());

            var result = finder.Find();

            Assert.Same(_sue, result.YoungerPerson);
            Assert.Same(_greg, result.OlderPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var finder = new Finder(
                new BirthdayDifferenceRepository(new List<Person> { _greg, _mike }),
                AlgorithmsFactory.GetMaxComparer());

            var result = finder.Find();

            Assert.Same(_greg, result.YoungerPerson);
            Assert.Same(_mike, result.OlderPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var finder = new Finder(
                new BirthdayDifferenceRepository(new List<Person>() { _greg, _mike, _sarah, _sue }),
                AlgorithmsFactory.GetMaxComparer());

            var result = finder.Find();

            Assert.Same(_sue, result.YoungerPerson);
            Assert.Same(_sarah, result.OlderPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var finder = new Finder(
                new BirthdayDifferenceRepository(new List<Person> { _greg, _mike, _sarah, _sue }),
                AlgorithmsFactory.GetMinComparer());

            var result = finder.Find();

            Assert.Same(_sue, result.YoungerPerson);
            Assert.Same(_greg, result.OlderPerson);
        }

        private readonly Person _sue = new Person("Sue", new DateTime(1950, 1, 1));
        private readonly Person _greg = new Person("Greg", new DateTime(1952, 6, 1));
        private readonly Person _sarah = new Person("Sarah", new DateTime(1982, 1, 1));
        private readonly Person _mike = new Person("Mike", new DateTime(1979, 1, 1));
    }
}