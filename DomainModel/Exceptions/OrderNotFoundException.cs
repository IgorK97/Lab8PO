using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public int OId;

        public OrderNotFoundException(int oId)
        {
            OId = oId;
        }
    }
}
