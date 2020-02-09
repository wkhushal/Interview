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
    }
}
