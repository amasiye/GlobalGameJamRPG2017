using UnityEngine;
using System.Collections;

public struct Command
{
    public string name;
    public int amount;
    public int cost;
    public Character.Element binding;

    public Command(string name, int amount, int cost = 1, Character.Element binding = Character.Element.Fire)
    {
        this.name = name;
        this.amount = amount;
        this.cost = cost;
        this.binding = binding;
    }
}

public class CommandList
{
    public static Command slash = new Command("Slash", 10);
    public static Command fire = new Command("Fire", 50, 5);
    public static Command ice = new Command("Ice", 50, 5);
    public static Command lightning = new Command("Lightning", 50, 5);
    public static Command earth = new Command("Earth", 50, 5);
    public static Command wave = new Command("Wave", 15, 3);
    public static Command bigWave = new Command("Big Wave", 30, 6);
    public static Command tsunami = new Command("Tsunami", 50, 10);
}
