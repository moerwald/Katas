using System;

namespace Algorithm.BirthdayDifference.Model
{
    /// <summary>
    /// Value type
    /// </summary>
    public class BirthdayDifference : IEquatable<BirthdayDifference>
    {
        protected BirthdayDifference() { }

        public BirthdayDifference(Person.Person p1, Person.Person p2)
        {
            YoungerPerson = p1.BirthDate < p2.BirthDate ? p1 : p2;
            OlderPerson = YoungerPerson == p1 ? p2 : p1;
            Difference = OlderPerson.BirthDate - (YoungerPerson.BirthDate);
        }

        public Person.Person YoungerPerson { get; }
        public Person.Person OlderPerson { get; }
        public TimeSpan Difference { get; }

        #region IEquatable, Code generated via Resharper
        public bool Equals(BirthdayDifference other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(YoungerPerson, other.YoungerPerson) &&
                   Equals(OlderPerson, other.OlderPerson) ;

        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BirthdayDifference)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (YoungerPerson != null ? YoungerPerson.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OlderPerson != null ? OlderPerson.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Difference.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(BirthdayDifference left, BirthdayDifference right)
            => Equals(left, right);

        public static bool operator !=(BirthdayDifference left, BirthdayDifference right)
            => !Equals(left, right);

        #endregion

        public override string ToString()
        {
            return $"{nameof(YoungerPerson)}: {YoungerPerson}, {nameof(OlderPerson)}: {OlderPerson}, {nameof(Difference)}: {Difference}";
        }
    }
}