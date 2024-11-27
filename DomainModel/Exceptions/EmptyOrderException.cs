using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Exceptions
{
    public class EmptyOrderException : Exception
    {
        public int odId;

        public EmptyOrderException(int odId)
        {
            this.odId = odId;
        }
    }
}
