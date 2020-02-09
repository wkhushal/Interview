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
    }
}
