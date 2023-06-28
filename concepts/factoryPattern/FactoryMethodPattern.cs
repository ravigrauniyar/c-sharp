using System;
namespace Internship
{
    public interface Person
    {
        void Activity(string activity);
    }
    public class Man : Person
    {
        public void Activity(string activity)
        {
            Console.WriteLine("\nMan can " + activity + ".");
        }
    }
    public class Woman : Person
    {
        public void Activity(string activity)
        {
            Console.WriteLine("\nWoman can " + activity + ".");
        }
    }
    public class Child : Person
    {
        public void Activity(string activity)
        {
            Console.WriteLine("\nChild can " + activity + ".");
        }
    }
    public abstract class PersonFactory
    {
        public abstract Person CreatePerson();
    }
    public class ManFactory : PersonFactory
    {
        public override Person CreatePerson()
        {
            return new Man();
        }
    }
    public class WomanFactory : PersonFactory
    {
        public override Person CreatePerson()
        {
            return new Woman();
        }
    }
    public class ChildFactory : PersonFactory
    {
        public override Person CreatePerson()
        {
            return new Child();
        }
    }

    public class FactoryMethodDemo{
        public void designPatternDemo(){

            PersonFactory manFactory = new ManFactory();
            PersonFactory womanFactory = new WomanFactory();
            PersonFactory childFactory = new ChildFactory();

            var man = manFactory.CreatePerson();
            var woman = womanFactory.CreatePerson();
            var child = childFactory.CreatePerson();

            man.Activity("walk");
            man.Activity("talk");
            woman.Activity("work");
            woman.Activity("give birth");
            child.Activity("crawl");
            child.Activity("cry");
        }
    }
}