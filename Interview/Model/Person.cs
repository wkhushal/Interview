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
            
            var p = obj as Person;
            return (p is null) ? false : 
                Id == p.Id && 
                Name == p.Name && 
                BirthDate == p.BirthDate;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Id.GetHashCode();
            hash = (hash * 7) + Name.GetHashCode();
            hash = (hash * 7) + BirthDate.GetHashCode();
            return hash;
        }
    }
}
