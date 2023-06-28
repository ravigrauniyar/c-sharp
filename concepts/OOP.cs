namespace Internship
{
    abstract class AbstractionDemo
    {
        public abstract int getCount();
    }
    class EncapsulationDemo
    {
        string name = "N/A";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    interface InterfaceDemo
    {
        int getAge();
    }
    class DemoClass : AbstractionDemo, InterfaceDemo
    {
        private int counter = 1;
        public override int getCount()
        {
            return counter;
        }
        int age = 21;
        public int getAge()
        {
            return age;
        }
    }
    class PolyDemo: EncapsulationDemo
    {
        string getNumber(string num)
        {
            return num;
        }
        string getAddress(string addr)
        {
            return addr;
        }
    }
    class OOP : PolyDemo
    {
        string getNumber(string num)
        {
            return "Your Number: " + num;
        }
        string getAddress(string addr, string country)
        {
            return "Your address: " + addr + " & Your country: " + country;
        }
        public void oopDemo()
        {

            OOP oop = new OOP();

            DemoClass absNinterfaceDemo = new DemoClass();

            int sn = absNinterfaceDemo.getCount();
            Console.WriteLine("\n\nAbstractionDemo: S.N. " + sn);

            EncapsulationDemo encapDemo = new EncapsulationDemo();
            Console.WriteLine("\nEncapsulationDemo: Initial Name: " + encapDemo.Name);

            encapDemo.Name = "Ravi";
            Console.WriteLine("\nFinal Name: " + encapDemo.Name);

            oop.Name = "Inherited Name";
            Console.WriteLine("\nInheritanceDemo: Name through Multi-level inheritance: " + oop.Name);

            Console.WriteLine("\nInterfaceDemo: Age: " + absNinterfaceDemo.getAge());

            Console.WriteLine("\nOverridingDemo: " + oop.getNumber("9821129864"));

            Console.WriteLine("\nOverloadingDemo: " + oop.getAddress("Hetauda-10", "Nepal") + "\n\n");
        }
    }
}