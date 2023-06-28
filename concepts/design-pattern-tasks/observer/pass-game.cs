using System;
namespace Internship
{
    public class Players
    {
        private string name;
        private bool hasBall;
        public Players(string name, bool hasBall)
        {
            this.name = name;
            this.hasBall = hasBall;
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public bool HasBall
        {
            get { return hasBall; }
            set
            {
                hasBall = value;
            }
        }
    }
    public interface IGame
    {
        void AddObserver(IGameObservers observer);
        void RemoveObserver(IGameObservers observer);
        void NotifyObservers();
    }
    public class Games : IGame
    {
        Random random = new Random();
        private int randomIndx = 0;
        public int BallPosition
        {
            get { return randomIndx; }
            set
            {
                if (randomIndx != value)
                {
                    randomIndx = value;
                    NotifyObservers();
                    Thread.Sleep(2000);
                }
            }
        }
        List<IGameObservers> observers = new List<IGameObservers>();
        List<Players> players = new List<Players>();
        public Games()
        {
            string[] player_names = { "Ravi", "Sujar", "Abhishek", "Ashraf", "Biplav" };
            for (int i = 0; i < 5; i++)
            {
                players.Add(new Players(player_names[i], false));
            }
        }

        static object resource = new object();
        public void AddObserver(IGameObservers observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IGameObservers observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (IGameObservers obs in observers)
            {
                obs.Update();
            }
        }
        public void Play()
        {
            while (true)
            {
                BallPosition = Convert.ToInt32(random.NextInt64(0, 5));
                players.ElementAt(BallPosition).HasBall = true;

                Console.WriteLine("\nPLAYERS LIST");
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("ID: {0}, Name: {1}\t", i + 1, players.ElementAt(i).Name);
                }
                Thread.Sleep(1000);
                Console.WriteLine("\nNow Guess who has the ball. ");

                int guess = Convert.ToInt32(random.NextInt64(0, 5));

                if (guess != BallPosition)
                {
                    Console.WriteLine("\nGuess: {0}\n{0} did not have the ball!", players.ElementAt(guess).Name);
                    Thread.Sleep(1000);
                    Console.WriteLine("\n{0} had the ball. Try again!", players.ElementAt(BallPosition).Name);
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Congrats! {0} did have the ball. Game over!\n", players.ElementAt(guess).Name);
                    Thread.Sleep(1000);
                    return;
                }
            }
        }
    }
    public interface IGameObservers
    {
        void Update();
    }
    public class GuessingPlayer : IGameObservers
    {
        private int player_id;
        public int Player_Id
        {
            get { return player_id; }
            set { player_id = value; }
        }
        public GuessingPlayer(int id)
        {
            player_id = id;
        }
        public void Update()
        {
            Console.WriteLine("\nPass Complete!\n");
        }
    }
    public class BallGameDemo
    {
        public void Start()
        {
            GuessingPlayer guessingPlayer = new GuessingPlayer(1);
            Games game = new Games();

            game.AddObserver(guessingPlayer);
            game.Play();
        }
    }
}