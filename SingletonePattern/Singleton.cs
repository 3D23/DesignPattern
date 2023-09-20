namespace SingletonePattern 
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            computer.Launch("Linux");
            Console.WriteLine(computer.OS.Name);

            computer.OS = OS.GetInstance("Windows");
            Console.WriteLine(computer.OS.Name);

            Console.ReadLine();
        }
    }
    class Computer
    {
        public OS OS { get; set; }
        
        public void Launch(string osName)
        {
            OS = OS.GetInstance(osName);
        }
    }

    class OS
    {
        private static OS instance;

        public string Name { get; set; }

        private OS(string name)
        {
            Name = name;
        }

        public static OS GetInstance(string name) 
        {
            if (instance == null)
                instance = new OS(name);
            return instance;
        }
    }
}
