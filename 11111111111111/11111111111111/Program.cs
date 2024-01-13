using System;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;

class Program
{
    static void Main()
    {
        double[] x = { 100, 98, 96, 93, 90, 88};
        double[] y = { 508, 508, 508, 508, 497.60436562, 489.980900408 };

        // Интерполяция полиномом Лагранжа
        IInterpolation interpolation = Interpolate.Linear(x, y);

        // Точки для проверки интерполяции
        double[] testPoints = { 90, 90.5, 91, 91.5, 92, 92.5, 93, 93.5, 94, 94.5, 95, 95.5, 96 };

        var tmp = 0;
        Console.WriteLine($"\n    При максимальном попуске воды через турбины и напоре:");
        // Выводим результат интерполяции для тестовых точек
        foreach (var point in testPoints)
        {
            tmp++;
            double interpolatedValue = interpolation.Interpolate(point);
            Console.WriteLine($"    {tmp}. H = {point} м, P = {Math.Round(interpolatedValue, 2)} МВт.");
        }
        Console.WriteLine($"\n    Расчёт завершён.");
    }
}
