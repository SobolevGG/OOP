using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MaxLoadRoughZone
    {
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
            { 98, 100 }
        };

        // График ЗНР2
        private readonly Dictionary<double, double> _roughZoneSB = new Dictionary<double, double>
        {
            { 79, 200 },
            { 93, 250 }
        };

        // Максмиальный и минимальные напоры
        private readonly double _maxWaterHead = 100.5;
        private readonly double _minWaterHead = 76;

        public double MinWaterHead
        {
            get => _minWaterHead;
        }

        public double MaxWaterHead
        {
            get => _maxWaterHead;
        }

        // Напор
        private double _waterHead;

        // Поля для значений вводимых верхнего и нижнего бьефов
        private double _upperReservoirLevel;
        private double _lowerReservoirLevel;

        // Ограничения по верхнему бьефу
        private readonly double _minUpperReservoirLevel = 225;
        private readonly double _maxUpperReservoirLevel = 243;

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
                if (value < _minUpperReservoirLevel || value > _maxUpperReservoirLevel)
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
            private set
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

        public double MaxPower => InterpolatePower(WaterHead, _maxPowerGraph);

        public double RoughZoneFB => InterpolatePower(WaterHead, _roughZoneFB);

        public double RoughZoneSB => InterpolatePower(WaterHead, _roughZoneSB);

        public static double InterpolatePower(double waterHead, Dictionary<double, double> powerGraph)
        {
            double lowerHead = powerGraph.Keys.Where(x => x <= waterHead).Max();
            double upperNapore = powerGraph.Keys.Where(x => x >= waterHead).Min();

            double lowerPower = powerGraph[lowerHead];
            double upperPower = powerGraph[upperNapore];

            double interpolatedPower = lowerPower + (upperPower - lowerPower) * (waterHead - lowerHead) / (upperNapore - lowerHead);

            return interpolatedPower;
        }
    }
}
