namespace SingletonePattern
{
    public class Singleton
    {
        public string Date { get; private set; }
        public static string text = "hello";

        private Singleton() 
        {
            Date = "";
        }

        public static Singleton GetInstance() 
        {
            return Nested.instance;
        }

        private class Nested
        {
            internal static readonly Singleton instance = new Singleton();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Singleton.text);
        }
    }
}