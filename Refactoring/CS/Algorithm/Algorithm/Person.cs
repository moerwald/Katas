using System;

namespace Algorithm
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(BirthDate)}: {BirthDate}";
        }
    }
}