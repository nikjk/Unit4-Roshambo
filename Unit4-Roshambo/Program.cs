using Unit4_Roshambo;

Console.Write("Enter your name: ");
string humanName = Console.ReadLine();
HumanPlayer humanPlayer = new HumanPlayer(humanName);

// Choose opponent
while (true)
{
    Console.Write("Enter 1 to play against RockPlayer or 2 to play against RandomPlayer: ");
    if (int.TryParse(Console.ReadLine(), out int opponentchoice) && (opponentchoice == 1 || opponentchoice == 2))
    {
        Player opponent = opponentchoice == 1 ? new RockPlayer() : new RandomPlayer();

        // Play the game
        Roshambo humanChoice = humanPlayer.GenerateRoshambo();
        Roshambo opponentChoice = opponent.GenerateRoshambo();

        Console.WriteLine($"{humanPlayer.Name} chose {humanChoice}");
        Console.WriteLine($"{opponent.Name} chose {opponentChoice}");

        if (humanChoice == opponentChoice)
        {
            Console.WriteLine("It's a tie!");
        }
        else if ((humanChoice == Roshambo.Rock && opponentChoice == Roshambo.Scissors) ||
                 (humanChoice == Roshambo.Paper && opponentChoice == Roshambo.Rock) ||
                 (humanChoice == Roshambo.Scissors && opponentChoice == Roshambo.Paper))
        {
            Console.WriteLine($"{humanPlayer.Name} wins!");
        }
        else
        {
            Console.WriteLine($"{opponent.Name} wins!");
        }

        break;
    }

    Console.WriteLine("Invalid input. Please enter 1 or 2.");
}