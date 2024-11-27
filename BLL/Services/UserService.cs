using DTO;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Services;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IDbRepos dbr;
        //PizzaDeliveryContext db;
        public UserService(IDbRepos repos)
        {
            dbr = repos;
            //db = new PizzaDeliveryContext();
        }
        public List<ManagerDto> GetAllManagers()
        {
            return dbr.Managers.GetList().ToList().Select(i => new ManagerDto(i)).ToList();
        }

        public List<CouriersDto> GetAllCouriers()
        {
            return dbr.Couriers.GetList().ToList().Select(i => new CouriersDto(i)).ToList();
        }
    }
}
