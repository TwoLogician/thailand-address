using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThailandAddress.Initializer.Model
{
    public class ProvinceTemplate
    {
        public int GEO_ID { get; set; }
        public string PROVINCE_CODE { get; set; } = string.Empty;
        public int PROVINCE_ID { get; set; }
        public string PROVINCE_NAME { get; set; } = string.Empty;
    }
}
