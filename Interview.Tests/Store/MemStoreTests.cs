using System;
using System.Linq;
using Xunit;
using AutoFixture.Xunit2;
using Interview.Model;
using Interview.Store;

namespace Interview.Tests.Store
{
    public class MemStoreTests
    {
        [Theory, AutoData]
        public async void GetAllAsyncEmpty(MemStore sut)
        {
            // action
            var result = await sut.GetAllAsync(default);
            // asserts
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory, AutoData]
        public void GetAsyncThrowsArgumentNullException(MemStore sut)
        {
            // asserts
            Assert.ThrowsAsync<ArgumentNullException>(async () => await sut.GetAsync(null, default));
        }

        [Theory, AutoData]
        public async void GetAsync(MemStore sut, Person person)
        {
            // arrange
            await sut.SaveAsync(person, default);
            // action
            var result = await sut.GetAsync(person.Id, default);
            // asserts
            Assert.Equal(result, person);
        }

        [Theory, AutoData]
        public void DeleteAsyncThrowsArgumentNullException(MemStore sut) {
            // asserts
            Assert.ThrowsAsync<ArgumentNullException>(async () => await sut.DeleteAsync(null, default));
        }

        [Theory, AutoData]
        public async void DeleteAsync(MemStore sut, Person person)
        {
            // arrange
            await sut.SaveAsync(person, default);
            var preList = await sut.GetAllAsync(default);
            
            // action
            await sut.DeleteAsync(person.Id, default);
            
            // asserts
            Assert.NotEmpty(preList);
            Assert.Equal(preList.First(), person); // it was in the store
            var postList = await sut.GetAllAsync(default);
            Assert.Empty(postList);
        }

        [Theory, AutoData]
        public void SaveAsyncThrowsArgumentNullException(MemStore sut) {
            // asserts
            Assert.ThrowsAsync<ArgumentNullException>(async () => await sut.SaveAsync(null, default));
        }

        [Theory, AutoData]
        public async void SaveAsync(MemStore sut, Person person)
        {
            // arrange
            var preList = await sut.GetAllAsync(default);

            // action
            await sut.SaveAsync(person, default);
            // asserts

            Assert.Empty(preList);
            var postList = await sut.GetAllAsync(default);
            Assert.NotEmpty(postList);
            Assert.Equal(postList.First(), person);
        }
    }
}
