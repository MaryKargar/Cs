using System;
using System.Collections.Generic;

// Container-Klasse zur Darstellung von Containern
class Container
{
    public string ContainerNumber { get; set; }
    public string Destination { get; set; }
    public int Weight { get; set; }
}

// Hafen-Klasse zur Verwaltung des Hafenbetriebs
class Port
{
    private List<Container> storage = new List<Container>();

    // Methode zum Be- und Entladen von Containern
    public void LoadContainer(Container container)
    {
        storage.Add(container);
        Console.WriteLine($"Container {container.ContainerNumber} wurde geladen.");
    }

    public void UnloadContainer(Container container)
    {
        if (storage.Contains(container))
        {
            storage.Remove(container);
            Console.WriteLine($"Container {container.ContainerNumber} wurde entladen.");
        }
        else
        {
            Console.WriteLine($"Container {container.ContainerNumber} nicht gefunden.");
        }
    }

    // Methode zur Anzeige des aktuellen Lagerbestands
    public void DisplayInventory()
    {
        Console.WriteLine("Aktueller Lagerbestand:");
        foreach (var container in storage)
        {
            Console.WriteLine($"Container: {container.ContainerNumber}, Ziel: {container.Destination}, Gewicht: {container.Weight} kg");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Port port = new Port();

        while (true)
        {
            Console.WriteLine("1. Container laden");
            Console.WriteLine("2. Container entladen");
            Console.WriteLine("3. Lagerbestand anzeigen");
            Console.WriteLine("4. Beenden");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl zwischen 1 und 4 ein.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Container-Nummer eingeben:");
                    string containerNumber = Console.ReadLine();
                    Console.WriteLine("Ziel eingeben:");
                    string destination = Console.ReadLine();
                    Console.WriteLine("Gewicht eingeben:");
                    if (!int.TryParse(Console.ReadLine(), out int weight))
                    {
                        Console.WriteLine("Ungültiges Gewicht. Bitte geben Sie eine ganze Zahl ein.");
                        continue;
                    }

                    Container container = new Container
                    {
                        ContainerNumber = containerNumber,
                        Destination = destination,
                        Weight = weight
                    };

                    port.LoadContainer(container);
                    break;

                case 2:
                    Console.WriteLine("Container-Nummer eingeben:");
                    string containerToRemove = Console.ReadLine();

                    Container containerToUnload = port.storage.Find(c => c.ContainerNumber == containerToRemove);
                    if (containerToUnload != null)
                    {
                        port.UnloadContainer(containerToUnload);
                    }
                    else
                    {
                        Console.WriteLine("Container nicht gefunden.");
                    }
                    break;

                case 3:
                    port.DisplayInventory();
                    break;

                case 4:
                    Console.WriteLine("Programm wird beendet.");
                    return;

                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte geben Sie eine Zahl zwischen 1 und 4 ein.");
                    break;
            }
        }
    }
}
