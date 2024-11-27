using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Exceptions
{
    public class OrderComponentMissingException : Exception
    {
        public int OId;
        public string Name;

        public OrderComponentMissingException(int oId, string name)
        {
            OId = oId;
            Name = name;
        }
    }
}
