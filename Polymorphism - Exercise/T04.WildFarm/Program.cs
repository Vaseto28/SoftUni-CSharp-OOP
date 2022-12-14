namespace T04.WildFarm
{
    using System;
    using System.Collections.Generic;
    using T04.WildFarm.Animals;

    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string infoForAnimal;
            while ((infoForAnimal = Console.ReadLine()) != "End")
            {
                string[] foodInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                string[] animalInfo = infoForAnimal.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string animalType = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                if (animalType == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    Owl owl = new Owl(name, weight, wingSize);

                    Console.WriteLine(owl.ProduceSound());

                    if (foodType == "Meat")
                    {
                        owl.Weight += quantity * 0.25;
                        owl.FoodEaten += quantity;
                    }
                    else
                    {
                        Console.WriteLine($"{animalType} does not eat {foodType}!");
                    }

                    animals.Add(owl);
                }
                else if (animalType == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    Hen hen = new Hen(name, weight, wingSize);

                    Console.WriteLine(hen.ProduceSound());

                    hen.Weight += quantity * 0.35;
                    hen.FoodEaten += quantity;

                    animals.Add(hen);
                }
                else if (animalType == "Mouse")
                {
                    string livingRegion = animalInfo[3];
                    Mouse mouse = new Mouse(name, weight, livingRegion);

                    Console.WriteLine(mouse.ProduceSound());

                    if (foodType == "Vegetable" || foodType == "Fruit")
                    {
                        mouse.Weight += quantity * 0.10;
                        mouse.FoodEaten += quantity;
                    }
                    else
                    {
                        Console.WriteLine($"{animalType} does not eat {foodType}!");
                    }

                    animals.Add(mouse);
                }
                else if (animalType == "Dog")
                {
                    string livingRegion = animalInfo[3];
                    Dog dog = new Dog(name, weight, livingRegion);

                    Console.WriteLine(dog.ProduceSound());

                    if (foodType == "Meat")
                    {
                        dog.Weight += quantity * 0.40;
                        dog.FoodEaten += quantity;
                    }
                    else
                    {
                        Console.WriteLine($"{animalType} does not eat {foodType}!");
                    }

                    animals.Add(dog);
                }
                else if (animalType == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    Cat cat = new Cat(name, weight, livingRegion, breed);

                    Console.WriteLine(cat.ProduceSound());

                    if (foodType == "Meat" || foodType == "Vegetable")
                    {
                        cat.Weight += quantity * 0.30;
                        cat.FoodEaten += quantity;
                    }
                    else
                    {
                        Console.WriteLine($"{animalType} does not eat {foodType}!");
                    }

                    animals.Add(cat);
                }
                else if (animalType == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    Tiger tiger = new Tiger(name, weight, livingRegion, breed);

                    Console.WriteLine(tiger.ProduceSound());

                    if (foodType == "Meat")
                    {
                        tiger.Weight += quantity * 0.40;
                        tiger.FoodEaten += quantity;
                    }
                    else
                    {
                        Console.WriteLine($"{animalType} does not eat {foodType}!");
                    }

                    animals.Add(tiger);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}

