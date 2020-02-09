using AutoFixture;
using AutoFixture.Xunit2;
using Interview.Model;
using Interview.Storeable;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Interview.Tests.Storeable
{
    public class PersonStoreTests
    {
        [Theory, AutoData]
        public void PersonStoreIdNotNull(PersonStore sut)
        {
            Assert.NotNull(sut.Id);
        }

        [Theory, AutoData]
        public void PersonStoreThrowsArgumentNullException(PersonStore sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.Id = null);
        }

        [Theory, AutoData]
        public void PersonStore(PersonStore sut, Person newPerson)
        {
            // action
            sut.Id = newPerson;
            // asserts
            Assert.Equal(newPerson, sut.Id);
        }

        [Theory, AutoData]
        public void EqualsTrue(PersonStore store1, PersonStore store2, Person person)
        {
            // action
            store1.Id = person;
            store2.Id = person;
            // asserts
            Assert.Equal(store1, store2);
        }

        [Theory, AutoData]
        public void GetHashCodeNotEqual(PersonStore store1, PersonStore store2)
        {
            // asserts
            Assert.NotEqual(store1.GetHashCode(), store2.GetHashCode());
        }

        [Theory, AutoData]
        public void GetHashCodeEqual(PersonStore store1, PersonStore store2, Person person)
        {
            // action
            store1.Id = person;
            store2.Id = person;
            // asserts
            Assert.Equal(store1.GetHashCode(), store2.GetHashCode());
        }
    }
}
