namespace SingletonePattern
{
    class OS
    {
        private static OS instance;

        public string Name { get; private set; }
        private statc object syncRoot = new object();

        protected OS(string name)
        {
            Name = name;
        }

        public static OS GetInstance(string name)
        {
            if (instance == null) 
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new OS(name);
                }
            }
            return instance;
        }
    }
}