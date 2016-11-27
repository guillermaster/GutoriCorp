using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GutoriCorp.Common
{
    public class Enums
    {
        public enum GeneralCatalog
        {
            ContractType = 1,
            GeneralStatus = 2,
            ContractFrequency = 3,
            ContractLateFeeType = 4
        }

        public enum GeneralStatus
        {
            Active = 3,
            Inactive = 4
        }
    }
}
