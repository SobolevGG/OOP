using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class MaxLoadRoughZone
    {
        public MaxLoadRoughZone()
        {
            // По умолчанию
        }

        // График максимальной мощности
        private readonly Dictionary<double, double> _maxPowerGraph = new Dictionary<double, double>
        {
            { 76, 400 },
            { 87, 484.565 },
            { 93, 508 },
            { 100.5, 508 }
        };

        // График ЗНР1
        private readonly Dictionary<double, double> _roughZoneFB = new Dictionary<double, double>
        {
            { 76, 50 },
            { 100.5, 103.991 }
        };

        // График ЗНР2
        private readonly Dictionary<double, double> _roughZoneSB = new Dictionary<double, double>
        {
            { 76, 191.549 },
            { 84, 210.798 },
            { 93, 250 },
            { 100.5, 274.648}
        };

        // Максмиальный и минимальные напоры
        private readonly double _maxWaterHead = 100.5;
        private readonly double _minWaterHead = 76;

        // Ограничения по верхнему бьефу
        private readonly double _minUpperReservoirLevel = 225;
        private readonly double _maxUpperReservoirLevel = 243;

        // Напор
        private double _waterHead;

        // Поля для значений вводимых верхнего и нижнего бьефов
        private double _upperReservoirLevel;
        private double _lowerReservoirLevel;

        

        public double MinWaterHead
        {
            get => _minWaterHead;
        }

        public double MaxWaterHead
        {
            get => _maxWaterHead;
        }

        public double MinUpperReservoirLevel
        {
            get => _minUpperReservoirLevel;
        }

        public double MaxUpperReservoirLevel
        {
            get => _maxUpperReservoirLevel;
        }

        // Ограничения по нижнему бьефу
        public double MaxLowerReservoirLevel => _maxUpperReservoirLevel - _minWaterHead;
        public double MinLowerReservoirLevel => _minUpperReservoirLevel - _maxWaterHead;


        public double LowerReservoirLevel
        {
            get { return _lowerReservoirLevel; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Ввод не может быть пустым.");
                }
                if (value < MinLowerReservoirLevel || value > MaxLowerReservoirLevel)
                {
                    throw new ArgumentOutOfRangeException($"Значение уровня нижнего бьефа должен лежать в диапазоне от {MinLowerReservoirLevel} " +
                        $"до {MaxLowerReservoirLevel}.");
                }
                _lowerReservoirLevel = value;
                UpdateWaterHead();
            }
        }

        public double UpperReservoirLevel
        {
            get { return _upperReservoirLevel; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Ввод не может быть пустым.");
                }
                if (value < _minUpperReservoirLevel || value > _maxUpperReservoirLevel)
                {
                    throw new ArgumentOutOfRangeException(nameof(UpperReservoirLevel),
                        $"Значение уровня верхнего бьефа должно лежать в диапазоне от {_minUpperReservoirLevel} " +
                        $"до {_maxUpperReservoirLevel}.");
                }
                _upperReservoirLevel = value;
                UpdateWaterHead();
            }
        }

        public double WaterHead
        {
            get { return _waterHead; }
            set
            {
                if (value < _minWaterHead || value > _maxWaterHead)
                {
                    throw new ArgumentOutOfRangeException($"Значение напора должно быть в диапазоне от {_minWaterHead} до {_maxWaterHead} м.");
                }
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("Ввод не может быть пустым.");
                }
                _waterHead = value;
            }
        }

        // Конструктор - это метод, который вызывается при создании нового экземпляра класса(объекта).
        // В данном случае, конструктор принимает аргумент waterHead -
        // значение напора.Когда создается новый объект MaxLoadRoughZone
        public MaxLoadRoughZone(double waterHead)
        {
            WaterHead = waterHead;
        }

        public void UpdateWaterHead()
        {
            double newWaterHead = UpperReservoirLevel - LowerReservoirLevel;

            if (newWaterHead < _minWaterHead || newWaterHead > _maxWaterHead)
            {
                throw new ArgumentOutOfRangeException($"Значение напора должно быть в диапазоне от {_minWaterHead} до {_maxWaterHead} м.");
            }

            _waterHead = newWaterHead;
        }

        public string HU { get; set; }

        public double MaxPower
        { get { return InterpolatePower(WaterHead, _maxPowerGraph); }
            set {  }
        }

        public double RoughZoneFB
        {
            get
            {
                return InterpolatePower(WaterHead, _roughZoneFB);
            }
            set { }
        }

        public double RoughZoneSB
        {
            get
            {
                return InterpolatePower(WaterHead, _roughZoneSB);
            }
            set { }
        }

        // Метод для интерполяции значения мощности на основе заданного уровня напора (waterHead)
        // и графика мощности (powerGraph), представленного в виде словаря, где ключи - уровни напора,
        // а значения - соответствующие значения мощности.
        public static double InterpolatePower(double waterHead, Dictionary<double, double> powerGraph)
        {
            // Проверяем, содержит ли коллекция элементы
            if (powerGraph.Count == 0)
            {
                throw new InvalidOperationException("Переданная Вами коллекция не содержит элементов.");
            }

            // Находим ближайший уровень напора, не превышающий заданный waterHead
            double lowerHead = powerGraph.Keys.Where(x => x <= waterHead).DefaultIfEmpty(powerGraph.Keys.Min()).Max();

            // Находим ближайший уровень напора, не менее заданного waterHead
            double upperHead = powerGraph.Keys.Where(x => x >= waterHead).DefaultIfEmpty(powerGraph.Keys.Max()).Min();

            // Если waterHead выходит за пределы диапазона ключей, возвращаем значение ближайшего края
            if (waterHead <= lowerHead)
            {
                return powerGraph[lowerHead];
            }
            else if (waterHead >= upperHead)
            {
                return powerGraph[upperHead];
            }

            // Получаем значения мощности для ближайших уровней напора
            double lowerPower = powerGraph[lowerHead];
            double upperPower = powerGraph[upperHead];

            // Линейная интерполяция мощности на основе заданного уровня напора
            double interpolatedPower = lowerPower + (upperPower - lowerPower) * (waterHead - lowerHead) / (upperHead - lowerHead);

            return interpolatedPower;
        }

    }
}
