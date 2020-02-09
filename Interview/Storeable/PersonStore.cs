using Interview.Model;
using System;

namespace Interview.Storeable
{
    public class PersonStore : IStoreable<Person>
    {
        private Person _person;
        public Person Id
        {
            get => _person;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(Id));
                }
                _person = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is PersonStore))
            {
                return false;
            }

            var p = obj as PersonStore;
            return (p is null) ? false : Id.Equals(p.Id);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Id.GetHashCode();
            return hash;
        }
    }
}
