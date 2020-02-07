using AutoFixture.Xunit2;
using Interview.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Interview.Tests.Model
{
    public class PersonTests
    {
        [Theory, AutoData]
        public void EqualsTrue(Person person)
        {
            Assert.True(person.Equals(person));
        }

        [Theory, AutoData]
        public void EqualsTrueProperties(string id, string name, DateTime birthDate)
        {
            // arrange
            var p1 = new Person { Id = id, Name = name, BirthDate = birthDate };
            var p2 = new Person { Id = id, Name = name, BirthDate = birthDate };

            // asserts
            Assert.True(p1.Equals(p2));
        }
        
        [Theory, AutoData]
        public void EqualsPersonFalse(Person person1, Person person2)
        {
            Assert.False(person1.Equals(person2));
        }

        [Theory, AutoData]
        public void EqualsObjectFalse(Person person1, object obj)
        {
            Assert.False(person1.Equals(obj));
        }

        [Theory, AutoData]
        public void GetHashCodeNotEqual(Person p1, Person p2)
        {
            Assert.NotEqual(p1.GetHashCode(), p2.GetHashCode());
        }
    }
}
