using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Domain.Exceptions
{
    public class MedicineException:Exception
    {
        public MedicineException(string message):base(message) {}
    }
}
