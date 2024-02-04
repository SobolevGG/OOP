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

        public double GetMaxPower(double waterHead)
        {
            return InterpolatePower(waterHead, _maxPowerGraph);
        }

        public double GetRoughZoneFBPower(double waterHead)
        {
            return InterpolatePower(waterHead, _roughZoneFB);
        }

        public double GetRoughZoneSBPower(double waterHead)
        {
            return InterpolatePower(waterHead, _roughZoneSB);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="waterHead">Напор воды.</param>
        /// <param name="powerGraph">График.</param>
        /// <returns></returns>
        public static double InterpolatePower(double waterHead, Dictionary<double, double> powerGraph)
        {
            double lowerNapore = powerGraph.Keys.Where(x => x <= waterHead).Max();
            double upperNapore = powerGraph.Keys.Where(x => x >= waterHead).Min();

            double lowerPower = powerGraph[lowerNapore];
            double upperPower = powerGraph[upperNapore];

            double interpolatedPower = lowerPower + (upperPower - lowerPower) * (waterHead - lowerNapore) / (upperNapore - lowerNapore);

            return interpolatedPower;
        }
    }
}
