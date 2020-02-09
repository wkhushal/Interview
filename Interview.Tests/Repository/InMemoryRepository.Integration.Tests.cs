using System;
using System.Linq;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using Xunit;
using Interview.Repository;
using AutoFixture.Xunit2;
using Interview.Model;
using Interview.Storeable;
using Interview.Store;
using Moq;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.Tests.Repository
{
    public class InMemoryRepositoryIntegrationTests
    {
        [Theory, AutoData]
        public void GetAll(IFixture fixture, Person[] persons)
        {
            // arrange
            var mockedStore = fixture.Create<Mock<IStore>>();
            
            mockedStore
                .Setup(fake => fake.GetAllAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(persons as IEnumerable<Person>));

            fixture.Inject(mockedStore);
            fixture.Customize(new AutoMoqCustomization());
            
            var sut = fixture.Create<InMemoryRepository>();
            // action
            var result = sut.GetAll().ToList();
            // asserts
            mockedStore.Verify(fake => fake.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory, AutoData]
        public void Get(IFixture fixture, Person person)
        {
            // arrange
            var mockedStore = fixture.Create<Mock<IStore>>();

            mockedStore
                .Setup(fake => fake.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(person));

            fixture.Inject(mockedStore);
            fixture.Customize(new AutoMoqCustomization());

            var sut = fixture.Create<InMemoryRepository>();
            // action
            var result = sut.Get(person);
            // asserts
            mockedStore.Verify(fake => fake.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory, AutoData]
        public void Save(IFixture fixture, PersonStore person)
        {
            // arrange
            var mockedStore = fixture.Create<Mock<IStore>>();

            mockedStore
                .Setup(fake => fake.SaveAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(person.Id));

            fixture.Inject(mockedStore);
            fixture.Customize(new AutoMoqCustomization());

            var sut = fixture.Create<InMemoryRepository>();
            
            // action
            sut.Save(person);

            // asserts
            mockedStore.Verify(fake => fake.SaveAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory, AutoData]
        public void Delete(IFixture fixture, Person person)
        {
            // arrange
            var mockedStore = fixture.Create<Mock<IStore>>();

            mockedStore
                .Setup(fake => fake.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(person.Id));

            fixture.Inject(mockedStore);
            fixture.Customize(new AutoMoqCustomization());

            var sut = fixture.Create<InMemoryRepository>();
            // action
            sut.Delete(person);
            // asserts
            mockedStore.Verify(fake => fake.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
