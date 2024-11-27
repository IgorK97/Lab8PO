using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IPizzaService
    {
        bool Save();

        List<PizzaDto> GetPizzas();

        List<PizzaSizesDto> GetPizzaSizes();
    }
}
