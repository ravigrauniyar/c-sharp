using System;
namespace Internship
{
    public interface Human
    {
        void Activity(string activity);
    }
    public class Male : Human
    {
        public void Activity(string activity)
        {
            Console.WriteLine("\nMale can " + activity + ".");
        }
    }
    public class Female : Human
    {
        public void Activity(string activity)
        {
            Console.WriteLine("\nFemale can " + activity + ".");
        }
    }
    public class Kid : Human
    {
        public void Activity(string activity)
        {
            Console.WriteLine("\nKid can " + activity + ".");
        }
    }
    public class HumanFactory
    {
        public static Human CreateHuman(string type)
        {
            switch (type)
            {
                case "man":
                    return new Male();
                case "woman":
                    return new Female();
                case "child":
                    return new Kid();
                default:
                    throw new ArgumentException($"Unknown type of Human: {type}", nameof(type));
            }
        }
    }
    public class SimpleFactoryDemo
    {
        public void designPatternDemo()
        {
            var male = HumanFactory.CreateHuman("man");
            male.Activity("walk");
            male.Activity("talk");
            male.Activity("work");
            
            var female = HumanFactory.CreateHuman("woman");
            female.Activity("walk");
            female.Activity("talk");
            female.Activity("work");
            female.Activity("give birth");
            
            var kid = HumanFactory.CreateHuman("child");
            kid.Activity("crawl");
            kid.Activity("cry");
        }
    }
}