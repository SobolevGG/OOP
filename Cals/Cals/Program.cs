class Program
{
    static void Main()
    {
        // Генерация массива расходов воды Qi для 12 гидрогенераторов
        double[] QiArray = GenerateQiArray(0, 615);

        // Вывод расходов воды через гидрогенераторы
        Console.WriteLine("Расходы воды через гидрогенераторы:");
        for (int i = 0; i < 12; i++)
        {
            Console.WriteLine($"Гидрогенератор {i + 1}: {Math.Round(QiArray[i], 1)} м3/с");
        }

        // Расчет мощности ГЭС
        double ZNR1 = 150;
        double ZNR2 = 320;
        double power = CalculatePower(QiArray, ZNR1, ZNR2) / 1000000; // переводим в мегаватты
        Console.WriteLine($"Мощность ГЭС: {power} МВт");

        // Штрафная функция
        double totalPenalty = CalculateTotalPenalty(QiArray, ZNR1, ZNR2);
        Console.WriteLine($"Общий штраф, МВт: {totalPenalty / 1000000}");
    }

    // Пример генерации случайных значений от 0 до 615
    static double[] GenerateQiArray(double minQ, double maxQ)
    {
        // Создаем объект Random для генерации случайных чисел
        Random random = new Random();

        // Создаем массив для хранения расходов воды Qi
        double[] QiArray = new double[12];

        for (int i = 0; i < 12; i++)
        {
            // Генерируем случайное значение с плавающей точкой в диапазоне от minQ до maxQ
            // используя random.NextDouble() и преобразуем его к нужному диапазону
            QiArray[i] = minQ + (maxQ - minQ) * random.NextDouble();
        }

        return QiArray;
    }

    static double CalculatePower(double[] QiArray, double ZNR1, double ZNR2)
    {
        double H = 93; // ваше значение H
        double g = 9.81; // ускорение свободного падения
        double rho = 1000; // плотность воды
        double sum = 0;

        for (int i = 0; i < 12; i++)
        {
            double term1 = 96.7 - Math.Pow(Math.Abs(QiArray[i] - 490), 1.78) / Math.Pow(22.5, 2);
            double term2 = Math.Pow(Math.Abs(H - 93), 1.5) / Math.Pow(4, 2);

            // Штрафы за превышение расхода
            double penalty = CalculatePenalty(QiArray[i]);

            // Штрафы при недопустимом расходе
            double penaltyZNR = CalculatePenaltyZNR(QiArray[i], ZNR1, ZNR2);

            // Учитываем штрафы в общей сумме мощности
            sum += (QiArray[i] - penalty - penaltyZNR) * (0.01 * H * g * rho * term1 + term2);
        }

        return sum;
    }

    static double CalculatePenalty(double Qi)
    {
        double penalty = 0;
        double threshold = 615;

        // Реализация штрафной функции
        if (Qi > threshold)
        {
            penalty += 15.85 * 1000000 * (Qi - threshold);
        }

        return penalty;
    }

    static double CalculatePenaltyZNR(double Qi, double ZNR1, double ZNR2)
    {
        double penaltyZNR = 0;

        if (Qi < ZNR1 || Qi > ZNR2)
        {
            penaltyZNR += 15.85 * 1000000 * Math.Abs(Qi - ZNR1);
        }

        return penaltyZNR;
    }

    static double CalculateTotalPenalty(double[] QiArray, double ZNR1, double ZNR2)
    {
        double totalPenalty = 0;

        for (int i = 0; i < 12; i++)
        {
            // Штрафы за превышение расхода
            double penalty = CalculatePenalty(QiArray[i]);

            // Штрафы при недопустимом расходе
            double penaltyZNR = CalculatePenaltyZNR(QiArray[i], ZNR1, ZNR2);

            // Общий штраф
            totalPenalty += penalty + penaltyZNR;
        }

        return totalPenalty;
    }
}