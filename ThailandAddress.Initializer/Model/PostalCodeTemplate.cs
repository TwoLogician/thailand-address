using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThailandAddress.Initializer.Model
{
    public class PostalCodeTemplate
    {
        public string DISTRICT_ID { get; set; } = string.Empty;
        public string PROVINCE_ID { get; set; } = string.Empty;
        public string SUB_DISTRICT_CODE { get; set; } = string.Empty;
        public string SUB_DISTRICT_ID { get; set; } = string.Empty;
        public string ZIPCODE { get; set; } = string.Empty;
        public int ZIPCODE_ID { get; set; }
    }
}
