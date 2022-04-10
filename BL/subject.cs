using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    internal class subject
    {
        public subject(string code , int creditHours , string subjectType , int subjectFee)
        {
            this.code = code;
            this.creditHours = creditHours;
            this.subjectType = subjectType;
            this.subjectFee = subjectFee;
        }
        public string code;
        public int creditHours;
        public string subjectType;
        public int subjectFee;
    }
}
