using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
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

        [Fact]
        public void ConstructorGuardArgumentNull()
        {
            var assertion = new GuardClauseAssertion(_fixture);
            var constructors = typeof(InMemoryRepository<IStoreable<Person>, Person>).GetConstructors();
            assertion.Verify(constructors);
        }

        [Fact]
        public void GetAll()
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository<IStoreable<Person>, Person>>();
            // asserts
            Assert.Throws<NotImplementedException>(() => sut.GetAll());
        }

        [Theory, AutoData]
        public void Get(Person id)
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository<IStoreable<Person>, Person>>();
            // asserts
            Assert.Throws<NotImplementedException>(() => sut.Get(id));
        }

        [Fact]
        public void GetThrowsArgumentNullException()
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository<IStoreable<Person>, Person>>();
            // asserts
            Assert.Throws<ArgumentNullException>(() => sut.Get(null));
        }

        [Theory, AutoData]
        public void Save(PersonStore item)
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository<IStoreable<Person>, Person>>();
            // asserts
            Assert.Throws<NotImplementedException>(() => sut.Save(item));
        }

        [Fact]
        public void SaveThrowsArgumentNullException()
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository<IStoreable<Person>, Person>>();
            // asserts
            Assert.Throws<ArgumentNullException>(() => sut.Save(null));
        }

        [Theory, AutoData]
        public void Delete(Person id)
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository<IStoreable<Person>, Person>>();
            // asserts
            Assert.Throws<NotImplementedException>(() => sut.Delete(id));
        }

        [Fact]
        public void DeleteThrowsArgumentNullException()
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository<IStoreable<Person>, Person>>();
            // asserts
            Assert.Throws<ArgumentNullException>(() => sut.Delete(null));
        }
    }
}
