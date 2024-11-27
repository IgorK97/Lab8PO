using DLab5WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5WebApp.Models
{
    public class ClientDTO : UserModel
    {
        public string? AddressDel { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
