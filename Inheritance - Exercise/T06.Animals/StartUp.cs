using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //List<Animal> animals = new List<Animal>();
            //Dictionary<string, List<Animal>> animals = new Dictionary<string, List<Animal>>();

            List<Animal> animals = new List<Animal>();

            string firstCommand = Console.ReadLine();
            while (true)
            {
                if (firstCommand == "Beast!")
                {
                    break;
                }

                string animalType = firstCommand;

                string secondCommand = Console.ReadLine();
                string[] secondCommandArgs = secondCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = secondCommandArgs[0];
                string stringAge = secondCommandArgs[1];
                string gender = secondCommandArgs[2];

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(stringAge) || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    firstCommand = Console.ReadLine();
                    continue;
                }

                int age = int.Parse(stringAge);
                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    firstCommand = Console.ReadLine();
                    continue;
                }

                if (animalType == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (animalType == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (animalType == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                }
                else if (animalType == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }
                else
                {
                    Frog frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }

                firstCommand = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
