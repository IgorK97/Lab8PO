using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5WebApp.Models
{
    public class DelStatusModel
    {
        public DelStatusModel()
        {

        }
        public int Id { get; set; }

        public string description { get; set; }
        public DelStatusModel(DelStatus ds)
        {
            Id = ds.Id;
        }
    }
}
