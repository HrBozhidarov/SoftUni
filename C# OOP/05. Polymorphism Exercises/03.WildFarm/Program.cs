using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _03.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            List<Animal> animals = new List<Animal>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input.Split();
                string animalType = animalInfo[0];
                string[] food = Console.ReadLine().Split();

                Food currentFood = ReadFoods(food);
                Animal animal = FeedAnimals(animals, animalInfo, animalType, currentFood);
                animal.ProducingSound();
                animal.TryToFeed(currentFood);
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Animal FeedAnimals(List<Animal> animals, string[] animalInfo, string animalType, Food currentFood)
        {
            switch (animalType)
            {
                case "Owl":
                    Animal owl = new Owl(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                    return owl;
                case "Hen":
                    Animal hen = new Hen(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                    return hen;
                case "Mouse":
                    Animal mouse = new Mouse(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                    return mouse;
                case "Dog":
                    Animal dog = new Dog(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                    return dog;
                case "Cat":
                    Animal cat = new Cat(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                    return cat;
                case "Tiger":
                    Animal tiger = new Tiger(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                    return tiger;
                default: throw new ArgumentException("Invalid Input!");
            }
        }

        private static Food ReadFoods(string[] food)
        {
            Food currentFood = null;

            switch (food[0])
            {
                case "Vegetable":
                    Food vegetable = new Vegetable(int.Parse(food[1]));
                    currentFood = vegetable;
                    break;
                case "Fruit":
                    Food fruit = new Fruit(int.Parse(food[1]));
                    currentFood = fruit;
                    break;
                case "Meat":
                    Food meat = new Meat(int.Parse(food[1]));
                    currentFood = meat;
                    break;
                case "Seeds":
                    Food seeds = new Seeds(int.Parse(food[1]));
                    currentFood = seeds;
                    break;
            }

            return currentFood;
        }
    }
}