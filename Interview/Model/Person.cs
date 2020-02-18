using System;

namespace Interview.Model
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Person))
            {
                return false;
            }

            return (!(obj is Person p)) ? false : Id == p.Id;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Id.GetHashCode();
            return hash;
        }
    }
}
