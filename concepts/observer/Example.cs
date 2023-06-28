using System;
namespace Internship
{
    public interface IGameHandler
    {
        void AddPlayer(IGameObserver observer);
        void RemovePlayer(IGameObserver observer);
        void NotifyPlayers(int level);
    }
    public class Game
    {
        Dictionary<string, string> quiz = new Dictionary<string, string>();
        GameEventHandler e;
        public Game()
        {
            e = new GameEventHandler();
            quiz.Add("2 + 2 = ?", "4");
            quiz.Add("2 ^ 4 = ?", "16");
            quiz.Add("2 * 16 ^ 2 = ?", "512");
        }
        private int currLvl;
        public int CurrLvl
        {
            get { return currLvl; }
            set
            {
                if (currLvl != value)
                {
                    currLvl = value;
                    e.NotifyPlayers(currLvl);
                }
            }
        }
        public void Play()
        {
            Console.WriteLine("Welcome to the Quiz!");
            CurrLvl = 1;
            foreach (var kvp in quiz)
            {
                Console.WriteLine("\nQ.{0}. {1}\n\nYour answer: ", CurrLvl, kvp.Key);
                string playerAnswer = Console.ReadLine();
                if (playerAnswer == kvp.Value)
                {
                    Console.WriteLine("\nYour answer is correct!\n");
                    if (CurrLvl == 3)
                    {
                        Console.WriteLine("Congratulations, You have successfully answered all questions!\n");
                        return;
                    }
                    CurrLvl++;
                }
                else
                {
                    Console.WriteLine("\nYour answer is incorrect! Game over!\n");
                    return;
                }
            }
        }
    }
    public class GameEventHandler : IGameHandler
    {
        List<IGameObserver> players = new List<IGameObserver>();
        public void AddPlayer(IGameObserver player)
        {
            Console.WriteLine("\nYou can play this game.\n");
            players.Add(player);
        }
        public void RemovePlayer(IGameObserver player)
        {
            Console.WriteLine("\nYou can no longer play this game.\n");
            players.Remove(player);
        }
        public void NotifyPlayers(int level)
        {
            foreach (IGameObserver player in players)
            {
                player.Update(level);
            }
        }
    }
    public interface IGameObserver{
        void Update(int change);
    }
    public class Player: IGameObserver
    {
        private string name;
        public Player(string name)
        {
            this.name = name;
        }
        public void Update(int level)
        {
            Console.WriteLine("\n{0}'s Game level = {1}.", name, level);
        }
    }
    public class ObserverExample
    {
        public void designPatternDemo()
        {
            Player ravi = new Player("Ravi");
            Game game = new Game();
            GameEventHandler handler = new GameEventHandler();
            
            handler.AddPlayer(ravi);
            game.Play();
        }
    }
}