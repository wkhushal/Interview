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
                if (value is null) throw new ArgumentNullException(nameof(Id));
                if (_person is null)
                {
                    _person = value;
                }
                else if(value.Equals(_person))
                {
                    _person = value;
                }
            }
        }
    }
}
