using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using Xunit;
using Interview.Repository;
using AutoFixture.Xunit2;
using Interview.Model;
using Interview.Storeable;
using Interview.Store;
using System.Linq;

namespace Interview.Tests
{
    public class InMemoryRepositoryTests
    {
        private IFixture _fixture;
        public InMemoryRepositoryTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _fixture.Inject<IStore>(_fixture.Create<MemStore>());
            _fixture.Inject(_fixture.Create<PersonStore>());
        }

        [Fact]
        public void ConstructorGuardArgumentNull()
        {
            var assertion = new GuardClauseAssertion(_fixture);
            var constructors = typeof(InMemoryRepository).GetConstructors();
            assertion.Verify(constructors);
        }

        [Fact]
        public void GetAll()
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository>();

            // action
            var result = sut.GetAll();
            // asserts
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory, AutoData]
        public void Get(Person id)
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository>();
            // action
            var result = sut.Get(id);
            // asserts
            Assert.Null(result);
        }

        [Fact]
        public void GetThrowsArgumentNullException()
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository>();
            // asserts
            Assert.Throws<ArgumentNullException>(() => sut.Get(null));
        }

        [Theory, AutoData]
        public void Save(PersonStore item)
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository>();
            // action
            sut.Save(item);
            // asserts
            var allStored = sut.GetAll();
            Assert.NotEmpty(allStored);
            Assert.Equal(item, allStored.First());
        }

        [Fact]
        public void SaveThrowsArgumentNullException()
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository>();
            // asserts
            Assert.Throws<ArgumentNullException>(() => sut.Save(null));
        }

        [Theory, AutoData]
        public void Delete(PersonStore person)
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository>();
            sut.Save(person);
            var preList = sut.GetAll();
            // action
            sut.Delete(person.Id);
            // asserts
            Assert.NotEmpty(preList);
            Assert.Equal(person, preList.First());
            Assert.Empty(sut.GetAll());
        }

        [Fact]
        public void DeleteThrowsArgumentNullException()
        {
            // arrange
            var sut = _fixture.Create<InMemoryRepository>();
            // asserts
            Assert.Throws<ArgumentNullException>(() => sut.Delete(null));
        }
    }
}
