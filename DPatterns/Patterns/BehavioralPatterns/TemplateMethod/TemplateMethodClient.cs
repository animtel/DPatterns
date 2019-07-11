namespace DPatterns.Patterns.BehavioralPatterns.TemplateMethod
{
    public class TemplateMethodClient : IClient
    {
        public TemplateMethodClient()
        {
            Execute();
        }

        public void Execute()
        {
            var chess = new Chess();
            chess.Run();
        }
    }

    public abstract class Game
    {
        protected int currentPlayer;
        protected readonly int numberOfPlayers;

        public Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }

        public void Run()
        {
            Start();
            while (!HaveWinner)
            {
                TakeTurn();
            }
            System.Console.WriteLine($"Player {WinningPlayer} wins.");
        }

        protected abstract void Start();
        protected abstract void TakeTurn();
        protected abstract bool HaveWinner {get;}
        protected abstract int WinningPlayer{get;}
    }

    public class Chess : Game
    {
        private int turn = 1;
        private int maxTurns = 10;

        public Chess() : base(2) // 2 players plaing
        {
        }

        protected override bool HaveWinner => turn == maxTurns;

        protected override int WinningPlayer => currentPlayer;

        protected override void Start()
        {
            System.Console.WriteLine($"Starting a game of chess with {numberOfPlayers} players.");
        }

        protected override void TakeTurn()
        {
            System.Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }
    }
}