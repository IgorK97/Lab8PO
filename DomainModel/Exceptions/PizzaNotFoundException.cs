using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Exceptions
{
    public class PizzaNotFoundException : Exception
    {
        public int IId;

        public PizzaNotFoundException(int iId)
        {
            IId = iId;
        }
    }
}
