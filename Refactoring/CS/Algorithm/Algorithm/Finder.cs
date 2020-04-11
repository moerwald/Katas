﻿using System;
using System.Linq;
using Algorithm.FindAlgorithms;

namespace Algorithm
{
    public sealed class Finder
    {
        private readonly IBirthdayDifferenceRepository _repository;
        private readonly IBirthdayDiffComparer _comparer;

        public Finder(
            IBirthdayDifferenceRepository repository,
            IBirthdayDiffComparer comparer)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        public BirthdayDifference Find()
            => _repository.GetRepository()
                .Aggregate((current, next) =>
                    _comparer.Compare(next, current));
    }
}