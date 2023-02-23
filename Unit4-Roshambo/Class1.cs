using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit4_Roshambo
{
    public enum Roshambo
    {
        Rock,
        Paper,
        Scissors
    }

    // Define abstract Player class
    public abstract class Player
    {
        public string Name { get; }
        public Roshambo Choice { get; protected set; }

        public Player(string name)
        {
            Name = name;
        }

        public abstract Roshambo GenerateRoshambo();
    }

    // Define RockPlayer class
    public class RockPlayer : Player
    {
        public RockPlayer() : base("RockPlayer")
        {
        }

        public override Roshambo GenerateRoshambo()
        {
            Choice = Roshambo.Rock;
            return Choice;
        }
    }

    // Define RandomPlayer class
    public class RandomPlayer : Player
    {
        public readonly Random random = new Random();

        public RandomPlayer() : base("RandomPlayer")
        {
        }

        public override Roshambo GenerateRoshambo()
        {
            Choice = (Roshambo)random.Next(3);
            return Choice;
        }
    }

    // Define HumanPlayer class
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name)
        {
        }

        public override Roshambo GenerateRoshambo()
        {
            while (true)
            {
                Console.Write("Enter 1 for Rock, 2 for Paper, or 3 for Scissors: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && Enum.IsDefined(typeof(Roshambo), choice - 1))
                {
                    Choice = (Roshambo)(choice - 1);
                    return Choice;
                }

                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }
        }
    }
}