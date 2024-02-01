using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class UserConstraints
    {
        public double MinFlowRate { get; set; }
        public double MaxFlowRate { get; set; }
        public double MinHead { get; set; }
        public double MaxHead { get; set; }
    }

}
