using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThailandAddress.Initializer.Model
{
    public class AreaTemplate
    {
        public string DISTRICT_CODE { get; set; } = string.Empty;
        public int DISTRICT_ID { get; set; }
        public string DISTRICT_NAME { get; set; } = string.Empty;
        public int GEO_ID { get; set; }
        public int PROVINCE_ID { get; set; }
    }
}
