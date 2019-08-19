using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("warrior", 20, 40);
        }

        [Test]
        public void ConstructorHaveToThrowError()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(null, 20, 40);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("warrior", 0, 40);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("warrior", 20, -1);
            });
        }

        [Test]
        public void AttackMethodHaveToThrowErrorIfHpIsSmallerThenMinAttack()
        {
            var warrior = new Warrior("warrior", 30, 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(this.warrior);
            });
        }

        [Test]
        public void AttackMethodHaveToThrowErrorIfHpIsSmallerThenMinAttackFromThePassedWarrior()
        {
            var warrior = new Warrior("warrior", 30, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(new Warrior("warrior", 30, 20));
            });
        }

        [Test]
        public void AttackMethodHaveToThrowErrorIfPassedWarriorHaveMoreDamageThenHpOnTheCurrentWarrior()
        {
            var warrior = new Warrior("warrior", 45, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(new Warrior("warrior", 50, 40));
            });
        }

        [Test]
        public void AttackMethodHaveToWorkCorrectlyThisDamageIsEqualOrSmallerThenPassedWarriorHp()
        {
            var warrior = new Warrior("warrior", 45, 40);
            var secondWarrior = new Warrior("warrior", 35, 50);

            warrior.Attack(secondWarrior);

            Assert.AreEqual(5, secondWarrior.HP);
            Assert.AreEqual(5, warrior.HP);
        }

        [Test]
        public void AttackMethodHaveToWorkCorrectlyThisDamageIsBiggerThenPassedWarriorHp()
        {
            var warrior = new Warrior("warrior", 55, 40);
            var secondWarrior = new Warrior("warrior", 35, 50);

            warrior.Attack(secondWarrior);

            Assert.AreEqual(0, secondWarrior.HP);
            Assert.AreEqual(5, warrior.HP);
        }
    }
}