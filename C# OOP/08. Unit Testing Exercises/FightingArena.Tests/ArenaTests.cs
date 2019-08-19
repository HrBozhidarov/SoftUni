using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ConstructorHaveToWorkCorrectly()
        {
            Assert.AreEqual(0, this.arena.Count);
        }

        [Test]
        public void EnrollMethodHaveToThrow()
        {
            this.arena.Enroll(new Warrior("warrior", 40, 50));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(new Warrior("warrior", 40, 50));
            });
        }

        [Test]
        public void EnrollMethodHaveToWorkCorrectly()
        {
            this.arena.Enroll(new Warrior("warrior", 40, 50));
            this.arena.Enroll(new Warrior("warrior1", 40, 50));

            Assert.AreEqual(2, this.arena.Count);
        }

        [Test]
        public void FightMethodHaveToThrow()
        {
            this.arena.Enroll(new Warrior("warrior", 40, 50));
            this.arena.Enroll(new Warrior("warrior1", 40, 50));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("invalidName", "warrior1");
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("warrior", "invalidName");
            });
        }

        [Test]
        public void FightMethodHaveWorkCorretly()
        {
            this.arena.Enroll(new Warrior("warrior", 40, 50));
            this.arena.Enroll(new Warrior("warrior1", 40, 50));

            this.arena.Fight("warrior", "warrior1");

            var warriors = this.arena.Warriors;

            var hps = new List<int>();

            foreach (var warrior in warriors)
            {
                hps.Add(warrior.HP);
            }

            Assert.AreEqual(10, hps[1]);
            Assert.AreEqual(10, hps[0]);
            Assert.AreEqual(2, this.arena.Count);
        }
    }
}
