IRoll roll = new Game();
RollDice rollDice = new RollDice(roll);
rollDice.Roll();
Console.ReadLine();

public interface IRoll
{
    void ShowMessage(string message);
    int RandomNo();
}

public class RollDice
{
    private readonly IRoll _game;

    public RollDice(IRoll game)
    {
        _game = game;

    }

    internal void Roll()
    {
        int counter = 0;
        int randomNo = _game.RandomNo();
        _game.ShowMessage($"Dice rolled. Guess what number it shows in {3 - counter} tries.");
        while (counter < 3)
        {
            int UserInput = int.Parse(Console.ReadLine());
            if (UserInput == randomNo)
            {
                _game.ShowMessage("You win");
                return;
            }
            else
            {
                _game.ShowMessage("Wrong number");
                ++counter;
            }
        }
        _game.ShowMessage($"you lost the correct number was {randomNo}");
    }
}


public class Game : IRoll
{
    private readonly int _diceFace = 7;
    public int RandomNo()
    {
        Random Rnd = new Random();
        int num = Rnd.Next(1, _diceFace);
        return num;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}