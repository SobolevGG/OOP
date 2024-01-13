using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.Optimization.ObjectiveFunctions;
using MathNet.Numerics.Optimization.TrustRegion;

class HydroGeneratorOptimization
{
    // Ускорение свободного падения, м/с^2
    private const double g = 9.81;

    // Метод для расчета мощности гидрогенератора
    public static double CalculatePower(double[] flowRates, double head)
    {
        const double rho = 1000.0;  // плотность воды, кг/м^3
        double sum = 0.0;

        for (int i = 0; i < flowRates.Length; i++)
        {
            double Qi = flowRates[i];
            sum += Qi * (96.7 - (
                Math.Pow(Math.Abs(Qi - 490), 1.78) / Math.Pow(22.5, 2) +
                Math.Pow(Math.Abs(head - 93), 1.5) / Math.Pow(4, 2)
            ));
        }

        // Ваша формула для расчета мощности
        double power = 0.01 * head * g * rho * sum;

        return power;
    }

    static void Main()
    {
        // Ввод ограничений от пользователя
        Console.Write("Введите минимальное значение расхода (куб. м/с): ");
        double minFlowRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите максимальное значение расхода (куб. м/с): ");
        double maxFlowRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите минимальное значение напора (м): ");
        double minHead = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите максимальное значение напора (м): ");
        double maxHead = Convert.ToDouble(Console.ReadLine());

        // Ввод значений расхода для каждого гидрогенератора
        double[] initialFlowRates = new double[12];
        for (int i = 0; i < initialFlowRates.Length; i++)
        {
            Console.Write($"Введите расход для гидрогенератора {i + 1}: ");
            initialFlowRates[i] = Convert.ToDouble(Console.ReadLine());
        }

        double initialHead = (minHead + maxHead) / 2.0;

        // Задаем начальные значения параметров
        var initialGuess = Vector<double>.Build.DenseOfArray(new double[] { initialHead });

        // Создаем объект-функцию для оптимизации
        Func<Vector<double>, double> objectiveFunction = point =>
        {
            double head = point[0];
            double power = -CalculatePower(initialFlowRates, head); // Минус, так как мы максимизируем
            return power;
        };

        // Используем метод BfgsBMinimizer для максимизации мощности с использованием градиента
        var optimizer = new BfgsBMinimizer(1e-6, 1e-6, 1e-6, 50000);

        // Запускаем оптимизацию с ограничениями
        var lowerBound = Vector<double>.Build.DenseOfArray(new double[] { minHead });
        var upperBound = Vector<double>.Build.DenseOfArray(new double[] { maxHead });

        // Создаем объект-функцию с градиентом
        var objectiveWithGradient = ObjectiveFunction.Gradient(objectiveFunction, point =>
        {
            double head = point[0];
            double sum = 0.0;

            for (int i = 0; i < initialFlowRates.Length; i++)
            {
                double Qi = initialFlowRates[i];
                sum += Qi * (96.7 - (
                    Math.Pow(Math.Abs(Qi - 490), 1.78) / Math.Pow(22.5, 2) +
                    Math.Pow(Math.Abs(head - 93), 1.5) / Math.Pow(4, 2)
                ));
            }

            double gradientHead = -0.01 * g * (96.7 - sum) * Math.Pow(Math.Abs(head - 93), 0.5) / Math.Pow(4, 2);
            return Vector<double>.Build.DenseOfArray(new double[] { gradientHead });
        });

        // Запускаем оптимизацию
        var result = optimizer.FindMinimum(objectiveWithGradient, lowerBound, upperBound, initialGuess);

        // Получаем оптимальные значения
        double optimalHead = result.MinimizingPoint[0];
        double optimalPower = -result.FunctionInfoAtMinimum.Value; // Минус, так как мы максимизируем

        // Вывод результатов
        Console.WriteLine($"Оптимальный напор: {optimalHead} м");
        Console.WriteLine($"Максимальная мощность: {Math.Round(optimalPower / 1e6, 3)} МВт");
    }
}