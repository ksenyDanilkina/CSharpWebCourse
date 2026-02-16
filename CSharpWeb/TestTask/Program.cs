using System;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            var point1 = new Point(3, 5);

            Console.WriteLine(point1);
#else
                        Console.WriteLine("Неверная конфигурация");
#endif

            #region MyRegion

            var point2 = new Point(1, 0);

            #endregion
        }
    }
}
