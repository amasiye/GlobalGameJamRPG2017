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
    public static Command slash = new Command("Slash", 10, 2);
    public static Command fire = new Command("Inferno", 50, 5);
    public static Command ice = new Command("Blizaro", 50, 5);
    public static Command lightning = new Command("Shockeroo", 50, 5);
    public static Command earth = new Command("Rockeroo", 50, 5);
    public static Command wave = new Command("Wave", 4, 3);
    public static Command bigWave = new Command("Big Wave", 10, 5);
    public static Command tsunami = new Command("Tsunami", 15, 10);
}
