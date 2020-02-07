using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;
using Interview.Repository;
using AutoFixture.Xunit2;
using Interview.Model;
using Interview.Storeable;

namespace Interview.Tests
{
    public class InMemoryRepositoryTests
    {
        private IFixture _fixture;
        public InMemoryRepositoryTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _fixture.Inject(_fixture.Create<PersonStore>());
        }

        [Theory, AutoData]
        public void GetAll(InMemoryRepository<IStoreable<Person>, Person> sut)
        {
            Assert.Throws<NotImplementedException>(() => sut.GetAll());
        }

        [Theory, AutoData]
        public void Get(InMemoryRepository<IStoreable<Person>, Person> sut, Person id)
        {
            Assert.Throws<NotImplementedException>(() => sut.Get(id));
        }

        [Theory, AutoData]
        public void Save(InMemoryRepository<IStoreable<Person>, Person> sut, PersonStore item)
        {
            Assert.Throws<NotImplementedException>(() => sut.Save(item));
        }

        [Theory, AutoData]
        public void Delete(InMemoryRepository<IStoreable<Person>, Person> sut, Person id)
        {
            Assert.Throws<NotImplementedException>(() => sut.Delete(id));
        }
    }
}
