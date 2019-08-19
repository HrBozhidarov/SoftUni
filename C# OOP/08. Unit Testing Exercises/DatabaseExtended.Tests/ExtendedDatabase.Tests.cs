using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            var people = new Person[]
            {
                new Person(1, "Ico"),
                new Person(2, "Hrisi"),
                new Person(3, "Dancho")
            };

            this.database = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void ConstructorHaveToWorkCorrectly()
        {
            Assert.AreEqual(3, this.database.Count);
        }

        [Test]
        public void ConstructorHaveToThrow()
        {
            var people = new Person[17];

            for (int i = 0; i <= 16; i++)
            {
                people[i] = new Person(i, "user" + i);
            }

            Assert.Throws<ArgumentException>(() =>
            {
                new ExtendedDatabase.ExtendedDatabase(people);
            });
        }

        [Test]
        public void MethodAddHaveToThrowErrorWhenAddSixteenPerson()
        {
            var people = new Person[16];

            for (int i = 0; i < 16; i++)
            {
               people[i] = new Person(i, "user" + i);
            }

            var db = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(23, "23"));
            });
        }

        [Test]
        public void MethodAddHaveToThrowErrorIfTwoPersonHaveTheSameName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(12, "Ico"));
            });
        }

        [Test]
        public void MethodAddHaveToThrowErrorIfTwoPersonHaveTheSameId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(1, "asdasd"));
            });
        }

        [Test]
        public void MethodAddHaveToWorkCorrectly()
        {
            this.database.Add(new Person(12, "asdasd"));

            Assert.AreEqual(4, this.database.Count);
        }

        [Test]
        public void MethodRemoveHaveToThrowIfCountOfPeopleIsZero()
        {
            var db = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void MethodRemoveHaveToWorkCorrectly()
        {
            this.database.Remove();

            Assert.AreEqual(2, this.database.Count);
        }

        [Test]
        public void FindByUsernameHaveToTrhowIfNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(null);
            });
        }

        [Test]
        public void FindByUsernameHaveToTrhowIfNameDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindByUsername("gosho");
            });
        }

        [Test]
        public void FindByUsernameHaveToWorkCorrectly()
        {
            var person = this.database.FindByUsername("Ico");

            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("Ico", person.UserName);
        }

        [Test]
        public void FindByIdHaveToTrhowIfNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(-1);
            });
        }

        [Test]
        public void FindByIdHaveToTrhowIfNameDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(5);
            });
        }

        [Test]
        public void FindByIdHaveToWorkCorrectly()
        {
            var person = this.database.FindById(1);

            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("Ico", person.UserName);
        }
    }
}