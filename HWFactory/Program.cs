namespace HWFactory
{
    public static class Program
    {
        public static int Main()
        {
            var fs = new FactorySimulator();

            fs.Simulate(100);

            return 0;
        }
    }
}