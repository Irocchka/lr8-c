using library;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Lab_08_01
{
    class Program
    {
        static void main()
        {

            XmlSerializer mySerializer = new XmlSerializer(typeof(Animal));

            Animal testAnimal = new Animal("Scotland", true, "Billy Bob Milly", "cold");

            using (FileStream output = File.Create("C:/Users/79526/source/repos/lr8/lr8/test.xml"))
            {
                mySerializer.Serialize(output, testAnimal);
                Console.WriteLine("Serializing...............");
            }

            Animal cloneAnimal;

            using (FileStream input = File.Open("C:/Users/79526/source/repos/lr8/lr8/test.xml", FileMode.Open))
            {
                cloneAnimal = (Animal)mySerializer.Deserialize(input);
                Console.WriteLine("Deserializing...............");
            }

            Console.WriteLine($"Country: {cloneAnimal.Country}" +
                            $"\n{(cloneAnimal.HideFromOtherAnimals ? "Hides" : "Doesn't hide")} from other animals" +
                            $"\nName: {cloneAnimal.Name}" +
                            $"\nIs a {cloneAnimal.WhatAnimal}");
        }

    }

}