using System;
namespace Internship
{
    public abstract class Builder
    {
        public Tech tech = new Tech();
        public abstract void GetTechType();
        public abstract void GetPrice();
        public abstract Tech GetTech();
    }
    public class ConcreteFanBuilder : Builder
    {
        public override void GetTechType()
        {
            tech.AddSpec("Tech Type = Fan");
        }
        public override void GetPrice()
        {
            tech.AddSpec("Fan Price = Rs.10000");
        }
        public override Tech GetTech()
        {
            return tech;
        }
    }
    public class ConcreteLaptopBuilder : Builder
    {
        public override void GetTechType()
        {
            tech.AddSpec("Tech Type = Laptop");
        }
        public override void GetPrice()
        {
            tech.AddSpec("Laptop Price = Rs.150000");
        }
        public override Tech GetTech()
        {
            return tech;
        }
    }
    public class Tech
    {
        private List<string> specs = new List<string>();
        public void AddSpec(string spec)
        {
            specs.Add(spec);
        }
        public string ShowSpecs()
        {
            return string.Join(", ", specs);
        }
    }
    public class TechExpert
    {
        public void buildTech(Builder builder){

            builder.GetTechType();
            builder.GetPrice();
        }
    }
    public class BuilderDemo
    {
        public void designPatternDemo()
        {
            TechExpert techExpert = new TechExpert();
            Builder builder;

            builder = new ConcreteFanBuilder();
            techExpert.buildTech(builder);

            var fan = builder.GetTech();
            Console.WriteLine("\n" + fan.ShowSpecs() + "\n");

            builder = new ConcreteLaptopBuilder();
            techExpert.buildTech(builder);

            var laptop = builder.GetTech();
            Console.WriteLine("\n" + laptop.ShowSpecs() + "\n");
        }
    }
}