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
        public void PersonStore(PersonStore sut)
        {
            Assert.NotNull(sut.Id);
        }
    }
}
