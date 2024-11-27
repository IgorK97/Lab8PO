using DAL.Repository;
using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MongoRepository
{
    public class DbReposMongo : IDbRepos
    {
        private MongoContext db;
        private PizzaRepositoryMongo pizzaRepository;
        private OrderRepositoryMongo orderRepository;
        private IngredientRepositoryMongo ingredientRepository;
        private ClientRepositoryMongo clientRepository;
        private DelStatusRepositoryMongo delstatusRepository;
        private CourierRepositoryMongo courierRepository;
        private ManagerRepositoryMongo managerRepository;
        private OrderLineRepositoryMongo orderLineRepository;
        private PizzaSizeRepositoryMongo pizzaSizeRepository;
        private ReportRepositoryMongo reportRepository;


        public DbReposMongo(string cs)
        {
            db = new MongoContext(cs);
            pizzaRepository = new PizzaRepositoryMongo(db);
            orderRepository = new OrderRepositoryMongo(db);
            ingredientRepository = new IngredientRepositoryMongo(db);
            clientRepository = new ClientRepositoryMongo(db);
            delstatusRepository = new DelStatusRepositoryMongo(db);
            courierRepository = new CourierRepositoryMongo(db);
            managerRepository = new ManagerRepositoryMongo(db);
            orderLineRepository = new OrderLineRepositoryMongo(db);
            pizzaSizeRepository = new PizzaSizeRepositoryMongo(db);
            reportRepository = new ReportRepositoryMongo(db);
        }

        public IRepository<Pizza> Pizzas
        {
            get
            {
               
                return pizzaRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                
                return orderRepository;
            }
        }

        public IRepository<Ingredient> Ingredients
        {
            get
            {
               
                return ingredientRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                
                return clientRepository;
            }
        }
        //IRepository<User> Users { get { 
        //    if(userRepo)
        //    } }
        public IRepository<Courier> Couriers
        {
            get
            {
                
                return courierRepository;
            }
        }
        public IRepository<Manager> Managers
        {
            get
            {
                
                return managerRepository;
            }
        }
        public IRepository<DelStatus> DelStatuses
        {
            get
            {
                
                return delstatusRepository;
            }
        }
        public IRepository<OrderLine> OrderLines
        {
            get
            {
                
                return orderLineRepository;
            }
        }
        public IRepository<PizzaSize> PizzaSizes
        {
            get
            {
                
                return pizzaSizeRepository;
            }
        }

        public IReportsRepository Reports
        {
            get
            {
                
                return reportRepository;
            }
        }

        public int Save()
        {
            return 1;
        }
    }
}
