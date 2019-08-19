using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("make", "model", 3, 30);
        }

        [Test]
        public void ConstructorHaveToThrowError()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car(null, "asd", 3, 28);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                new Car("asd", null, 3, 28);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                new Car("asd", "asd", 0, 28);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                new Car("asd", "asd", 5, 0);
            });
        }

        [Test]
        public void ConstructorHaveToWorkCorrectly()
        {
            Assert.AreEqual("make", this.car.Make);
            Assert.AreEqual("model", this.car.Model);
            Assert.AreEqual(3, this.car.FuelConsumption);
            Assert.AreEqual(30, this.car.FuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void MethodRefuelHaveToThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(-1);
            });
        }

        [Test]
        public void TestRefuelWithZero()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(0);
            });
        }

        [Test]
        public void MethodRefuelHaveToWorkCorrectly()
        {
            this.car.Refuel(27);
            var firstRefuel = this.car.FuelAmount;
            this.car.Refuel(25);
            var secondRefuel = this.car.FuelAmount;

            Assert.AreEqual(27, firstRefuel);
            Assert.AreEqual(30, secondRefuel);
        }


        [Test]
        public void MethodDrivelHaveToThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(100);
            });
        }

        [Test]
        public void MethodDriveHaveToWorkCorrectly()
        {
            this.car.Refuel(25);
            this.car.Drive(100);

            Assert.AreEqual(22, this.car.FuelAmount);
        }
    }
}