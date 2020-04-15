using System;

namespace Algorithm.Person
{
    /// <summary>
    /// Immutable value type.
    /// </summary>
    public sealed class Person : IEquatable<Person>
    {
        public Person(string name, DateTime birthDate)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BirthDate = birthDate;
        }

        public string Name { get; }
        public DateTime BirthDate { get; }
        public override string ToString() => $"{nameof(Name)}: {Name}, {nameof(BirthDate)}: {BirthDate}";

        #region IEquatable, code generated via Resharper

        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && BirthDate.Equals(other.BirthDate);
        }

        public override bool Equals(object obj)
            => ReferenceEquals(this, obj) || obj is Person other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ BirthDate.GetHashCode();
            }
        }

        public static bool operator ==(Person left, Person right) => Equals(left, right);

        public static bool operator !=(Person left, Person right) => !Equals(left, right);
        #endregion
    }
}