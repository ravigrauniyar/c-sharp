using System;
namespace Internship
{
    public sealed class Instance
    {
        private static Instance ins = null;
        private static readonly object resource = new object();
        private Instance()
        {
            Console.WriteLine("Instance created successfully");
        }
        public static Instance GetInstance
        {
            get
            {
                lock (resource)
                {
                    if (ins == null)
                    {
                        ins = new Instance();
                    }
                    return ins;
                }
            }
        }
    }
    public class SingletonDemo
    {
        public void designPatternDemo()
        {
            Instance firstInstance = Instance.GetInstance;
            Instance secondInstance = Instance.GetInstance;

            if (firstInstance == secondInstance)
            {
                Console.WriteLine("Same instances!");
            }
            else
            {
                Console.WriteLine("Different instances!");
            }
        }
    }
}