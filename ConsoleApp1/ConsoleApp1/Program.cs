using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Extreme.Mathematics;
using HydroGeneratorOptimization;
using static HydroGeneratorOptimization.Formulas;
using MathNet.Numerics.Optimization;
using System;
using MathNet.Numerics;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.Optimization.ObjectiveFunctions;
using System;
using Extreme.Mathematics.Calculus.OrdinaryDifferentialEquations;
using System;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HydroGeneratorOptimization
{
    class GeneticAlgorithm
    {
        private readonly int populationSize;
        private readonly double crossoverRate;
        private readonly double mutationRate;
        private readonly int chromosomeLength;
        private readonly double[] maxFlowRates;
        private readonly double[] minFlowRates;
        private readonly double ZNR1;
        private readonly double ZNR2;
        private readonly double head;

        public GeneticAlgorithm(int populationSize, double crossoverRate, double mutationRate, int chromosomeLength, double[] maxFlowRates, double[] minFlowRates, double znr1, double znr2, double head)
        {
            this.populationSize = populationSize;
            this.crossoverRate = crossoverRate;
            this.mutationRate = mutationRate;
            this.chromosomeLength = chromosomeLength;
            this.maxFlowRates = maxFlowRates;
            this.minFlowRates = minFlowRates;
            ZNR1 = znr1;
            ZNR2 = znr2;
            this.head = head;
        }

        private double Fitness(double[] chromosome)
        {
            // Рассчет мощности ГЭС по формуле
            double power = chromosome.Select(Qi => Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 490), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 93), 1.5) / Math.Pow(4, 2)))).Sum();

            // Возвращаем отрицательное значение для минимизации мощности
            return -power;
        }

        private bool IsValid(double[] chromosome)
        {
            // Проверка на соответствие ограничениям (максимум, минимум, ЗНР)
            for (int i = 0; i < chromosome.Length; i++)
            {
                if (chromosome[i] < minFlowRates[i] || chromosome[i] > maxFlowRates[i])
                    return false;

                if (chromosome[i] < 0 && chromosome[i] > ZNR1 && chromosome[i] < ZNR2 && chromosome[i] > 615)
                    return false;
            }

            return true;
        }

        private double[] InitializeChromosome()
        {
            Random random = new Random();
            double[] chromosome = new double[chromosomeLength];

            for (int i = 0; i < chromosomeLength; i++)
            {
                chromosome[i] = random.NextDouble() * (maxFlowRates[i] - minFlowRates[i]) + minFlowRates[i];
            }

            return chromosome;
        }

        private double[][] InitializePopulation()
        {
            double[][] population = new double[populationSize][];
            for (int i = 0; i < populationSize; i++)
            {
                population[i] = InitializeChromosome();
            }

            return population;
        }

        private double[][] SelectParents(double[][] population)
        {
            // Выбор лучших особей в текущей популяции
            return population.OrderBy(Fitness).Take(populationSize).ToArray();
        }

        private double[] Crossover(double[] parent1, double[] parent2)
        {
            Random random = new Random();
            double[] child = new double[chromosomeLength];

            for (int i = 0; i < chromosomeLength; i++)
            {
                if (random.NextDouble() < crossoverRate)
                    child[i] = parent1[i];
                else
                    child[i] = parent2[i];
            }

            return child;
        }

        private void Mutate(double[] chromosome)
        {
            Random random = new Random();

            for (int i = 0; i < chromosomeLength; i++)
            {
                if (random.NextDouble() < mutationRate)
                {
                    chromosome[i] += random.NextDouble() * (maxFlowRates[i] - minFlowRates[i]) + minFlowRates[i];
                    chromosome[i] = Math.Max(minFlowRates[i], Math.Min(maxFlowRates[i], chromosome[i]));
                }
            }
        }

        public double[] Optimize(bool maximize)
        {
            double[][] population = InitializePopulation();

            for (int generation = 0; generation < 100; generation++)
            {
                double[][] parents = SelectParents(population);

                double[][] offspring = new double[populationSize][];

                for (int i = 0; i < populationSize; i += 2)
                {
                    double[] parent1 = parents[i];
                    double[] parent2 = parents[i + 1];

                    double[] child1 = Crossover(parent1, parent2);
                    double[] child2 = Crossover(parent1, parent2);

                    Mutate(child1);
                    Mutate(child2);

                    offspring[i] = child1;
                    offspring[i + 1] = child2;
                }

                population = offspring;

                // Выводим лучшее решение на текущей итерации
                double[] bestSolution = population.OrderByDescending(Fitness).First();
                Console.WriteLine($"Generation {generation + 1}: Best Fitness = {Fitness(bestSolution)}");

                // Инвертирование знака для минимизации
                if (!maximize)
                {
                    bestSolution = bestSolution.Select(x => -x).ToArray();
                }

                return bestSolution;
            }

            return null;
        }
    }



    public class Program
    {
        private static double CalculatePower(double[] flowRates, double head)
        {
            // Рассчет мощности ГЭС по формуле
            return flowRates.Select(Qi => Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 490), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 93), 1.5) / Math.Pow(4, 2)))).Sum();
        }

        public static void Main()
        {
            // Заданные значения
            int chromosomeLength = 12;
            double[] maxFlowRates = Enumerable.Repeat(615.0, chromosomeLength).ToArray();
            double[] minFlowRates = Enumerable.Repeat(0.0, chromosomeLength).ToArray();
            double ZNR1 = 100.0;
            double ZNR2 = 500.0;
            double head = 90.0;

            // Максимизация мощности
            GeneticAlgorithm gaMaximize = new GeneticAlgorithm(100, 0.75, 0.1, chromosomeLength, maxFlowRates, minFlowRates, ZNR1, ZNR2, head);
            double[] resultMaximize = gaMaximize.Optimize(true);

            // Минимизация мощности
            GeneticAlgorithm gaMinimize = new GeneticAlgorithm(100, 0.75, 0.1, chromosomeLength, maxFlowRates, minFlowRates, ZNR1, ZNR2, head);
            double[] resultMinimize = gaMinimize.Optimize(false);

            // Вывод результатов
            Console.WriteLine($"Optimal Flow Rates (Maximize): {string.Join(", ", resultMaximize)}");
            Console.WriteLine($"Optimal Power (Maximize): {CalculatePower(resultMaximize, head)}");

            Console.WriteLine($"Optimal Flow Rates (Minimize): {string.Join(", ", resultMinimize)}");
            Console.WriteLine($"Optimal Power (Minimize): {CalculatePower(resultMinimize, head)}");



#if false
            // Создаем экземпляр XmlFileManager для GeneratorFlows
            var generatorFlowsFileManager = new XmlFileManager<GeneratorFlows>();

            // Загрузка файла расходов для каждого гидрогенератора
            GeneratorFlows generatorFlows = generatorFlowsFileManager.Load("generatorFlows.xml");

            // Вывод расходов в консоль
            // Display.DisplayGeneratorFlows(generatorFlows?.Flows);        

            // Создаем экземпляр XmlFileManager для List<PowerFormula>
            var powerFormulaFileManager = new XmlFileManager<List<PowerFormula>>();

            // Загрузка файла формул
            List<PowerFormula> powerFormulas = powerFormulaFileManager.Load("formulas.xml");

            // Вывод формул в консоль
            Display.DisplayFormulas(powerFormulas);



            // Создаем экземпляр XmlFileManager для UserConstraints
            var userConstraintsFileManager = new XmlFileManager<UserConstraints>();

            // Загрузка файла ограничений пользователя
            UserConstraints userConstraints = userConstraintsFileManager.Load("userConstraints.xml");

            // Вывод ограничений пользователя в консоль
            Display.DisplayUserConstraints(userConstraints);


            // CreateNewListAndAddForm("Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 494), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 91), 1.5) / Math.Pow(4, 2)))", "NewFormula");

            // AddInListNewForm("Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 494), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 91), 1.5) / Math.Pow(4, 2)))", "NewFormula321");

            // Пример удаления формулы с индексом 14
            // ListFormulas.RemoveFormByNum(powerFormulaFileManager.Load("formulas.xml"), 14);





            // Создаем экземпляр XmlFileManager для GeneratorFlows
            var generatorFlowsFileManager = new XmlFileManager<GeneratorFlows>();

            // Загрузка файла расходов для каждого гидрогенератора
            GeneratorFlows generatorFlows = generatorFlowsFileManager.Load("generatorFlows.xml");

            // Предполагается, что есть 12 гидрогенераторов
            double[] initialFlowRates = GeneratorFlow.CheckWaterFlows(generatorFlows, 12);
            double initialHead = 90.0;






            PowerCalculation.CalculatePower("formulas.xml", initialFlowRates, initialHead);



#endif
        }
    }
}
