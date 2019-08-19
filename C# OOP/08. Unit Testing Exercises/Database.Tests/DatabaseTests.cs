using NUnit.Framework;
using Database;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(1, 2, 3);
        }

        [Test]
        public void ConstructorHaveToWorkCorrectly()
        {
            Assert.AreEqual(3, this.database.Count);
        }

        [Test]
        public void AddMethodHaveToWorkCorrectly()
        {
            this.database.Add(4);

            Assert.AreEqual(this.database.Count, 4);
            Assert.AreEqual(4, this.database.Fetch()[3]);
        }

        [Test]
        public void AddMethodHaveToThrow()
        {
            for (int i = this.database.Count; i <= 15; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(1);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemovethodHaveToWorkCorrectly()
        {
            this.database.Remove();

            Assert.AreEqual(this.database.Count, 2);
            Assert.AreEqual(2, this.database.Fetch()[1]);
        }

        [Test]
        public void RemoveMethodHaveToThrow()
        {
            this.database.Remove();
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            }, "The collection is empty!");
        }

        [Test]
        public void FetchMethodHaveToWorkCorrectly()
        {
            var expectedArr = new int[] { 1, 2, 3 };
            var actualArr = this.database.Fetch();

            Assert.AreEqual(expectedArr.Length, actualArr.Length);

            for (int i = 0; i < actualArr.Length; i++)
            {
                Assert.AreEqual(expectedArr[i], actualArr[i]);
            }
        }
    }
}