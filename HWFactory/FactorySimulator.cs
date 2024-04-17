namespace HWFactory
{
    internal class FactorySimulator
    {
        private Random rnd = new Random();

        private int minCapacity = 0;
        private int maxCapacity = 100;

        private int steps = 250;
        private int detailIncome = 5;

        private List<int> As = new List<int>()
        {
            5,
            10,
            30,
        };

        private List<int> markedXs = new List<int>()
        {
            10,
            20,
            30,
            40,
            50,
            60,
            70,
            80,
            90,
        };

        private float Rand(int a)
        {
            return rnd.Next(-a, a) / 100f + 1;
        }

        public void Simulate(int experiments)
        {

            foreach (var a in As)
            {
                for (int startingCapacity = minCapacity; startingCapacity <= maxCapacity; ++startingCapacity)
                {
                    int failsCount = 0;

                    for (int experiment = 0; experiment < experiments; ++experiment)
                    {
                        bool failedFlag = false;

                        var x1 = startingCapacity;
                        var x2 = startingCapacity;
                        var x3 = startingCapacity;

                        for (int step = 0; step < steps; ++step)
                        {
                            var dx1 = (int)(detailIncome * Rand(a));
                            x1 += dx1;

                            var dx2 = (int)(detailIncome * Rand(a));
                            x2 += dx2;
                            x1 -= dx2;

                            var dx3 = (int)(detailIncome * Rand(a));
                            x3 += dx3;
                            x2 -= dx3;

                            x3 -= (int)(detailIncome * Rand(a));

                            if (experiment != 0)
                            {
                                if (x1 > maxCapacity || x1 < 0 || x2 > maxCapacity || x2 < 0 || x3 > maxCapacity || x3 < 0)
                                {
                                    failedFlag = true;
                                }                                
                            }

                            if (failedFlag)
                            {
                                ++failsCount;
                                break;
                            }
                        }
                    }

                    double failProb = (double)failsCount / (double)experiments;

                    if (markedXs.Contains(startingCapacity) || startingCapacity == minCapacity || startingCapacity == maxCapacity)
                    {
                        Console.WriteLine($"A: {a}, Начальная заполненность: {startingCapacity}, Вероятность ошибки: {failProb}");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
